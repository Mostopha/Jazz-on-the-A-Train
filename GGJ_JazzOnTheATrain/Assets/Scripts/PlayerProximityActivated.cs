using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;
using Object = System.Object;

public abstract class PlayerProximityActivated : MonoBehaviour
{
    public abstract void OnActivate();
    private PlayerCharacter playerCharacter;

    public void Update()
    {
        if (playerCharacter == null)
        {
            playerCharacter = FindObjectOfType<PlayerCharacter>();
        }

        if (playerCharacter.IsStartingInteraction() && this.IsInRangeOfPlayer())
        {
            this.OnActivate();
        }
    }

    public bool IsInRangeOfPlayer()
    {
        float playerX = playerCharacter.transform.position.x;
        print("distance: " + Math.Abs(this.transform.position.x - playerX));
        return Math.Abs(this.transform.position.x - playerX) < 1.5;
    }

    public static bool IsIntrusiveGuiOverlayVisible()
    {
        DialogueRunner dialogRunner = FindObjectOfType<DialogueRunner>();
        if (dialogRunner != null && dialogRunner.isDialogueRunning == true)
        {
            return true;
        }

        IntrusiveGuiOverlay[] intrusiveOverlays = FindObjectsOfType<IntrusiveGuiOverlay>();
        foreach (IntrusiveGuiOverlay intrusiveGuiOverlay in intrusiveOverlays)
        {
            if (intrusiveGuiOverlay.isActiveAndEnabled)
            {
                return true;
            }
        }

        return false;
    }
}