using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BearAI : MonoBehaviour
{
    private Wander wander;
    private Search search;

    public float searchTime = 15f;
    private float searchTimer;

    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<Wander>();
        search = GetComponent<Search>();
    }

    // Update is called once per frame
    void Update()
    {
        if (search)
        {
            if (searchTimer >= searchTime)
            {
                wander.enabled = true;
                search.enabled = false;
                searchTimer = 0;
            }
            else
            {
                searchTimer += Time.deltaTime;
            }
        }
    }

    public void NoiseHeard(Vector3 position)
    {
        searchTimer = 0;
        wander.enabled = false;
        search.enabled = true;
        search.BeginSearch(position);
    }
}
