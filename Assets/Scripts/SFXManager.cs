using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager sndMan;
    private AudioSource audioSrc;
    public AudioClip[] IdleSound;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;
    private int randomIdleSound;

    // Start is called before the first frame update

    void Start()
    {
       
        sndMan = this;
        audioSrc = GetComponent<AudioSource>();
        CallNoise();






    }

    void CallNoise()
    {
        Invoke("RandomNoise", 5f);
    }

    // Update is called once per frame
    void  RandomNoise()
    {
        randomIdleSound = Random.Range(0, 5);
        audioSrc.PlayOneShot(IdleSound[randomIdleSound]);
        CallNoise();

    }
}
