using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class Search : MonoBehaviour
{
    private NavMeshAgent agent;
    private BearAI bearAI;

    [HideInInspector]
    public bool arrivedAtNoise = false;
    [HideInInspector]
    public Transform roomTransform;

    public float minWaitTime = 5f;
    public float maxWaitTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bearAI = GetComponent<BearAI>();
    }

    public void BeginSearch(Transform transform, Vector3 position)
    {
        position.y = position.y < 3.2f ? 1.5f : 4.5f;

        agent.destination = position;
        roomTransform = transform;

        bearAI.Invoke("SelectNewDestination", Random.Range(minWaitTime, maxWaitTime));
    }

    public void NewSearchDestination()
    {
        Vector3 roomCenter = roomTransform.position;
        Vector3 randXOffset = new Vector3(Random.Range(-3f, 3f), 0, 0);
        Vector3 randZOffset = new Vector3(0, 0, Random.Range(-3f, 3f));

        agent.destination = (roomCenter + randXOffset + randZOffset);
        bearAI.Invoke("SelectNewDestination", Random.Range(minWaitTime, maxWaitTime));
    }
}
