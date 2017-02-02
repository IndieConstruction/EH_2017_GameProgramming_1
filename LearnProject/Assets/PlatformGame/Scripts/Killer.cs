using UnityEngine;
using System.Collections;
namespace Learn.Platformer {
    /// <summary>
    /// Uccide il player al contatto
    /// </summary>
    public class Killer : MonoBehaviour {

        public string target;

        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == target) {
                Destroy(other.gameObject);
            }
        }
    }
}
