using UnityEngine;
using UnityEngine.AI;

public class BeaverWood : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform targetWood;
    public string woodTag = "Wood";
    public float searchRadius = 20f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindClosestWood();
    }

    void Update()
    {
        if (targetWood == null)
        {
            FindClosestWood();
            return;
        }
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
            }
        }
    }

    void FindClosestWood()
    {
        GameObject[] woodObjects = GameObject.FindGameObjectsWithTag(woodTag);
        float shortestDistance = Mathf.Infinity;
        Transform closestWood = null;

        foreach (GameObject wood in woodObjects)
        {
            float distance = Vector3.Distance(transform.position, wood.transform.position);
            if (distance < shortestDistance && distance <= searchRadius)
            {
                shortestDistance = distance;
                closestWood = wood.transform;
            }
        }

        if (closestWood != null)
        {
            targetWood = closestWood;
            agent.SetDestination(targetWood.position);
        }
    }
}