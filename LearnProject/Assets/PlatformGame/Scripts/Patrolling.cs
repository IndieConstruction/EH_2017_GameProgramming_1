using UnityEngine;
using System.Collections;

public class Patrolling : MonoBehaviour {
    bool IsRight;
	// Use this for initialization
	void Start () {
        IsRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<GameManager>().IsGamePaused) {
            return;
        }
        if (IsRight == true) {
            PatrollingDx();
        } else {
            PatrollingSx();
        }
	}

    void PatrollingDx() {
        transform.position = new Vector2(transform.position.x + 1 * 0.02f, transform.position.y);
    }
    void PatrollingSx() {
        transform.position = new Vector2(transform.position.x + -1 * 0.02f, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EdgeCollider") {
            if (IsRight == true) {
                IsRight = false;
            } else {
                IsRight = true;
            }
        }
    }

}
