using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;

public class Peligro : ScriptableObject
{
    public enum FacilidadEscape{ escapeLibre, escapeSinObjetos, NoHayEscape}

    [SerializeField] Optional<string> textoInfoRequerimiento;
    public string info => ("• " + textoInfoRequerimiento);

    [Range(0f, 100f)] public float ruidoParaAlarma;
    public FacilidadEscape facilidadEscape;

}
