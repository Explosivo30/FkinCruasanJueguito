using Hedenrag.ExVar;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementManager : MonoBehaviour
{
    static RequirementManager instance;

    [SerializeField] GameObject buttonPrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    Optional<Robable> target = new(null, false);
    Action onFinishAction;

    List<RequirementButton> buttons = new List<RequirementButton>();

    public static void ShowMenuToDoStuff(Robable robable, Action OnRemoveRequirements)
    {
        instance.target = new(robable);
        instance.onFinishAction = OnRemoveRequirements;

        foreach (Requerimiento req in robable.requerimientos)
        {
            GameObject g = Instantiate(instance.buttonPrefab, instance.transform);
            RequirementButton button = g.GetComponent<RequirementButton>();
            instance.buttons.Add(button);
            button.nombre.text = req.nombre;
            button.requerimiento = req;
            button.requirementButtonImage.sprite = req.imagen;
            button.target = robable;
        }
    }
    public static void HideRequirements()
    {
        instance.HideMenu();
    }

    public void HideMenu()
    {
        target = new(null, false);
        foreach (RequirementButton button in buttons)
        {
            Destroy(button.gameObject);
        }
        buttons.Clear();
    }

    private void Update()
    {
        if (target)
        {
            for (int i = buttons.Count-1; i >= 0; i--)
            {
                if (buttons[i] == null)
                    buttons.Remove(buttons[i]);
            }
            if (buttons.Count == 0)
            {
                onFinishAction.Invoke();
                target = new(null, false);
            }
        }
    }
}
