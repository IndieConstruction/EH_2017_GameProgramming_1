using UnityEngine;
using System.Collections;

namespace Learn.Platformer {

    public class JumpController : MonoBehaviour {

        public float JumpForce = 6;

        bool isGrounded = false;
        Rigidbody2D rb;

        /// <summary>
        /// Se è true il game object a cui è collegato è un player
        /// </summary>
        bool isPlayer;

        void Start() {
            rb = GetComponent<Rigidbody2D>();
            if(gameObject.tag == "Player") {
                isPlayer = true;
            }
            else {
                isPlayer = false;
            }
        }

        void Update() {

            if (Input.GetKeyDown(KeyCode.J) && isPlayer) {
                Jump();
            }
        }

        void OnCollisionEnter2D(Collision2D coll) {
            isGrounded = true;
        }

        void OnCollisionStay2D(Collision2D coll) {
            isGrounded = true;
        }

        void OnCollisionExit2D(Collision2D coll) {
            isGrounded = false;
        }

        #region API
        public void Jump() {
            if(isGrounded == true) {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
        #endregion
    }
}