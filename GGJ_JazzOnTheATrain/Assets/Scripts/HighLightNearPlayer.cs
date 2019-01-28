using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightNearPlayer : MonoBehaviour
{
    public GameObject player;
    
    public float distance;

    public Vector3 originalScale;

    public bool tutorial;
    
    
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
            //this.transform.localScale = originalScale;
            SpriteRenderer[] _sprites = this.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer _localSprite in _sprites)
            {
                _localSprite.color = Color.white;
                
                SpriteRenderer _spaceBar = GameObject.Find("SpaceBar").GetComponent<SpriteRenderer>();
                _spaceBar.enabled = false;
            }

        }
    }

    void Bigger()
    {
       // this.transform.localScale = new Vector3(1.2f,1.2f,1.2f);

        SpriteRenderer[] _sprites = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer _localSprite in _sprites)
        {
            _localSprite.color = Color.red;
            SpriteRenderer _spaceBar = GameObject.Find("SpaceBar").GetComponent<SpriteRenderer>();
            _spaceBar.enabled = true;
        }

    }
}
