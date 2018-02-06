using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class LowerPlayerUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public Vector3 respawnPoint;
        public bool dead;

        private void Awake()
        {
            dead = false;
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump1");
            }
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            float h = CrossPlatformInputManager.GetAxis("Horizontal1");
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "dropZone")
            {
                transform.position = respawnPoint;
            }
            if (other.tag == "checkpoint") 
            {
                respawnPoint = other.transform.position;
            }
        }
    }
}
