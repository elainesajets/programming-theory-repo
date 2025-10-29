// Abstraction + Inheritance
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Animal : MonoBehaviour
{

    [Header("Wander settings")]
    [SerializeField] private float wanderRadius = 8f;
    [SerializeField] private Vector2 idleTimeRange = new Vector2(1.0f, 3.0f);
    [SerializeField] private float repathCheckInterval = 0.25f;

    private NavMeshAgent _agent;
    private Coroutine _wanderRoutine;
    //TODO Add audio files for each animal
    // [SerializeField] protected AudioSource audioSource;
    // [SerializeField] protected AudioClip soundClip;

    //Polymorphism
    protected abstract void MakeSound();
    protected virtual void Interact() { MakeSound(); }

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        // Randomize behavior parameters so each animal moves differently
        wanderRadius += Random.Range(-2f, 2f);
        idleTimeRange.x += Random.Range(-0.5f, 0.5f);
        idleTimeRange.y += Random.Range(-0.5f, 0.5f);
        _agent.speed += Random.Range(-0.5f, 1.0f);

        if (TryGetRandomPoint(transform.position, wanderRadius, out Vector3 randomPos))
        {
            // Instantly move the agent to that position
            _agent.Warp(randomPos);
        }
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        // Don’t click through UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Try to hit an Animal first
        int animalMask = LayerMask.GetMask("Animal");
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, animalMask))
        {
            var animal = hit.collider.GetComponentInParent<Animal>();
            if (animal != null)
            {
                Debug.Log($"Hit: {hit.collider.name} (layer {LayerMask.LayerToName(hit.collider.gameObject.layer)})");
                animal.OnAnimalClicked();
            }
            return;
        }

        // Clicked somewhere that is NOT an animal (or hit nothing): hide the panel
        var mainGameUIHandler = MainGameUIHandler.Instance;
        if (mainGameUIHandler != null) mainGameUIHandler.HideInfoPanelIfActive();
    }

    protected abstract void OnAnimalClicked(); //Polymorphism

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
            random.y = center.y;
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
