/*

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
using UnityEngine.Experimental.UIElements;
using UnityEngine.Serialization;

namespace Yarn.Unity.Example
{
    public class NPC : PlayerProximityActivated
    {
        public string characterName = "";

        [FormerlySerializedAs("startNode")] public string talkToNode = "";

        [Header("Optional")] public TextAsset scriptToLoad;


        // Use this for initialization
        public override void OnActivate()
        {
            if (string.IsNullOrEmpty(talkToNode))
            {
                Debug.Log(characterName + " has nothing to say.");
            } else
            {
                Debug.Log("Beginning conversation with " + characterName + " at node " + talkToNode);
                // Kick off the dialogue at this node.
                FindObjectOfType<DialogueRunner>().StartDialogue(talkToNode);

                Yarn.Value v = new Yarn.Value(true);
                FindObjectOfType<ExampleVariableStorage>().SetValue("$happy", v);
                Yarn.Value b = FindObjectOfType<ExampleVariableStorage>().GetValue("$happy");
                Debug.Log(b.type);
                if (b.type == Yarn.Value.Type.Bool)
                {
                    bool boolean = b.AsBool;
                    Debug.Log(boolean);
                }
            }
        }

        void Start()
        {
            if (scriptToLoad != null)
            {
                FindObjectOfType<Yarn.Unity.DialogueRunner>().AddScript(scriptToLoad);
            }
        }
    }
}