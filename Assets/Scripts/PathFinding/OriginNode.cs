using Hedenrag.ExVar;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

public class OriginNode : MonoBehaviour
{
    static List<OriginNode> originNodes = new List<OriginNode>();
    int myId;
    //TODO add npc pool scriptable singleton

    static Optional<OriginCreator> og = new(null, false);

    [SerializeField] GameObject testPrefab;

    private void Awake()
    {
        myId = originNodes.Count;
        originNodes.Add(this);

        if(!og) og = new(new(), true);
    }

    public void CreateNPC()
    {
        GameObject g = Instantiate(testPrefab);
        NavMeshAgent agent = g.GetComponent<NavMeshAgent>();
        int index = Random.Range(0, originNodes.Count-2);
        if (index >= myId)
        {
            index++;
        }
        agent.SetDestination(originNodes[index].transform.position);
    }

    void OnDestroy()
    {
        originNodes.Remove(this);
        for(int i = myId; i < originNodes.Count(); i++)
        {
            originNodes[i].myId--;
        }
    }


    class OriginCreator
    {
        Timer timer;

        public OriginCreator()
        {
            Create();
        }

        void Create()
        {
            timer = new Timer();
            timer.Interval = 2500;
            timer.Start();
            timer.Elapsed += UpdateLoop;
        }

        private void UpdateLoop(object sender, ElapsedEventArgs e)
        {
            if(BaseAgent.ActiveAgents < BaseAgent.maxAgentsPool)
            {
                originNodes[Random.Range(0, originNodes.Count-1)].CreateNPC();
            }
            Create();
        }
    }
}
