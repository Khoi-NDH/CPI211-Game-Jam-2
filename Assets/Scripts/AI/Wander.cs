using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public List<GameObject> rooms = new();
    private BearAI bearAI;
    private NavMeshAgent agent;

    public float minWaitTime = 10f;
    public float maxWaitTime = 20f;

    public bool debugOverrideRoomChoice = false;
    public NumberOf debugRoom = NumberOf.RoomTrigger1;
    
    public enum NumberOf
    {
        RoomTrigger1,
        RoomTrigger2,
        RoomTrigger3,
        RoomTrigger4,
        RoomTrigger6,
        RoomTriggerUp1,
        RoomTriggerUp2,
        RoomTriggerUp3
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bearAI = GetComponent<BearAI>();
    }

    public void NewWanderDestination()
    {
        var room = rooms[Random.Range(0, rooms.Count)];

        if (debugOverrideRoomChoice)
        {
            room = rooms[(int)debugRoom];
        }
        
        Vector3 roomCenter = room.transform.position;
        Vector3 randXOffset = new Vector3(Random.Range(-3f, 3f), 0, 0);
        Vector3 randZOffset = new Vector3(0, 0, Random.Range(-3f, 3f));

        agent.destination = (roomCenter + randXOffset + randZOffset);
        bearAI.Invoke("SelectNewDestination", Random.Range(minWaitTime, maxWaitTime));
    }
}
