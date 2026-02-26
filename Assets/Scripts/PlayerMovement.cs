using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent PlayerAgent => GetComponent<NavMeshAgent>();

    private Animator PlayerAnimator => GetComponent<Animator>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimator.SetFloat("Speed", PlayerAgent.velocity.magnitude);

        if (Mouse.current.rightButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                PlayerAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
