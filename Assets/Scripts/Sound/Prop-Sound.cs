using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSound : MonoBehaviour
{
 
    public GameObject GenericSoundPrefab;
    public GameObject GenericObject;
    public bool collided = false;
    
    void Start() {

   


    }
    private void OnCollisionEnter(Collision Collision)
    {
        Debug.Log("Impact!");
        GameObject instance = Instantiate(GenericSoundPrefab, GenericObject.transform.position, Quaternion.identity);
        Destroy(instance, 1f);

    }





    // Update is called once per frame
    void Update()
    {
       

    }
}
