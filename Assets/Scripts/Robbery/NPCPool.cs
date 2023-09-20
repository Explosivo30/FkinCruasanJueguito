using Hedenrag.ExVar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPool : SingletonScriptableObject<NPCPool>, ICallOnAll
{
    [SerializeField] List<NPCItemsPool> pool;

    public GameObject CreateNPC(Transform parent)
    {
        return pool[Random.Range(0, pool.Count - 1)].GetNPC(parent);
    }
}
