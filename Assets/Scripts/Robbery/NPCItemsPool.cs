using Hedenrag.ExVar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new NPC Items Pool", menuName = "Scriptable Objects/Robbery Game/new NPC ItemsPool")]
public class NPCItemsPool : ScriptableObject
{
    [SerializeField] List<string> nombres = new List<string>();

    [SerializeField] RangeIntValue numeroDeObjetos;
    [SerializeField] List<Objeto> poolDeObjetos = new List<Objeto>();
    [Space(5f)]
    [SerializeField] RangeIntValue numeroDePeligros;
    [SerializeField] List<Peligro> poolDePeligros = new List<Peligro>();
    [Space(10f)]
    [SerializeField] List<GameObject> charactersPrefabs;

    public GameObject GetNPC(Transform parent)
    {
        GameObject g = Instantiate(charactersPrefabs[Random.Range(0, charactersPrefabs.Count - 1)], parent);
        Robable rob = g.GetComponent<Robable>();
        rob.objetos = GetObjects();
        rob.peligros = GetPeligros();
        if(string.IsNullOrWhiteSpace(rob.nombre))
            rob.nombre = nombres[Random.Range(0, nombres.Count-1)];
        return g;
    }

    List<Objeto> GetObjects()
    {
        int num = numeroDeObjetos.possibleValue;
        List<Objeto> list = new List<Objeto>();
        for (int i = 0; i < num; i++)
        {
            list.Add(poolDeObjetos[Random.Range(0, poolDeObjetos.Count - 1)]);
        }
        return list;
    }

    List<Peligro> GetPeligros()
    {
        int num = numeroDePeligros.possibleValue;
        List<Peligro> list = new List<Peligro>();
        for (int i = 0; i < num; i++)
        {
            list.Add(poolDePeligros[Random.Range(0, poolDePeligros.Count - 1)]);
        }
        return list;
    }
}
