using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{
    private CreateNoise noise;

    public GameObject shatteredVersion;

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
            if (noise)
            {
                noise.MakeNoise(strength);
            }

            if (singleUse)
            {
                // change to the broken version of item
                Shatter();
            }
            else
            {
                tag = "AbleToGrab";
            }
        }
    }

    private void Shatter() {

        // spawn shattered version at current position, destroy unshattered version
        Instantiate(shatteredVersion, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}
