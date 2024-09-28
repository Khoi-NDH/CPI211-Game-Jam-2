using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDImageSelector : MonoBehaviour
{
    [SerializeField] GameObject player;
    private BasicPickUp pickUp;

    public Sprite openHand;
    public Sprite grabHand;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            Debug.Log(name + " does not have a player connected!");
            return;
        }

        pickUp = player.GetComponent<BasicPickUp>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pickUp)
            return;

        if (pickUp.heldObject)
            image.overrideSprite = grabHand;
        else
        {
            image.overrideSprite = pickUp.isHovering ? openHand : null;
        }
    }
}
