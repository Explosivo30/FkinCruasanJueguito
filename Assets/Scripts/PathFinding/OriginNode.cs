using Hedenrag.ExVar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OriginNode : MonoBehaviour
{
    static List<OriginNode> originNodes = new List<OriginNode>();
    int myId;

    const float spawnRate = 0.2f;

    static bool og = false;

    private void Awake()
    {
        myId = originNodes.Count;
        originNodes.Add(this);

        if (!og)
        {
            CoroutineWait.DoAfterSeconds(action: RepeatInvokeCreateNPCs, time: spawnRate);
            og = true;
        }
    }
    static void RepeatInvokeCreateNPCs()
    {
        CreateNPC();
        CoroutineWait.DoAfterSeconds(action: RepeatInvokeCreateNPCs, time: spawnRate);
    }

    public static void CreateNPC()
    {
        int ogIndex = Random.Range(0, originNodes.Count - 1);
        GameObject g = NPCPool.Instance.CreateNPC(originNodes[ogIndex].transform);
        g.transform.parent = null;
        NavMeshAgent agent = g.GetComponent<NavMeshAgent>();

        int destIndex = Random.Range(0, originNodes.Count - 2);
        if (destIndex >= ogIndex) destIndex++;

        agent.SetDestination(originNodes[destIndex].transform.position);
    }

    void OnDestroy()
    {
        originNodes.Remove(this);
        for(int i = myId; i < originNodes.Count; i++)
        {
            originNodes[i].myId--;
        }
    }


}
