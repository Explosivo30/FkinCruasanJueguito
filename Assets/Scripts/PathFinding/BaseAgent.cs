using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAgent : MonoBehaviour
{
    NavMeshAgent mNavMeshAgent;

    public static int ActiveAgents => agentPool;
    static int agentPool = 0;
    public const int maxAgentsPool = 20;
    // Start is called before the first frame update
    void Awake()
    {
        agentPool++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mNavMeshAgent.pathPending)
        {
            if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
            {
                Destroy(gameObject);
                agentPool--;
            }
        }
    }
}
