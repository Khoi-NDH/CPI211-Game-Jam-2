using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoise : MonoBehaviour
{
    [SerializeField] private GameObject noiseObject;

    public void MakeNoise(int strength)
    {
        var noise = GameObject.Instantiate(noiseObject, transform);
        noise.GetComponent<NoiseEvent>().noiseStrength = strength;
    }
}
