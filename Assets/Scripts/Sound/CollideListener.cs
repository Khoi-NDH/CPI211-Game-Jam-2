using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideListener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject GenericObject;
    public GameObject GenericSoundPrefab;
    private bool collided = false;
    private bool collision_occured = false;

    void Start()
    {

        GenericObject = GameObject.FindGameObjectWithTag("AbleToGrab");
       

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
        collided = GenericObject.GetComponent<PropSound>().collided;
   

        if (collided == true && collision_occured == false)
        {
            GameObject instance = Instantiate(GenericSoundPrefab, GenericObject.transform.position, Quaternion.identity);
    
            Destroy(instance,0.3f);
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
