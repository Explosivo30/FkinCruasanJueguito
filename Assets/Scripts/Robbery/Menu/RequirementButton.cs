using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RequirementButton : DragObjectTarget
{
    [SerializeField] GameObject requirementButton;
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
                return true;
            }
        }
        return false;
    }
}
