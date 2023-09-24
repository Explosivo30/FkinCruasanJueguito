using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellTarget : DragObjectTarget
{
    static SellTarget instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        HideBuySellInventory();
    }

    [SerializeField] private GameObject SellingItemButtonPrefab;
    [SerializeField] Transform sellContent;
    [SerializeField] public TMPro.TextMeshProUGUI precioInventario;


    protected override bool OnDropRequirements(PointerEventData eventData)
    {
        InventoryButton inventoryButton = eventData.pointerDrag.GetComponent<InventoryButton>();
        if (inventoryButton == null) return false;
        GameManager.Instance.SellItemFromBag(inventoryButton.objeto);
        Destroy(inventoryButton.gameObject);
        if (GameManager.Instance.currentMoney >= GameManager.Instance.maxMoney)
        {
            GameManager.Instance.WinGame();
        }
        return true;
    }

    List<GameObject> buttons = new();
    public static void ShowBuySellInventory(Robable robable)
    {
        instance.gameObject.SetActive(true);
        if (instance == null)
        {
            Debug.Log("no sellInventory");
            return;
        }
        for (int i = instance.buttons.Count-1; i >= 0; i--)
        {
            Destroy(instance.buttons[i]);
        }
        instance.buttons.Clear();
        foreach (Objeto obj in robable.objetos)
        {
            GameObject g = Instantiate(instance.SellingItemButtonPrefab, instance.sellContent);
            instance.buttons.Add(g);
            SellingItem si = g.GetComponent<SellingItem>();
            si.objectImage.sprite = obj.image;
            si.nombre.text = obj.name;
            si.objetoALaVenta = obj;
            si.precio.text = obj.buyPrice.ToString() + " EUR";
        }
        instance.precioInventario.text = GameManager.Instance.ShowPriceSellAllInventory().ToString();
    }

    public static void HideBuySellInventory()
    {
        instance.gameObject.SetActive(false);
    }

    public void SellAllInventory()
    {
        GameManager.Instance.currentMoney += GameManager.Instance.SellAllItems();
        precioInventario.text = GameManager.Instance.ShowPriceSellAllInventory().ToString();
        //TODO maybe reduce actions
    }
}
