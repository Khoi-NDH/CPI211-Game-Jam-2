using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public List<GameObject> rooms = new();
    private Animator animator;
    private NavMeshAgent agent;

    public float minWaitTime = 10f;
    public float maxWaitTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SelectNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance != 0)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("None");
        }
    }

    void SelectNewDestination()
    {
        var room = rooms[Random.Range(0, rooms.Count)];
        var randX = room.transform.position.x + Random.Range(-3f, 3f);
        var randZ = room.transform.position.x + Random.Range(-3f, 3f);

        agent.destination = new Vector3(randX, room.transform.position.y, randZ);
        Invoke("SelectNewDestination", Random.Range(minWaitTime, maxWaitTime));
    }
}
