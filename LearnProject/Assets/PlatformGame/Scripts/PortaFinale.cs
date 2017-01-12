using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Porta in collisione triggerata con il Player setta la condizione di vittoria (IsWinning in GameManager) a true
/// </summary>
public class PortaFinale : MonoBehaviour {

    GameManager GM;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            GM = GameObject.FindObjectOfType<GameManager>();
            GM.DoWin();
        }
    }
}
