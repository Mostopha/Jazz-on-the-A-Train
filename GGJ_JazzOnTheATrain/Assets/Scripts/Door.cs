using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PlayerProximityActivated
{
    public string ToSceneName = "";
    
    public override void OnActivate()
    {
        SceneChanger.sceneChanger.SwitchToScene(ToSceneName);
    }
}