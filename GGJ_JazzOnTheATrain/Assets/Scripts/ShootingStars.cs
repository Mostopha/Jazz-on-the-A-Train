using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStars : MonoBehaviour
{
    public Material starField;
    
    // Start is called before the first frame update
    void Start()
    {
        //starField = this.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        starField.mainTextureOffset = new Vector2((starField.mainTextureOffset.x + Time.deltaTime), 1);
    }
    
}
