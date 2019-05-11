using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentController : MonoBehaviour {

    #region
    public NavMeshAgent agent;
    public GameObject playerObj;
    public Vector3 randomVector3;
    public Transform targetLocation;
    public int walkRadius;
    private NavMeshHit navHit;
    #endregion
    
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        FindTarget();
    }

    private void Update()
    {
        if (Vector3.Distance(playerObj.transform.position, agent.transform.position) < 7.5f)
        {
            agent.speed = 5f;
        }
        else
        {
            agent.speed = 3.5f;
        }
    }

    public void FindTarget()
    {
        StopAllCoroutines();
        StartCoroutine(FindTargetPoint());
    }

    void StopInvoke()
    {
        CancelInvoke();
    }

    public IEnumerator FindTargetPoint()
    {
        //to find a random point on the navigation mesh around the player
        walkRadius = Random.Range(20, 75);
        randomVector3 = Random.insideUnitSphere * walkRadius;
        randomVector3 += playerObj.transform.position;
        NavMesh.SamplePosition(randomVector3, out navHit, walkRadius, 1);

        if (Vector3.Distance(playerObj.transform.position, navHit.position) < 13f)
        {
            FindTarget();
        }

        agent.SetDestination(navHit.position);

        yield return new WaitForSeconds(5);

        FindTarget();
    }
}
