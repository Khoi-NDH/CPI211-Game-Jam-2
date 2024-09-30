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
    private Animator fade_transition;
    // Start is called before the first frame update

    private void Start()
    {
     Victory.SetActive(false);
    }
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Teleporter"))
        {
            
            Player.transform.position = Teleport.transform.position;
            Victory.SetActive(true);

            Victory.GetComponent<Animator>().Play("Introduce text");
            Invoke("resetGame", 10f);




        }
      


    }
   void resetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}

