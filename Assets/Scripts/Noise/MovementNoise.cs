using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNoise : MonoBehaviour
{
    [Header("Noise Strength")]
    [Tooltip("Strength of noise event created when running.")]
    public int runStrength = 5;
    [Tooltip("Strength of noise event created when walking.")]
    public int walkStrength = 0;

    [Header("Event Timer")]
    [Tooltip("Time player needs to move before creating a noise event.")]
    public float moveTime = 0.5f;
    [Tooltip("Multiplier for how quickly time until next movement noise event should decay when not moving.")]
    public float decayRate = 0.3f;

    private FirstPersonMovement movement;
    private Crouch crouch;
    private CreateNoise noise;

    private float timer = 0f;

    private void Start()
    {
        movement = GetComponentInParent<FirstPersonMovement>();
        crouch = GetComponentInParent<Crouch>();
        noise = GetComponentInParent<CreateNoise>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is moving
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f))
        {
            var strength = movement.IsRunning ? runStrength : walkStrength;

            // Don't make noise if player is crouching
            if (!crouch.IsCrouched)
            {
                timer += Time.deltaTime;
                if (timer >= moveTime)
                {
                    timer = 0f;
                    noise.MakeNoise(strength);
                }
            }
        }
        else if (timer > 0f)
        {
            timer = (Mathf.Max(timer - Time.deltaTime * decayRate, 0f));
        }
    }
}
