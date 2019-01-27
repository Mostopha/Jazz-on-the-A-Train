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

        public Animator anim;
        public Transform t;
        float OGscale;

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
            anim = GameObject.Find("Jazz").GetComponent<Animator>();
            t = GameObject.Find("Jazz").transform;
            OGscale = t.localScale.x;
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
            // Remove all player control when we're in dialogue, map, etc.
            if (PlayerProximityActivated.IsIntrusiveGuiOverlayVisible())
            {
                return;
            }

            // Move the player, clamping them to within the boundaries 
            // of the level.
            var movement = Input.GetAxis("Horizontal");
            anim.SetBool("Walking", movement != 0);
            movement += movementFromButtons;
            movement *= (moveSpeed * Time.deltaTime);


            var newPosition = transform.position;
            newPosition.x += movement;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition, maxPosition);

            transform.position = newPosition;

            if (movement < 0)
            {
                Vector3 mod = new Vector3(OGscale * -1, t.localScale.y, t.localScale.z);
                t.localScale = mod;
            }
            if (movement > 0)
            {
                Vector3 mod = new Vector3(OGscale, t.localScale.y, t.localScale.z);
                t.localScale = mod;
            }
        }


        public bool IsStartingInteraction()
        {
            if (PlayerProximityActivated.IsIntrusiveGuiOverlayVisible())
            {
                return false;
            }

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



        public void moveTo(float positionX)
        {
            var newPosition = transform.position;
            newPosition.x = positionX;
            transform.position = newPosition;
        }
    }
}