using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoise : MonoBehaviour
{
    public GameObject noiseObject;

    private void Start()
    {
        if (!noiseObject)
        {
            Debug.Log(name + " does not have a noise object connected!");
        }
    }
    public void MakeNoise(int strength)
    {
        var noise = GameObject.Instantiate(noiseObject, transform);
        noise.GetComponent<NoiseEvent>().noiseStrength = strength;
    }
}
