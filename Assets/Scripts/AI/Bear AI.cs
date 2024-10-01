using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BearAI : MonoBehaviour
{
    private Wander wander;
    private Search search;
    private Animator animator;
    private NavMeshAgent agent;

    private AIState state = AIState.Wander;
    public float searchTime = 30f;
    private float searchTimer;

    public bool arrivedAtDest = true;

    private enum AIState
    {
        Wander,
        Search
    }

    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<Wander>();
        search = GetComponent<Search>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        SelectNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Bear animation
        if (agent.remainingDistance != 0)
        {
            switch (state)
            {
                case AIState.Wander:
                    animator.Play("Walk");
                    break;
                case AIState.Search:
                    animator.Play("Run");
                    break;
                default:
                    break;
            }
        }
        else
        {
            arrivedAtDest = true;
            animator.Play("None");
        }

        // Search state timer
        if (state == AIState.Search)
        {
            searchTimer += Time.deltaTime;
            if (searchTimer >= searchTime)
            {
                state = AIState.Wander;
                agent.speed = 3;
            }
        }
    }

    public void SelectNewDestination()
    {
        if (arrivedAtDest)
        {
            switch (state)
            {
                case AIState.Wander:
                    wander.NewWanderDestination();
                    break;
                case AIState.Search:
                    search.NewSearchDestination();
                    break;
                default:
                    break;
            }

            arrivedAtDest = false;
        }
        else
        {
            Debug.Log(name + " has not yet reached its destination");
            Invoke("SelectNewDestination", 5f);
        }
    }

    public void NoiseHeard(Transform transform, Vector3 position)
    {
        state = AIState.Search;
        agent.speed = 8;
        search.BeginSearch(transform, position);
        searchTimer = 0f;
    }
}
