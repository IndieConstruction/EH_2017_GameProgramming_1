using Learn.Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float startTime;
    float timeToCount = 4f;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= startTime + timeToCount) {
            Destroy(gameObject);
        }
	}
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Weapon>() || collision.gameObject.tag == "EdgeCollider" 
            || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            return;
        }
        Destroy(gameObject);
    }
}
