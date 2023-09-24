using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;

public class BuyTarget : DragObjectTarget
{
    

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

    
}
