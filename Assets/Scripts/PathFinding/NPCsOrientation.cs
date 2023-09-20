using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCsOrientation : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] bool ogLooksRight = false;
    private void Update()
    {
        float dir = ogLooksRight ? -1f : 1f;
        if(agent.desiredVelocity.x*dir > 0f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
