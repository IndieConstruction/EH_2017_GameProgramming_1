using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    public Sprite MarioBig;
    public Sprite MarioSmall;

    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B)) {
            ChangeMarioDimension(true);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            ChangeMarioDimension(false);
        }

        if (IsGrounded()) {
            // Is Grounded
        }
	}

    bool IsGrounded() {
        if (transform.position.y <= 0)
            return true;
        else
            return false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        ChangeMarioDimension(true);
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Collision 2d stay");
    }

    void OnTriggerExit2D(Collider2D other) {
        ChangeMarioDimension(false);
    }


    public void ChangeMarioDimension(bool isBig) {
        if (isBig == true) {
            spriteRenderer.sprite = MarioBig;
            boxCollider.size = new Vector2(0.64f, 0.64f);
        } else {
            spriteRenderer.sprite = MarioSmall;
            boxCollider.size = new Vector2(0.32f, 0.32f);
        }

    }
}
