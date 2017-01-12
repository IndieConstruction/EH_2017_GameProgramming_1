using UnityEngine;
using System.Collections;

namespace Learn.Platformer {

    public class JumpController : MonoBehaviour {

        public float JumpForce = 6;

        bool isGrounded = false;
        Rigidbody2D rb;

        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update() {

            if (Input.GetKeyDown(KeyCode.J) && isGrounded == true) {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
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
    }
}