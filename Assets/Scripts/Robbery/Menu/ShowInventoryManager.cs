using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;
using System.Linq;

public class ShowInventoryManager : MonoBehaviour
{

    static Optional<ShowInventoryManager> instance = new Optional<ShowInventoryManager>(null, false); 

    [SerializeField] Transform content;

    List<GameObject> ContextItems;

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
    }

    public static void ShowInventory()
    {
        if (!instance) { return; }
        List<Objeto> objetosUtiles = GameManager.Instance.DevolverObjeto(); //TODO inventory.GetAllUsefullItems

        foreach(Objeto obj in objetosUtiles)
        {
            instance.Value.ContextItems.Add(Instantiate(instance.Value.buttonPrefab, instance.Value.content));
            InventoryButton inveButt = instance.Value.ContextItems.Last().GetComponent<InventoryButton>();
            inveButt.objeto = obj;
            inveButt.sprite.sprite = obj.image;
            inveButt.nombre.text = obj.name;
            inveButt.peso.text = obj.peso.ToString() + " Kg";
            inveButt.precio.text = obj.sellPrice.ToString() + " EUR";
        }
    }


}
