using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Elemento che gestisce la raccolta, la collezione delle armi e la capacità di sparare
/// del gameobject che ha questo component
/// </summary>
public class WeaponManager : MonoBehaviour {

    List<Weapon> WeaponCollection = new List<Weapon>();

    private Weapon currentWeapon;
    /// <summary>
    /// 
    /// </summary>
    public Weapon CurrentWeapon {
        get { return currentWeapon; }
        set { currentWeapon = value; }
    }


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<Weapon>() != null) {
            WeaponCollection.Add(collision.GetComponent<Weapon>());
            Debug.Log(WeaponCollection[WeaponCollection.Count-1].Name);
            LoadWeapon(WeaponCollection[WeaponCollection.Count - 1]);
            GameObject.Destroy(collision.gameObject);
        }
    }

    private void LoadWeapon(Weapon _weaponToLoad) {
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
            Instantiate<GameObject>(prefabLoaded,transform);
        }
    }
}
