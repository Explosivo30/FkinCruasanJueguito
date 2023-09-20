using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;
using Unity.VisualScripting;
using System.Runtime.Remoting.Messaging;

public class Robable : MonoBehaviour
{
    public string nombre;

    public List<Requerimiento> requerimientos;
    public List<Objeto> objetos;
    public List<Delito> delitos;
    public List<Peligro> peligros;

    public ExtraLayers posibilidades;

    Optional<List<string>> infoList = new(null, false);
    [SerializeField] ExtraLayer investigateLayer;

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

    void Robar()
    {
        //Cargar escena de casa
    }

    void Atracar()
    {

    }

    public void MostrarInfo()
    {
        if (infoList)
            ListManager.instance.SetList(infoList.Value.ToArray());
    }
    public void OcultarInfo()
    {
        ListManager.instance.gameObject.SetActive(false);
    }
}
