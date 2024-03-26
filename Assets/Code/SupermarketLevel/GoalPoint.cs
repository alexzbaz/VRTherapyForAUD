using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> targets;
    [SerializeField] private float distanceToTargetPoint;
    private int targetCounter = -1;
    private bool targetReached = false;
    public bool walking = false;
    private int waitSeconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (targets.Count > 0)
        {
            if (targetReached == false)
            {
                StartCoroutine(Bot());
            }
        }
    }

    private IEnumerator Bot()
    {
        if (targetCounter == -1)
        {
            targetCounter++;
            agent.SetDestination(targets[targetCounter].position);
            walking = true;
        }

        if (Vector3.Distance(agent.transform.position, targets[targetCounter].position) < distanceToTargetPoint)
        {
            targetReached = true;
            walking = false;
            waitSeconds = Random.Range(1, 11);
            Debug.Log("Wait Seconds Random: " + waitSeconds);
            yield return new WaitForSeconds(waitSeconds);
            walking = true;
            targetReached = false;
            targetCounter++;
            if (targetCounter < targets.Count)
            {
                agent.SetDestination(targets[targetCounter].position);
            }
            else
            {
                targetReached = true;
                walking = false;
            }
        }
        
    }
}
