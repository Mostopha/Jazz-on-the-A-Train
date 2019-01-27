﻿/*

The MIT License (MIT)

Copyright (c) 2015 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Yarn.Unity.Example
{
    public class PlayerCharacter : MonoBehaviour
    {
        public float minPosition = -5.3f;
        public float maxPosition = 5.3f;

        public float moveSpeed = 1.0f;

        public float interactionRadius = 2.0f;

        public float movementFromButtons { get; set; }

        // Draw the range at which we'll start talking to people.
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, 1, 0));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
        }

        void Start()
        {
            MakeDoorsReachable();
        }

        private void MakeDoorsReachable()
        {
            Door[] doors = Object.FindObjectsOfType<Door>();
            foreach (Door door in doors)
            {
                float doorX = door.gameObject.transform.position.x;
                if (doorX - 1 < minPosition)
                {
                    minPosition = doorX - 1;
                }

                if (doorX + 1 > maxPosition)
                {
                    maxPosition = doorX + 1;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            DialogueRunner dialogRunner = FindObjectOfType<DialogueRunner>();
            // Remove all player control when we're in dialogue
            if (dialogRunner != null && dialogRunner.isDialogueRunning == true)
            {
                return;
            }

            // Move the player, clamping them to within the boundaries 
            // of the level.
            var movement = Input.GetAxis("Horizontal");
            movement += movementFromButtons;
            movement *= (moveSpeed * Time.deltaTime);


            var newPosition = transform.position;
            newPosition.x += movement;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition, maxPosition);

            transform.position = newPosition;


            // Detect if we want to start a conversation
            
            if (IsStartingInteraction())
            {
                CheckForNearbyNPC();
            }
        }

        public bool IsStartingInteraction()
        {
            KeyCode[] interactionKeys =
            {
                KeyCode.Return,
                KeyCode.Space,
                KeyCode.O
            };
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in interactionKeys)
                {
                    if (Input.GetKeyDown(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public void CheckForNearbyNPC()
        {
            // Find all DialogueParticipants, and filter them to
            // those that have a Yarn start node and are in range; 
            // then start a conversation with the first one
            var allParticipants = new List<NPC>(FindObjectsOfType<NPC>());
            var target = allParticipants.Find(delegate(NPC p)
            {
                return string.IsNullOrEmpty(p.talkToNode) == false && // has a conversation node?
                       (p.transform.position - this.transform.position) // is in range?
                       .magnitude <= interactionRadius;
            });
            if (target != null)
            {
                Debug.Log(target.characterName);
                // Kick off the dialogue at this node.
                FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);

                Yarn.Value v = new Yarn.Value(true);
                FindObjectOfType<ExampleVariableStorage>().SetValue("$happy", v);
                Yarn.Value b = FindObjectOfType<ExampleVariableStorage>().GetValue("$happy");
                Debug.Log(b.type);
                if (b.type == Yarn.Value.Type.Bool)
                {
                    bool boolean = b.AsBool;
                    Debug.Log(boolean);
                }
                //Yarn.Value c = FindObjectOfType<ExampleVariableStorage>().GetValue("$should_see_sally"); 

                //Debug.Log(c);	
            }
        }

        public void moveTo(float positionX)
        {
            var newPosition = transform.position;
            newPosition.x = positionX;
            transform.position = newPosition;
        }
    }
}