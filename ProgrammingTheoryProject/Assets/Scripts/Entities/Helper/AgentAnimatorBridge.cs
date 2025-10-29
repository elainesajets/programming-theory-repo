using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class AgentAnimatorBridge : MonoBehaviour
{
    public string speedParam = "Vert";   // float

    public float walkThreshold = 0.1f;
    public float runThreshold = 2.5f;

    Animator anim;
    NavMeshAgent agent;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float s = agent.velocity.magnitude;
        anim.SetFloat(speedParam, s);
    }
}