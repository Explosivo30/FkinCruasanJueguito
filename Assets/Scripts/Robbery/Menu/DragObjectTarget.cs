using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObjectTarget : MonoBehaviour, IDropHandler
{
    protected virtual bool OnDropRequirements(PointerEventData eventData)
    {
        return true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropRequirements(eventData))
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}
