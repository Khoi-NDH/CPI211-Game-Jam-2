using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrigger : MonoBehaviour
{
    public List<GameObject> adjacentRooms = new();  // list of adjacent room triggers, currently populated manually
    [HideInInspector]
    public int propagationDist;

    [Tooltip("Amount propagation distance should decay when a noise travels through the room.")]
    public int distanceDecay = 1;
    public bool monsterPresent = false;

    private GameObject bear;

    void Start()
    {
        bear = GameObject.Find("Bear");
    }

    private void OnTriggerEnter(Collider collider)
    {
        // If something makes a loud noise
        if (collider.CompareTag("Noise"))
        {
            GetNoise(collider);
        }

        if (collider.CompareTag("Bear"))
        {
            Debug.Log("Monster has entered " + name);
            monsterPresent = true;
        }
    }

    /*
    private void OnTriggerStay(Collider collider)
    {
        // For persistent noise triggers, currently unimplemented
    }
    */

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Bear"))
        {
            Debug.Log("Monster has left " + name);
            monsterPresent = false;
        }
    }

    private void GetNoise(Collider collider)
    {
        var noise = collider.GetComponent<NoiseEvent>();

        // Get noise strength
        propagationDist = noise.noiseStrength;
        Debug.Log("Noise triggered in " + name + " (strength " + propagationDist + ")");

        // Destroy noise event if it is not persistent
        if (!noise.isPersistent)
        {
            Destroy(collider.gameObject);
        }

        // Call noise propagation method
        PropagateNoise(collider.transform.position);
    }

    // Propagate noise breadth-first, visiting each adjacent room
    // If monster is in one of the visited rooms, it will hear the noise and investigate
    private void PropagateNoise(Vector3 position)
    {
        Queue<GameObject> queue = new();
        List<string> visited = new();
        GameObject currRoom;

        visited.Add(name);
        queue.Enqueue(gameObject);

        while (queue.Count > 0)
        {
            currRoom = queue.Dequeue();
            var currTrigger = currRoom.GetComponent<NoiseTrigger>();

            if (currTrigger.monsterPresent)
            {
                Debug.Log("Monster in " + currRoom.name + " heard a noise!");
                NotifyMonster(position);
                return;
            }

            // If there is remaining distance for the noise to travel
            if (currTrigger.propagationDist > 0)
            {
                // Spread noise to unvisited rooms
                foreach (var room in currRoom.GetComponent<NoiseTrigger>().adjacentRooms)
                {
                    if (visited.Contains(room.name))
                    {
                        continue;
                    }

                    var trigger = room.GetComponent<NoiseTrigger>();

                    // Set the distance for noise to travel from each room
                    // to the current remaining distance minus the amount it
                    // should decay when traveling through the room (default 1)
                    // For example: a large room or long hallway may have a larger decay
                    trigger.propagationDist = (currTrigger.propagationDist - trigger.distanceDecay);

                    Debug.Log("Noise propagated to " + room.name + " (strength " + trigger.propagationDist + ")");
                    visited.Add(room.name);
                    queue.Enqueue(room);
                }
            }
        }
    }

    private void NotifyMonster(Vector3 position)
    {
        bear.GetComponent<BearAI>().NoiseHeard(position);
    }
}
