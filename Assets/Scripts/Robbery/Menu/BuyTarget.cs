using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyTarget : DragObjectTarget
{
    static BuyTarget instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        HideBuySellInventory();
    }

    [SerializeField] private GameObject SellingItemButtonPrefab;
    [SerializeField] Transform sellContent;


    protected override bool OnDropRequirements(PointerEventData eventData)
    {
        SellingItem item = eventData.pointerDrag.GetComponent<SellingItem>();
        if(item == null) { return false; }
        if(GameManager.Instance.currentMoney < item.objetoALaVenta.buyPrice) { return false; }
        GameManager.Instance.QuitarDinero(item.objetoALaVenta.buyPrice);
        GameManager.Instance.AddToBag(item.objetoALaVenta);
        //TODO reload seller
        return true;
    }

    List<GameObject> buttons = new(); 
    public static void ShowBuySellInventory(Robable robable)
    {
        if (instance == null)
        {
            Debug.Log("no sellInventory");
            return;
        }
        for (int i = instance.buttons.Count; i >= 0; i--)
        {
            Destroy(instance.buttons[i]);
        }
        instance.buttons.Clear();
        foreach(Objeto obj in robable.objetos)
        {
            GameObject g = Instantiate(instance.SellingItemButtonPrefab, instance.sellContent);
            SellingItem si = g.GetComponent<SellingItem>();
            si.objectImage.sprite = obj.image;
            si.nombre.text = obj.name;
            si.objetoALaVenta = obj;
            si.precio.text = obj.buyPrice.ToString() + " EUR";
        }
    }

    public static void HideBuySellInventory()
    {
        instance.gameObject.SetActive(false);
    }
}
