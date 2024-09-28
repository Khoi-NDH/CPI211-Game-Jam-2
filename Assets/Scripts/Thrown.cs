using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{
    private CreateNoise noise;

    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<CreateNoise>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        tag = "AbleToGrab";

        if (noise)
            noise.MakeNoise(3);
    }
}
