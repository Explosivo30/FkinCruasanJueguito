using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeHurto : MonoBehaviour
{
    public static MenuDeHurto instance;
    [SerializeField] GameObject hurtableButtonPrefab;
    [SerializeField] Transform content;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    List<GameObject> buttons = new List<GameObject>();

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void CreateMenu(Robable robable)
    {
        foreach(GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
        foreach(Objeto obj in robable.objetos)
        {
            GameObject g = Instantiate(hurtableButtonPrefab, content);
            buttons.Add(g);
            HurtableButton hB = g.GetComponent<HurtableButton>();
            hB.SetButton(obj, robable);
        }
        gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false );
    }
}
