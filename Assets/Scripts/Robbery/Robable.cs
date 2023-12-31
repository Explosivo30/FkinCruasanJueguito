using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;
using Unity.VisualScripting;
using System;
//using System.Runtime.Remoting.Messaging;

public class Robable : MonoBehaviour
{
    public string nombre;

    public List<Requerimiento> requerimientos;
    public List<Objeto> objetos;
    public Edificio edificio;
    public List<Delito> delitos;
    public List<Peligro> peligros;

    public ExtraLayers posibilidades;

    [NonSerialized] public bool entered = false;

    Optional<List<string>> infoList = new(null, false);
    [SerializeField] ExtraLayer investigateLayer;

    //Investigar
    //Hurto
    //Entrar
    //Atraco
    //Hablar

    private void Awake()
    {
        if(investigateLayer == default(ExtraLayer))
        investigateLayer = new ExtraLayer(posibilidades.Layer, 1);
    }
    public void CreateSelection()
    {
        if (infoList)
        {
            posibilidades -= investigateLayer;
        }
        ClickManager.instance.Value.SetOptions(this);
    }

    public string[] Investigar()
    {
        infoList = new(new(), true);
        foreach (Requerimiento requerimiento in requerimientos)
        {
            infoList.Value.Add(requerimiento.info);
        }
        foreach (Peligro peligro in peligros)
        {
            infoList.Value.Add(peligro.info);
        }

        return infoList.Value.ToArray();
    }

    public void MostrarInfo()
    {
        return;
        if (infoList)
            ListManager.instance.SetList(infoList.Value.ToArray());
    }
    public void OcultarInfo()
    {
        return;
        ListManager.instance.gameObject.SetActive(false);
    }
}
