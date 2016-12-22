using UnityEngine;
using System.Collections;
namespace Learn.Platformer {
    public class SideMovementController : MonoBehaviour {

        // Variabile settabile esternamente
        public float SpeedMultiplier = 0.2f;

        // Variabili ad uso interno
        int SideMovement = 0;
        private Animator anim;

        void Start() {
            // carico il riferimento all'animator
            anim = GetComponent<Animator>();
        }

        void Update() {
            // Calcolo movimento laterale
            if (Input.GetKey(KeyCode.A)) {
                SideMovement = -1;
            } else if (Input.GetKey(KeyCode.D)) {
                SideMovement = 1;
            } else {
                SideMovement = 0;
            }

            // Animazione del movimento laterale
            anim.SetInteger("SideMovement", SideMovement);
            // Movimento laterale
            transform.position = transform.position + new Vector3(SideMovement * SpeedMultiplier, 0, 0);
        }

    }
}