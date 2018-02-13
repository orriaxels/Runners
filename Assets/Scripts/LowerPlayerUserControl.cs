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

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump1");
            }
        }

        private void FixedUpdate()
        {
            
            float h = CrossPlatformInputManager.GetAxis("Horizontal1");

            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "death")
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
            if(col.tag == "movingPlatform")
            {                
                transform.parent = col.transform;
            }
        }
    
        void OnTriggerExit2D(Collider2D col)
        {
            if(col.tag == "movingPlatform")
            {                
                transform.parent = null; 
            }
        }

        public float getX()
        {
            return transform.position.x;
        }
    }
}
