using UnityEngine;
using System.Collections;
namespace Learn.Platformer {

    public class Patrolling : SideMovementController {
        Directions currentDirection;
        // Use this for initialization
        void Start() {
            currentDirection = Directions.Right;
        }

        // Update is called once per frame
        void Update() {
            if (FindObjectOfType<GameManager>().IsGamePaused) {
                return;
            }
            Move(currentDirection);
        }
        void ChangeDirection() {
            if (currentDirection == Directions.Right) {
                currentDirection = Directions.Left;
            } else {
                currentDirection = Directions.Right;
            }
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "EdgeCollider") {
                ChangeDirection();
            }
        }
    } 
}
