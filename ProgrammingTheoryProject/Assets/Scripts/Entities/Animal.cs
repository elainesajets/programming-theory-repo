// Abstraction + Inheritance
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Animal : MonoBehaviour
{
    //Encapsulation
    private string _name;
    protected string Name => _name;

    [Header("Wander settings")]
    [SerializeField] private float wanderRadius = 8f;
    [SerializeField] private Vector2 idleTimeRange = new Vector2(1.0f, 3.0f);
    [SerializeField] private float repathCheckInterval = 0.25f;

    private NavMeshAgent _agent;
    private Coroutine _wanderRoutine;
    // [SerializeField] protected AudioSource audioSource;
    // [SerializeField] protected AudioClip soundClip;

    //Polymorphism
    protected abstract void MakeSound();
    protected virtual void Interact() { MakeSound(); }

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        Move();
    }

    protected void Move()
    {
        if (NavMesh.SamplePosition(transform.position, out var hit, 2f, NavMesh.AllAreas))
            _agent.Warp(hit.position);

        if (_wanderRoutine == null)
            _wanderRoutine = StartCoroutine(WanderRoutine());
    }

    public void StopWandering()
    {
        if (_wanderRoutine != null)
        {
            StopCoroutine(_wanderRoutine);
            _wanderRoutine = null;
        }
        if (_agent != null)
            _agent.ResetPath();
    }


    private System.Collections.IEnumerator WanderRoutine()
    {
        while (true)
        {
            // Pause idly for a random duration
            float wait = Random.Range(idleTimeRange.x, idleTimeRange.y);
            yield return new WaitForSeconds(wait);

            // Pick a random reachable point on the NavMesh within radius
            if (TryGetRandomPoint(transform.position, wanderRadius, out Vector3 dest))
            {
                _agent.SetDestination(dest);
            }

            // Wait until we arrive or the path is done
            while (_agent.pathPending)
                yield return null;

            while (_agent.remainingDistance > _agent.stoppingDistance)
                yield return new WaitForSeconds(repathCheckInterval);
        }
    }

    private bool TryGetRandomPoint(Vector3 center, float radius, out Vector3 result)
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 random = center + Random.insideUnitSphere * radius;
            random.y = center.y; // keep level with current plane
            if (NavMesh.SamplePosition(random, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = center;
        return false;
    }


}