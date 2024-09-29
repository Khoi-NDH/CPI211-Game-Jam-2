using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSound : MonoBehaviour
{
 
    //public GameObject GenericSoundPrefab;
    public bool collided = false;
    
    void Start()
    {
        //Collider Objectcollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision Collision)
    {
       

        if (collided != true )
        {
            Debug.Log("Impact!");
            collided = true;
           
        }
      
    }

   private void OnCollisionExit(Collision Collision)
    {

        if (collided == true)
        {

            collided = false;
        }

    }



    // Update is called once per frame
    void Update()
    {
       

    }
}
