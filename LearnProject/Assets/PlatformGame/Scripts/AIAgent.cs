using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Learn.Platformer {
    [RequireComponent(typeof (JumpController))]
    public class AIAgent : MonoBehaviour {

        public float minTime = 0.1f;
        public float maxTime = 1f;
        

        // Use this for initialization
        JumpController jumpController;
        Weapon weapon;
        float startTime;
        float countTime;

        void Start() {
            jumpController = GetComponent<JumpController>();
            weapon = GetComponentInChildren<Weapon>();
            InitTimeCounters(minTime, maxTime);
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
            countTime = Random.Range(_min, _max);
        }
    }
}
