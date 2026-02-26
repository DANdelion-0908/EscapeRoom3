using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyManager : MonoBehaviour
{
    [Tooltip("List of waypoints for the enemy to follow")]
    [SerializeField] private List<Transform> waypoints;

    [Tooltip("Enemy animator")]
    [SerializeField] Animator enemyAnimator;

    private enum EnemyState { Idle, Patrol, Chase, Attack }
    private readonly EnemyState CurrentState = EnemyState.Patrol;

    private NavMeshAgent EnemyAgent => GetComponent<NavMeshAgent>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.SetFloat("Speed", EnemyAgent.velocity.magnitude);

        switch (CurrentState)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Patrol:
                Patrol();
                break;

            case EnemyState.Chase:
                Chase();
                break;
        }
    }

    private void Idle()
    {
        Debug.Log("Enemy is idle.");
    }

    private void Patrol()
    {
        Debug.Log("Enemy is patrolling.");
        EnemyAgent.SetDestination(waypoints[0].position);
    }

    private void Chase()
    {
        Debug.Log("Enemy is chasing the player.");
        EnemyAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
