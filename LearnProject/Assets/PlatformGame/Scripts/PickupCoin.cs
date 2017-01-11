using UnityEngine;
using System.Collections;

namespace Learn.Platformer {

    public class PickupCoin : MonoBehaviour {

        GameManager gm;

        // Use this for initialization
        void Start() {
            gm = GameObject.FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update() {

        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                gm.AddCoins();
                Destroy(gameObject);
            }

        }
    }
}