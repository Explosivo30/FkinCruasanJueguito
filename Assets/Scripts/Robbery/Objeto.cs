using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hedenrag.ExVar;

[CreateAssetMenu(fileName = "NombreObjeto", menuName = "Scriptable Objects/Robbery Game/New Object")]
public class Objeto : ScriptableObject
{
    public Texture2D image;
    public int buyPrice;
    public int sellPrice;
    public Optional<List<Requerimiento>> capacidades;
}
