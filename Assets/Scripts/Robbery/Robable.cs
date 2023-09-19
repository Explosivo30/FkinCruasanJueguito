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
    
    public void CreateSelection()
    {
        ClickManager.instance.Value.SetOptions(this);
    }
}
