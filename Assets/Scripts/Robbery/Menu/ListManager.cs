using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    public static ListManager instance;

    [SerializeField] Transform content;
    [SerializeField] GameObject listItemPrefab;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    List<GameObject> items = new();

    public void SetList(string[] list)
    {
        foreach (GameObject item in items)
        {
            Destroy(item);
        }
        items.Clear();
        foreach (string item in list)
        {
            GameObject g = Instantiate(listItemPrefab, content);
            items.Add(g);
            g.GetComponent<TextMeshProUGUI>().text = item;
        }
        gameObject.SetActive (true);
    }
}
