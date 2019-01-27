using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightNearPlayer : MonoBehaviour
{
    public GameObject player;
    
    public float distance;

    public Vector3 originalScale;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        originalScale = this.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance < 4)
        {
            Bigger();
        }
        else
        {
            this.transform.localScale = originalScale;
        }
    }

    void Bigger()
    {
        this.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }
}
