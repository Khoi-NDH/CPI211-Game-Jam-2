using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{
    private CreateNoise noise;

    public int strength = 0;
    public bool singleUse = false;

    // Start is called before the first frame update
    void Start()
    {
        noise = GetComponent<CreateNoise>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Thrown"))
        {
            if (!singleUse)
            {
                tag = "AbleToGrab";
            }

            if (noise)
            {
                noise.MakeNoise(strength);
            }
        }
    }
}
