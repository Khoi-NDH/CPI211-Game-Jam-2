using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoise : MonoBehaviour
{
    [SerializeField] GameObject noiseObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var noise = GameObject.Instantiate(noiseObject, this.transform);
            noise.GetComponent<NoiseEvent>().noiseStrength = 3;
        }
    }
}
