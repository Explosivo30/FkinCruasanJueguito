using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NombreRequerimiento", menuName = "Scriptable Objects/Robbery Game/New Requirement")]
public class Requerimiento : ScriptableObject
{
    public Sprite imagen;
    public string nombre;

    [SerializeField] string textoInfoRequerimiento;
    public string info => ("• " + textoInfoRequerimiento);
}
