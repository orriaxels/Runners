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

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");

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
            Debug.Log("hello1111");
            if(col.tag == "movingPlatform")
            {
                Debug.Log("hello");
                transform.parent = col.transform;
            }
        }
    
        void OnTriggerExit2D(Collider2D col)
        {
            if(col.tag == "movingPlatform")
            {
                Debug.Log("hello2222");
                transform.parent = null; 
            }
        }

        public float getX()
        {
            return transform.position.x;
        }
    }
}
