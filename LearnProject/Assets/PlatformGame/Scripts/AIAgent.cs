using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Learn.Platformer {
    [RequireComponent(typeof (JumpController))]
    [System.Serializable]
    public class AIAgent : MonoBehaviour, IShooter, IKillable, ILiveBehaviour {

        public float minTime = 0.1f;
        public float maxTime = 1f;

        public List<GameObject> KillablePrefabs = new List<GameObject>();
        private List<IKillable> Killables = new List<IKillable>();

        // Use this for initialization
        JumpController jumpController;
        Weapon weapon;
        float startTime;
        float countTime;

        public Color GetBulletColor() {
            return Color.black;
        }

        void Start() {
            jumpController = GetComponent<JumpController>();
            weapon = GetComponentInChildren<Weapon>();
            InitTimeCounters(minTime, maxTime);

            foreach (GameObject k in KillablePrefabs) {
                if (k.GetComponent<IKillable>() != null)
                    Killables.Add(k.GetComponent<IKillable>());
            }
        }

        // Update is called once per frame
        void Update() {
            if(Time.time >= startTime + countTime) {
                jumpController.Jump();
                if(weapon != null) {
                    weapon.Shoot();
                }
                InitTimeCounters(minTime, maxTime);
            }
            
        }

        void InitTimeCounters(float _min, float _max) {
            startTime = Time.time;
            countTime = UnityEngine.Random.Range(_min, _max);
        }

        public List<IKillable> GetKillable() {
            return Killables;
        }

        public void Kill() {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
            foreach (MonoBehaviour item in gameObject.GetComponentsInChildren<ILiveBehaviour>())
                item.enabled = false;
            foreach (var item in gameObject.GetComponentsInChildren<Collider2D>())
                item.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
