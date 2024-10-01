using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class Search : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance != 0)
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("None");
        }
    }

    public void BeginSearch(Vector3 position)
    {
        agent.destination = position;
    }
}
