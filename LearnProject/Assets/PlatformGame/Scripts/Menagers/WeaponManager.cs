using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Learn.Platformer {
    /// <summary>
    /// Elemento che gestisce la raccolta, la collezione delle armi e la capacità di sparare
    /// del gameobject che ha questo component
    /// </summary>
    public class WeaponManager : MonoBehaviour {

        public Transform PlayerHand;

        List<Weapon> WeaponCollection = new List<Weapon>() { null, null };
        /// <summary>
        /// Salva temporneamanete l'arma che il player ha in mano
        /// </summary>
        private Weapon oldCurrentWeapon;

        private Weapon currentWeapon;
        /// <summary>
        /// L'arma che il palyer ha in uso al momento
        /// </summary>
        public Weapon CurrentWeapon {
            get { return currentWeapon; }
            set {
                oldCurrentWeapon = currentWeapon;
                currentWeapon = value;
                PlaceOldWeapon();
            }
        }


        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (CurrentWeapon != null) {
                if (Input.GetKeyDown(KeyCode.Space))
                    currentWeapon.Shoot();
            }
        }
        /// <summary>
        /// Gestisce la sorte dell'arma che avevi in mano prima
        /// </summary>
        void PlaceOldWeapon() {
            for (int i = 0; i < WeaponCollection.Count; i++) {
                if (WeaponCollection[i] == null) {
                    WeaponCollection[i] = oldCurrentWeapon;
                    if (oldCurrentWeapon != null) {
                        //Distrugge il primo oggetto con Component Weapon tra le istanze dei propri figli
                        Destroy(GetComponentInChildren<Weapon>().gameObject);
                    }
                    return;
                }
            }
            DropWeapon(oldCurrentWeapon);
            //Distrugge il primo oggetto con Component Weapon tra le istanze dei propri figli
            Destroy(GetComponentInChildren<Weapon>().gameObject);
        }

        /// <summary>
        /// Anzichè salvare il component Weapon del GameObject in scena, prima ne istanzia uno nuovo e distrugge quello con cui si entra in collisione,
        /// e in CurrentWeapon viene salvato il component della nuova istanza.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.GetComponent<Weapon>() != null /*&& collision.GetType().Name == "CircleCollider2D"*/) {

                SetParentWeapon(collision.GetComponent<Weapon>(), PlayerHand);
                Destroy(collision.gameObject);
            }
        }

        /// <summary>
        /// Raccoglie arma assegnandola a CurrentWeapon e istanziandola come figlia di _parent
        /// </summary>
        /// <param name="_weaponToLoad">Arma da caricare</param>
        /// /// <param name="_parent">L'oggetto padre dell'istanza</param>
        private void SetParentWeapon(Weapon _weaponToLoad, Transform _parent) {
            Weapon prefabLoaded = null;

            switch (_weaponToLoad.Name) {
                case "Pistola":
                    prefabLoaded = Resources.Load<Weapon>("Weapons/Gun");
                    break;
                case "Fucile":
                    prefabLoaded = Resources.Load<Weapon>("Weapons/Shotgun");
                    break;
                default:
                    break;
            }

            if (prefabLoaded != null) {
                CurrentWeapon = Instantiate<Weapon>(prefabLoaded, _parent, true);
                //CurrentWeapon.Owner = "Player";
                CurrentWeapon.transform.localPosition = Vector2.zero;

            }


        }


        /// <summary>
        /// Raccoglie arma Senza l'assegnazione a CurrentWeapon e la istanzia
        /// </summary>
        /// <param name="_weaponToLoad">Arma da caricare</param>
        private void DropWeapon(Weapon _weaponToLoad) {
            GameObject prefabLoaded = null;

            switch (_weaponToLoad.Name) {
                case "Pistola":
                    prefabLoaded = Resources.Load<GameObject>("Weapons/Gun");
                    break;
                case "Fucile":
                    prefabLoaded = Resources.Load<GameObject>("Weapons/Shotgun");
                    break;
                default:
                    break;
            }

            if (prefabLoaded != null) {
                Instantiate<GameObject>(prefabLoaded);
            }

        }
    }
}
