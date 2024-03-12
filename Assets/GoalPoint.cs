using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> target;
    [SerializeField] private int distanceToTargetPoint;

    public bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoppingSimulation());
    }

    IEnumerator shoppingSimulation()
    {
        if (target.Count > 0)
        {
            agent.SetDestination(target[0].position);
            walking = true;

            for (int i = 0; i < target.Count; i++)
            {
                Debug.Log("LOOP " + i);
                if (Vector3.Distance(agent.transform.position, target[i].position) < distanceToTargetPoint)
                {
                    Debug.Log("IF" + i);
                    walking = false;
                    yield return new WaitForSeconds(5);
                    agent.SetDestination(target[i + 1].position);
                    walking = true;
                }
            }
        }
    }
}
