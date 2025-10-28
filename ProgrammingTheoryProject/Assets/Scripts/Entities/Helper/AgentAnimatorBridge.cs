using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class AgentAnimatorBridge : MonoBehaviour
{
    public string speedParam = "Vert";   // float
    public string stateParam = "State";  // int (0 idle, 1 walk, 2 run)

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

        int state = 0; // idle
        if (s > runThreshold) state = 2;
        else if (s > walkThreshold) state = 1;
        anim.SetInteger(stateParam, state);
    }
}