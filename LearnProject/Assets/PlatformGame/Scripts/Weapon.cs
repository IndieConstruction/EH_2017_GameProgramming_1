﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Platformer {

    public class Weapon : MonoBehaviour {

        public string Name;
        public int Ammo;
        public float RateOfFire;
        public float RangeOfFire;
        public GameObject Bullet;
        public SideMovementController SMC;
        SpriteRenderer SR;
        public float BulletForce = 3f;

        // Use this for initialization
        void Start() {
            if (SMC == null)
                SMC = GetComponentInParent<SideMovementController>();

            SR = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update() {
            TurnWeapon();
        }

        void TurnWeapon() {
            if (SMC == null)
                return;

            if (SMC.GetDirection() == Direction.Left)
                SR.flipX = true;
            else if(SMC.GetDirection() == Direction.Right)
                SR.flipX = false;
        }

        public void DropMe() {
            gameObject.transform.SetParent(null);
            gameObject.AddComponent<Rigidbody2D>();
            Destroy(gameObject, 3f);
        }

        public void Shoot() {
            if (Ammo > 0) {
                int Direction = 0;      //Se la mano è rivolta a sinistra avrà valore -1; rivolta a destra, 1.

                foreach (Transform t in GetComponentsInParent<Transform>()) {
                    if (t.name == "Hand") {
                        if (t.localPosition.x > 0) {
                            Direction = 1;
                        } else {
                            Direction = -1;
                        }
                        break;
                    }

                }



                Bullet tempBullet = Instantiate<Bullet>(Bullet.GetComponent<Bullet>(), this.transform.position, this.transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Direction, 0) * BulletForce, ForceMode2D.Impulse);

                IShooter owner = GetComponentInParent<IShooter>();
                tempBullet.SetOwner(owner);
                
                Ammo = Ammo - 1;
            }

        }
    }
}
