using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAgent : MonoBehaviour
{
    NavMeshAgent mNavMeshAgent;

    public static int ActiveAgents => agentPool;
    static int agentPool = 0;
    public const int maxAgentsPool = 40;
    // Start is called before the first frame update
    void Awake()
    {
        agentPool++;
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            Destroy(gameObject);
            agentPool--;
        }
    }
}
