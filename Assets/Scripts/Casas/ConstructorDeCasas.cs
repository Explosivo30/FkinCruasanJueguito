using Hedenrag.ExVar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorDeCasas : SingletonScriptableObject<ConstructorDeCasas>, ICallOnAll
{
    public GameObject[] muebles;
}

[System.Serializable]
public class Constructor 
{ 
    public enum Tamaño { Pequeño = 0, Grande = 1 }
    [SerializeField] List<MuebleEstructura> muebles;


    [System.Serializable]
    public class MuebleEstructura
    {
        public GameMueble mueble;
        public MuebleEstructura[] subMueblesGrandes;
        public MuebleEstructura[] subMueblesPequeños;
    }
}