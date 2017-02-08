using UnityEngine;
using System.Collections;
namespace Learn.Platformer {

    public class Patrolling : SideMovementController {
        Direction currentDirection;
        // Use this for initialization
        void Start() {
            currentDirection = Direction.Right;
        }

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
            } else {
                currentDirection = Direction.Right;
            }
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "EdgeCollider") {
                ChangeDirection();
            }
        }
    } 
}
