using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSound : MonoBehaviour
{
 
    public GameObject GenericSoundPrefab;
    private GameObject GenericObject;
    public bool collided = false;
    private bool waitingToStart = true;
    
    void Start()
    {
        GenericObject = gameObject;
        Invoke("EnableSound", 0.5f);
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (!waitingToStart)
        {
            GameObject instance = Instantiate(GenericSoundPrefab, GenericObject.transform.position, Quaternion.identity);
            Destroy(instance, 0.5f);
        }
    }

    private void EnableSound()
    {
        waitingToStart = false;
    }
}
