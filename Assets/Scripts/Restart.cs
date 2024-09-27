using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Try Again Text UI
    GameObject tryAgain;
    //GameObject Victory;
    //lose barrier cube
    GameObject loseBarrier;
    // Start is called before the first frame update
    void Start()
    {
        //Shows try again object UI
        tryAgain = GameObject.FindGameObjectWithTag("TryAgain");
        //Victory = GameObject.FindGameObjectWithTag("Victory");
        loseBarrier = GameObject.FindGameObjectWithTag("losebarrier");
        tryAgain.SetActive(false);

    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            tryAgain.SetActive(true);
            //disappear in two seconds
            Invoke("resetGame", 3f);
        }
        //resetGame();

    }

    void resetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Update is called once per frame


}
