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

        /// <summary>
        /// return the actual direction of the object of SideMovementController
        /// </summary>
        /// <returns></returns>
        public Direction GetDirection() {
            if (SideMovement == 1)
                return Direction.Right;
            if (SideMovement == -1)
                return Direction.Left;

           return Direction.Idle;
        }

        void Start() {
            // carico il riferimento all'animator
            anim = GetComponent<Animator>();
            hand = GameObject.Find("Hand");
            handInitialPosition = hand.transform.localPosition;
        }

        void Update() {
            // Calcolo movimento laterale
            if (Input.GetKey(KeyCode.A)) {
                Move(Direction.Left);
                hand.transform.localPosition = new Vector2(handInitialPosition.x * SideMovement , handInitialPosition.y);

            } else if (Input.GetKey(KeyCode.D)) {
                Move(Direction.Right);
                hand.transform.localPosition = new Vector2(handInitialPosition.x * SideMovement, handInitialPosition.y);
            } else {
                Move(Direction.Idle);
            }

            // Animazione del movimento laterale
            anim.SetInteger("SideMovement", SideMovement);
            // Movimento laterale
        }

        

        public void Move(Direction _direction) {
            if (_direction == Direction.Right) {
                SideMovement = 1;
            } else if(_direction == Direction.Left) {
                SideMovement = -1;
            }
            else {
                SideMovement = 0;
            }
            transform.position = (Vector2)transform.position + new Vector2(SideMovement * SpeedMultiplier, 0);
        }

    }

    public enum Direction {
        Right,
        Left,
        Idle
    }
}