using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellTarget : DragObjectTarget
{
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

    public void SellAllUnusefullItems()
    {
        GameManager.Instance.SellAllItems();
        //TODO maybe reduce actions
    }


}
