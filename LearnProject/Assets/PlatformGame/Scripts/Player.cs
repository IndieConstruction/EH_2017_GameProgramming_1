using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Platformer {

    public class Player : MonoBehaviour, IShooter, IKillable {

        public List<GameObject> KillablePrefabs = new List<GameObject>();
        private List<IKillable> Killables = new List<IKillable>();

        void Start() {
            foreach (var k in KillablePrefabs) {
                if (k.GetComponent<IKillable>() != null)
                    Killables.Add(k.GetComponent<IKillable>());
            }
        }

        public Color GetBulletColor() {
            return Color.white;
        }

        public List<IKillable> GetKillable() {
            return Killables;
        }

        public void Kill() {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            foreach (MonoBehaviour item in gameObject.GetComponentsInChildren<ILiveBehaviour>())
                item.enabled = false;
        }


        // Update is called once per frame
        void Update() {

        }
    }
}
