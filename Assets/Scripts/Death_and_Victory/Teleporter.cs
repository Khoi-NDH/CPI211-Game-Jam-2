using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //"How to Make Teleporters in Unity" by Code Ripple
    public GameObject Player;
    public GameObject Teleport;
    public GameObject Victory;
    public GameObject Locked;
    private Animator fade_transition;

    public bool hasKey = false;

    // Start is called before the first frame update
    private void Start()
    {
        Victory.SetActive(false);
    }

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Teleporter"))
        {
            if (!hasKey)
            {
                Locked.SetActive(true);
                Locked.GetComponent<Animator>().Play("Introduce text");
            }
            else
            {
                Player.transform.position = Teleport.transform.position;
                Victory.SetActive(true);

                Victory.GetComponent<Animator>().Play("Introduce text");
                Invoke("ResetGame", 10f);
            }
        }
    }
    
    void ResetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

