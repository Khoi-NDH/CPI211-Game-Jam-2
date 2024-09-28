using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] adjacentRooms;
    public bool bearPresent = false;
    public bool propagated = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Noise")
        {
            // Get noise strength
            var propagationDist = collider.GetComponent<NoiseEvent>().noiseStrength;
            Debug.Log("Noise triggered in " + name + " (strength " + propagationDist + ")");

            // Destroy noise event
            Destroy(collider.gameObject);

            propagateNoise(adjacentRooms, propagationDist);
        }

        if (collider.tag == "Bear")
        {
            bearPresent = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Bear")
        {
            bearPresent = false;
        }
    }

    bool propagateNoise(GameObject[] rooms, int dist)
    {
        propagated = true;

        if (dist > 0)
        {
            foreach (GameObject room in rooms)
            {
                if (room.GetComponent<NoiseTrigger>().propagated)
                {
                    continue;
                }

                room.GetComponent<NoiseTrigger>().propagated = true;

                Debug.Log("Noise propagated to " + room.name + " (strength " + (dist - 1) + ")");

                if (room.GetComponent<NoiseTrigger>().bearPresent)
                {
                    // Notify bear
                    room.GetComponent<NoiseTrigger>().propagated = false;

                    return true;
                }

                if (propagateNoise(room.GetComponent<NoiseTrigger>().adjacentRooms, (dist - 1)))
                {
                    room.GetComponent<NoiseTrigger>().propagated = false;

                    return true;
                }

                room.GetComponent<NoiseTrigger>().propagated = false;
            }
        }

        propagated = false;

        return false;
    }
}
