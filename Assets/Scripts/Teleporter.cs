using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //"How to Make Teleporters in Unity" by Code Ripple
    public GameObject Player;
    public GameObject Teleport;
    public GameObject Respawn;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Teleporter"))
        {
            
            Player.transform.position = Teleport.transform.position;

        }
        if (Col.gameObject.CompareTag("FallTeleport"))
        {
            Player.transform.position = Respawn.transform.position;
        }
    }

}

