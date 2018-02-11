using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class UpperPlayerUserController : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public Vector3 respawnPoint;
        public bool dead;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "dropZone" || other.gameObject.name == "Saw" || other.gameObject.name == "Enemy")
            {
                transform.position = respawnPoint;
            }
            if (other.tag == "checkpoint") 
            {
                respawnPoint = other.transform.position;
            }
        }

        void OnTriggerStay2D(Collider2D col)
        {     
            Debug.Log("hello1111");
            if(col.gameObject.name == "Hovering_platform")
            {
                Debug.Log("hello");
                transform.parent = col.transform;
            }
        }
    
        void OnTriggerExit2D(Collider2D col)
        {
            if(col.gameObject.name == "Hovering_platform")
            {
                Debug.Log("hello2222");
                transform.parent = null; 
            }
        } 
    }
}
