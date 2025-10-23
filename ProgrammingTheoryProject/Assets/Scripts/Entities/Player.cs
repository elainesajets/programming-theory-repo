
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private RaycastHit m_HitInfo = new RaycastHit();
    private Animator m_Animator;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Target clicked");
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                m_Agent.destination = m_HitInfo.point;
        }

        if (m_Agent.velocity.magnitude != 0f)
        {
            m_Animator.SetBool("Walking", true);
        }
        else
        {
            m_Animator.SetBool("Walking", false);
        }
    }
}