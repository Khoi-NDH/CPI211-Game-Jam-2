using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideListener : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GenericObject1;
    public GameObject GenericObject2;
    public GameObject GenericObject3;
    //public GameObject GenericObject4;
    //public GameObject GenericObject5;
    public GameObject floor;
    public GameObject GenericSoundPrefab;
    private bool collided = false;
    private bool collision_occured = false;

    void Start()
    {

        
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
            GameObject instance = Instantiate(GenericSoundPrefab, GenericObject1.transform.position, Quaternion.identity);
            GameObject instance2 = Instantiate(GenericSoundPrefab, GenericObject2.transform.position, Quaternion.identity);
            GameObject instance3 = Instantiate(GenericSoundPrefab, GenericObject3.transform.position, Quaternion.identity);
            //GameObject instance4 = Instantiate(GenericSoundPrefab, GenericObject4.transform.position, Quaternion.identity);
            //GameObject instance5 = Instantiate(GenericSoundPrefab, GenericObject5.transform.position, Quaternion.identity);

            Destroy(instance,1f);
            Destroy(instance2, 1f);
            Destroy(instance3, 1f);
            //Destroy(instance4, 1f);
            //Destroy(instance5, 1f);
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
