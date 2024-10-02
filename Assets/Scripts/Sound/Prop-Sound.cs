using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSound : MonoBehaviour
{
 
    public GameObject GenericSoundPrefab;
    private GameObject GenericObject;
    public bool collided = false;
    private bool waitingToStart = true;
    private bool singleuse = true;
    void Start()
    {
        singleuse = GetComponent<Thrown>().singleUse;
        GenericObject = gameObject;
        Invoke("EnableSound", 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player") && !waitingToStart)
        {
            if (singleuse == false)
            {
                GameObject instance = Instantiate(GenericSoundPrefab, GenericObject.transform.position, Quaternion.identity);
                Destroy(instance, 0.5f);
            }
        }
    }

    private void EnableSound()
    {
        waitingToStart = false;
    }
}
