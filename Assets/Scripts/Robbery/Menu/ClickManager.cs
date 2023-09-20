using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;

public class ClickManager : MonoBehaviour
{
    public static Optional<ClickManager> instance = new Optional<ClickManager>(null, false);

    [SerializeField] GameObject[] options;

#if UNITY_EDITOR
    [SerializeField] ExtraLayers layersInfo;
#endif

    private void Awake()
    {
        if (instance.Value != null) Destroy(gameObject);
        else
        {
            instance = new Optional<ClickManager>(this);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    Robable robable;

    public void SetOptions(Robable sr)
    {
        robable = sr;
        gameObject.SetActive (true);
        transform.position = Input.mousePosition;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(sr.posibilidades[i]);
        }
    }

    #region

    public void Investigar()
    {
        string[] infoRobable = robable.Investigar();
        ListManager.instance.SetList(infoRobable);
    }

    public void Hurtar()
    {
        MenuDeHurto.instance.CreateMenu(robable);
        gameObject.SetActive(false);
    }

    public void Atracar()
    {

    }

    #endregion
}
