using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;
using Unity.VisualScripting;
using System.Runtime.Remoting.Messaging;

public class Robable : MonoBehaviour
{
    public List<Requerimiento> requerimientos;
    public List<Objeto> objetos;

    public ExtraLayers posibilidades;

    Optional<List<string>> infoList;
    [SerializeField] ExtraLayer investigateLayer;

    private void Awake()
    {
        investigateLayer = new ExtraLayer(posibilidades.Layer, 1);
    }
    public void CreateSelection()
    {
        if(infoList)
        ClickManager.instance.Value.SetOptions(this);
    }
}
