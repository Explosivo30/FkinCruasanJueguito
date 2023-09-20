using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;

[CreateAssetMenu(fileName = "NombreObjeto", menuName = "Scriptable Objects/Robbery Game/New Object")]
public class Objeto : ScriptableObject
{
    public Sprite image;
    public int buyPrice;
    public int sellPrice;
    public Optional<List<Requerimiento>> capacidades;
    [Range(0f, 100f)] public float ruido;
    [Range(0f, 100f)] public float probabilidadDeAlarma;
    [Range(0f, 100f)] public float probabilidadDeRobar;
}
