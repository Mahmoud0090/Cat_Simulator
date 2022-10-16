using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayer : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float radius = 10f;
    public Animator catAnim;
    public int score = 0;
    public GameManager gm;


    public void StartGame()
    {
        navMeshAgent.destination = RandomNavMeshLocation(radius);
        catAnim.SetBool("canWalk", true);
        InvokeRepeating("ChangeDestination", Random.Range(8, 12), Random.Range(8, 12));
    }

    public Vector3 RandomNavMeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if(NavMesh.SamplePosition(randomDirection , out hit , radius , 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void ChangeDestination()
    {
        navMeshAgent.destination = RandomNavMeshLocation(radius);
    }

    void Update()
    {
        if(gm.gameStarted && navMeshAgent.remainingDistance < 1.5f)
        {
            ChangeDestination();
        }
    }
}
