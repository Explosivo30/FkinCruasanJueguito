using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RequirementButton : DragObjectTarget
{
    [SerializeField] GameObject requirementButton;
    [SerializeField] public Image requirementButtonImage;
    [SerializeField] public TMPro.TextMeshProUGUI nombre;
    [HideInInspector] public Requerimiento requerimiento;
    [HideInInspector] public Robable target;

    protected override bool OnDropRequirements(PointerEventData eventData)
    {
        InventoryButton inventoryButton = eventData.pointerDrag.GetComponent<InventoryButton>();
        if(inventoryButton == null) return false;
        //TODO añadir ruido y alarma por peligro
        if (inventoryButton.objeto.capacidades)
        {
            if (inventoryButton.objeto.capacidades.Value.Contains(requerimiento))
            {
                target.requerimientos.Remove(requerimiento);
                Destroy(requirementButton);
                //TODO remove item from inventory
                return true;
            }
        }
        return false;
    }
}
