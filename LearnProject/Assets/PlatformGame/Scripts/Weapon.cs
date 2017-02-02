using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Learn.Platformer {
    public class Weapon : MonoBehaviour {

        public string Owner;
        public string Name;
        public int Ammo;
        public float RateOfFire;
        public float RangeOfFire;
        public GameObject Bullet;
        public float BulletForce = 3f;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

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



                GameObject tempBullet = Instantiate<GameObject>(Bullet, this.transform.position, this.transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Direction, 0) * BulletForce, ForceMode2D.Impulse);
                if(Owner == "Player") {
                    tempBullet.GetComponent<Killer>().target = "Enemy";
                }
                else {
                    tempBullet.GetComponent<Killer>().target = "Player";
                }
                
                Ammo = Ammo - 1;
            }

        }
    }
}
