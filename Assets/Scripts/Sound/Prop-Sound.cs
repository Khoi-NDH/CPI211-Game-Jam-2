using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSound : MonoBehaviour
{
 
    public GameObject GenericSoundPrefab;
    private GameObject GenericObject;
    public bool collided = false;
    
    void Start() {

        GenericObject = gameObject;


    }
    private void OnCollisionEnter(Collision Collision)
    {
        Debug.Log("Impact!");
       

    }

    private void OnCollisionExit(Collision Collision)
    {
        GameObject instance = Instantiate(GenericSoundPrefab, GenericObject.transform.position, Quaternion.identity);
        Destroy(instance, 0.5f);
    }






    // Update is called once per frame
    void Update()
    {
       

    }
}
