using Learn.Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    IShooter Owner;
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
        IKillable killable = collision.gameObject.GetComponent<IKillable>();
        if(killable != null) {
            foreach (IKillable item in Owner.GetKillable()) {
                if(item.GetType() == killable.GetType()) {
                    killable.Kill();
                }
            }
            //Owner.GetKillable().Exists(k => k.GetType() == killable.GetType())        
        }
    }

    public void SetOwner(IShooter _owner) {
        Owner = _owner;
        gameObject.GetComponent<SpriteRenderer>().color = Owner.GetBulletColor();
    }
}
