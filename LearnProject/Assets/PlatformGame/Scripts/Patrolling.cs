using UnityEngine;
using System.Collections;
namespace Learn.Platformer {

    public class Patrolling : SideMovementController, ILiveBehaviour {
        Direction currentDirection = Direction.Right;
                   

        // Update is called once per frame
        void Update() {
            if (FindObjectOfType<GameManager>().IsGamePaused) {
                return;
            }
            Move(currentDirection);
        }
        void ChangeDirection() {
            if (currentDirection == Direction.Right) {
                currentDirection = Direction.Left;
                ChangeHandPosition(-1);
            } else {
                currentDirection = Direction.Right;
                ChangeHandPosition(1);
            }
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "EdgeCollider") {
                ChangeDirection();
            }
        }
    } 
}
