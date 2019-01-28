using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static GameObject instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
    }

    private void Update()
    {
        Reset();
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(this.gameObject);
            SceneChanger.sceneChanger.SwitchToScene("Intro");
        }
    }
}
