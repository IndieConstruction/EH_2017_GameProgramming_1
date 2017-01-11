using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// Totale delle monete contenute nella scena
    /// </summary>
    int MaxCoins; 
    /// <summary>
    /// Monete attualmente raccotte dal giocatore
    /// </summary>
    int CoinsCollected = 0;
    public Text TextCoin;

	// Use this for initialization
	void Start () {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        MaxCoins = coins.Length;
        UpdateCoinUI();
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
        UpdateCoinUI();
    }

    /// <summary>
    /// Aggiorna il valore del TextCoin
    /// </summary>
    void UpdateCoinUI() {
        TextCoin.text = CoinsCollected.ToString() + "/" + MaxCoins.ToString();
    }

}
