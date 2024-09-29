using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideListener : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GenericObject;
    public GameObject floor;
    public GameObject GenericSoundPrefab;
    private bool collided = false;
    private bool collision_occured = false;

    void Start()
    {

        GenericObject = GameObject.FindGameObjectWithTag("AbleToGrab");
        collided = false;

    }
    void Awake()
    {
       
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        collided = floor.GetComponent<PropSound>().collided;
   

        if (collided == true && collision_occured == false)
        {
            GameObject instance = Instantiate(GenericSoundPrefab, GenericObject.transform.position, Quaternion.identity);
    
            Destroy(instance,1f);
            collision_occured = true;
            Debug.Log("Impact!!!!");





        }
        else
        {
            if (collided == false)
                {
                collision_occured = false;
            }
        }
    }
}
