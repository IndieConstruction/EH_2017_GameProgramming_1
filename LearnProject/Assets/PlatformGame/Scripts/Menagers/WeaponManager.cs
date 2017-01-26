using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Elemento che gestisce la raccolta, la collezione delle armi e la capacità di sparare
/// del gameobject che ha questo component
/// </summary>
public class WeaponManager : MonoBehaviour {

    public Transform PlayerBag;
    public Transform PlayerHand;

    List<Weapon> WeaponCollection = new List<Weapon>() {null, null};
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
            SetParentWeapon(CurrentWeapon, PlayerHand);
            PlaceOldWeapon();
        }
    }


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Gestisce la sorte dell'arma che avevi in mano prima
    /// </summary>
    void PlaceOldWeapon() {
        for(int i = 0; i < WeaponCollection.Count; i++ ) {
            if(WeaponCollection[i] == null) {
                WeaponCollection[i] = oldCurrentWeapon;
                if (oldCurrentWeapon != null) {
                    Debug.Log("Destroy");
                    GameObject.Destroy(oldCurrentWeapon.gameObject);
                }
                return;
            }
        }
        SetParentWeapon(oldCurrentWeapon,null);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<Weapon>() != null && collision.GetType().Name == "CircleCollider2D") {
            CurrentWeapon = collision.GetComponent<Weapon>();
            GameObject.Destroy(collision.gameObject);       
        }
    }

    /// <summary>
    /// Raccoglie arma 
    /// </summary>
    /// <param name="_weaponToLoad"></param>
    private void SetParentWeapon(Weapon _weaponToLoad, Transform _parent) {
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
            Instantiate<GameObject>(prefabLoaded, _parent).transform.localPosition = Vector2.zero;
        }
    }
}
