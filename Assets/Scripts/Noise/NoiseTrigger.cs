using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrigger : MonoBehaviour
{
    public GameObject[] adjacentRooms;   // List of adjacent rooms (triggers), currently populated manually for each room
    [Tooltip("Amount propagation distance should decay when a noise travels through the room.")]
    [SerializeField] private int distanceDecay = 1;

    [HideInInspector]
    public int propagationDist;

    public bool bearPresent = false;

    void OnTriggerEnter(Collider collider)
    {
        // If something made a loud noise
        if (collider.tag == "Noise")
        {
            // Get noise strength
            propagationDist = collider.GetComponent<NoiseEvent>().noiseStrength;
            Debug.Log("Noise triggered in " + name + " (strength " + propagationDist + ")");

            // Destroy noise event if it is not persistent
            if (!collider.GetComponent<NoiseEvent>().isPersistent)
                Destroy(collider.gameObject);

            // Call noise propagation method
            propagateNoise();
        }

        if (collider.tag == "Bear")
        {
            bearPresent = true;
            Debug.Log("Bear has entered " + name);
        }
    }

    /*
    void OnTriggerStay(Collider collider)
    {
        // For persistent noise triggers, currently unimplemented
    }
    */

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Bear")
        {
            bearPresent = false;
            Debug.Log("Bear has left " + name);
        }
    }

    // Propagate noise breadth-first, visiting each adjacent room
    // If bear is in one of the visited rooms, it will hear the noise and investigate
    void propagateNoise()
    {
        Queue<GameObject> queue = new Queue<GameObject>();
        List<string> visited = new List<string>();
        GameObject currRoom;

        visited.Add(name);
        queue.Enqueue(this.gameObject);

        while (queue.Count > 0)
        {
            currRoom = queue.Dequeue();

            if (bearPresent)
            {
                Debug.Log("Bear in " + currRoom.name  + " heard a noise!");
                /*
                 * TODO:
                 * Notify bear to investigate once it is implemented
                 */
                return;
            }

            // If there is remaining distance for the noise to travel
            if (currRoom.GetComponent<NoiseTrigger>().propagationDist > 0)
            {
                // Spread noise to unvisited rooms
                foreach (var room in currRoom.GetComponent<NoiseTrigger>().adjacentRooms)
                {
                    if (visited.Contains(room.name))
                        continue;

                    // Set the distance for noise to travel from each room
                    // to the current remaining distance minus the amount it
                    // should decay when traveling through the room (default 1)
                    // For example: a large room or long hallway may have a larger decay
                    room.GetComponent<NoiseTrigger>().propagationDist = (currRoom.GetComponent<NoiseTrigger>().propagationDist - room.GetComponent<NoiseTrigger>().distanceDecay);

                    Debug.Log("Noise propagated to " + room.name + " (strength " + room.GetComponent<NoiseTrigger>().propagationDist + ")");
                    visited.Add(room.name);
                    queue.Enqueue(room);
                }
            }
        }
    }
}
