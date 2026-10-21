using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetMoverV2 : MonoBehaviour
{
    [SerializeField] private float roamRadius = 10f;
    [SerializeField] private float speed = 3.5f;

    private NavMeshAgent agent;
    private NavMeshPath path;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    void Update()
    {
        agent.speed = speed;
        if (!agent.isOnNavMesh || agent.pathPending)
            return;

        // Keep moving until close enough to the destination.
        if (agent.hasPath &&
            agent.remainingDistance > agent.stoppingDistance + 0.2f)
            return;

        Vector2 offset = Random.insideUnitCircle * roamRadius;
        Vector3 point = transform.position +
                        new Vector3(offset.x, 0f, offset.y);

        // Find a nearby NavMesh point and ensure we can reach it.
        if (NavMesh.SamplePosition(point, out NavMeshHit hit, 2f, agent.areaMask) &&
            agent.CalculatePath(hit.position, path) &&
            path.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetPath(path);
        }
    }
}