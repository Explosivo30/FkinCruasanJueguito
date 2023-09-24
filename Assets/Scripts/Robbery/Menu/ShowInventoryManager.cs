using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;
using System.Linq;

public class ShowInventoryManager : MonoBehaviour
{

    static Optional<ShowInventoryManager> instance = new Optional<ShowInventoryManager>(null, false); 

    [SerializeField] Transform content;

    List<GameObject> ContextItems = new();

    List<Objeto> usados = new List<Objeto>();

    [SerializeField]GameObject buttonPrefab;

    private void Awake()
    {
        if(!instance)
        {
            instance = new(this);
        }
        else
        {
            Destroy(gameObject);
        }
        HideInventory();
    }

    public static void ShowInventory()
    {
        if (!instance) { return; }
        HideInventory();
        instance.Value.gameObject.SetActive(true);
        List<Objeto> objetosUtiles = GameManager.Instance.DevolverObjeto();

        foreach(Objeto obj in objetosUtiles)
        {
            instance.Value.ContextItems.Add(Instantiate(instance.Value.buttonPrefab, instance.Value.content));
            InventoryButton inveButt = instance.Value.ContextItems.Last().GetComponent<InventoryButton>();
            Debug.Log("Objeto instanciado", inveButt);
            inveButt.objeto = obj;
            inveButt.sprite.sprite = obj.image;
            inveButt.nombre.text = obj.name;
            inveButt.peso.text = obj.peso.ToString() + " Kg";
            inveButt.precio.text = obj.sellPrice.ToString() + " EUR";
        }
    }

    public static void HideInventory()
    {
        if (!instance) { return; }
        if(instance.Value.ContextItems != null)
        {
            foreach (var obj in instance.Value.ContextItems)
            {
                Destroy(obj);
            }
            instance.Value.ContextItems.Clear();
        }
       
        instance.Value.gameObject.SetActive(false);
    }

    public static void ShowAllInventoryHUD()
    {
        if (!instance) { return; }
        HideInventory();
        instance.Value.gameObject.SetActive(true);
        List<Objeto> objetosUtiles = GameManager.Instance.AllInventoryReturned();

        foreach (Objeto obj in objetosUtiles)
        {
            instance.Value.ContextItems.Add(Instantiate(instance.Value.buttonPrefab, instance.Value.content));
            InventoryButton inveButt = instance.Value.ContextItems.Last().GetComponent<InventoryButton>();
            Debug.Log("Objeto instanciado", inveButt);
            inveButt.objeto = obj;
            inveButt.sprite.sprite = obj.image;
            inveButt.nombre.text = obj.name;
            inveButt.peso.text = obj.peso.ToString() + " Kg";
            inveButt.precio.text = obj.sellPrice.ToString() + " EUR";
        }
    }

}
