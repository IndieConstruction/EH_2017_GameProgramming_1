using UnityEngine;
using System.Collections;

namespace Bellali {
    public class MonobClass : MonoBehaviour {

        public MyClass MC;

        public Transform T;
        public Vector3 TPos;


        public Vector3 Position() {
            return transform.position;
        }

        // Use this for initialization
        void Start() {
            MC = new MyClass("Ciaobbelli");
            int numEnemies = 3;

            TPos = T.position;

            for (int x = 0; x < numEnemies; x++) {

               



                ///////////////////////
                for (int y = 0; y < numEnemies; y++) {

                    for (int z = 0; z < numEnemies; z++) {
                        if(x != 2 && y != 1 && z != 2)
                            Instantiate(T, new Vector3(x, y, z), transform.rotation);
                    }

                }
                ///////////////////////

            }
        }

        // Update is called once per frame
        void Update() {
            //MC.LogMe();
            MC.Update();
        }
    }
}