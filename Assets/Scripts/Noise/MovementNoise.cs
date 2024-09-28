using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNoise : MonoBehaviour
{
    [Header("Noise Strength")]
    [Tooltip("Strength of noise event created when running.")]
    [SerializeField] private int runStrength = 5;
    [Tooltip("Strength of noise event created when walking.")]
    [SerializeField] private int walkStrength = 0;

    [Header("Event Timer")]
    [Tooltip("Time player needs to move before creating a noise event.")]
    [SerializeField] private float moveTime = 0.5f;
    [Tooltip("Multiplier for how quickly time until next movement noise event should decay when not moving.")]
    [SerializeField] private float decayRate = 0.3f;

    [Header("Components")]
    public FirstPersonMovement movement;
    public Crouch crouch;
    public CreateNoise noise;

    private float timer = 0f;

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
            timer -= Time.deltaTime * decayRate;
        }
    }
}
