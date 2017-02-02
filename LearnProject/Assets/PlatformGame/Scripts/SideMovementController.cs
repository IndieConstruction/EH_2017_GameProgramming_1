using UnityEngine;
using System.Collections;
namespace Learn.Platformer {

    public class SideMovementController : MonoBehaviour {

        // Variabile settabile esternamente
        public float SpeedMultiplier = 0.2f;

        // Variabili ad uso interno
        int SideMovement = 0;
        private Animator anim;
        GameObject hand;
        Vector2 handInitialPosition;

        void Start() {
            // carico il riferimento all'animator
            anim = GetComponent<Animator>();
            hand = GameObject.Find("Hand");
            handInitialPosition = hand.transform.localPosition;
        }

        void Update() {
            // Calcolo movimento laterale
            if (Input.GetKey(KeyCode.A)) {
                Move(Directions.Left);
                hand.transform.localPosition = new Vector2(handInitialPosition.x * SideMovement , handInitialPosition.y);

            } else if (Input.GetKey(KeyCode.D)) {
                Move(Directions.Right);
                hand.transform.localPosition = new Vector2(handInitialPosition.x * SideMovement, handInitialPosition.y);
            } else {
                Move(Directions.Idle);
            }

            // Animazione del movimento laterale
            anim.SetInteger("SideMovement", SideMovement);
            // Movimento laterale
        }

        public void Move(Directions _direction) {
            if (_direction == Directions.Right) {
                SideMovement = 1;
            } else if(_direction == Directions.Left) {
                SideMovement = -1;
            }
            else {
                SideMovement = 0;
            }
            transform.position = (Vector2)transform.position + new Vector2(SideMovement * SpeedMultiplier, 0);
        }

    }

    public enum Directions {
        Right,
        Left,
        Idle
    }
}