using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Try Again Text UI
    public GameObject JumpscareImage;
    //GameObject Victory;
    //lose barrier cube
    GameObject Monster;
    private AudioSource thisAudioSource;
    public AudioClip Scare;
    public float ScareVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Shows jump scare image object UI
        thisAudioSource = GetComponent<AudioSource>();
        //Victory = GameObject.FindGameObjectWithTag("Victory");
        Monster = GameObject.FindGameObjectWithTag("Bear");
        JumpscareImage.SetActive(false);

    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {

            JumpscareImage.SetActive(true);
            //disappear in two seconds
            thisAudioSource.PlayOneShot(Scare);
            thisAudioSource.volume = ScareVolume;
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
