using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Image image;

    private void Awake()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (var item in images)
        {
            item.raycastTarget = false;
        }
        image = GetComponent<Image>();
        image.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
