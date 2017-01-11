using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// Totale delle monete contenute nella scena
    /// </summary>
    int MaxCoins; 
    /// <summary>
    /// Monete attualmente raccotte dal giocatore
    /// </summary>
    int CoinsCollected = 0;

	// Use this for initialization
	void Start () {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        MaxCoins = coins.Length;
    }
	
	// Update is called once per frame
	void Update () {

	}
    /// <summary>
    /// Incrementa il contatore delle monete raccolte dal player
    /// </summary>
    public void AddCoins() {
        CoinsCollected = CoinsCollected + 1;
        if (CoinsCollected == MaxCoins) {
            Debug.Log("Hai Vinto");
        }
    }
}
