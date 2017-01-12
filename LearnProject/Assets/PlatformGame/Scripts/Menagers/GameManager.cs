using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// Totale delle monete contenute nella scena
    /// </summary>
    int MaxCoins; 
    /// <summary>
    /// Monete attualmente raccotte dal giocatore
    /// </summary>
    int CoinsCollected = 0;
    public Text CoinText;
    public Slider CoinSlider;
    GameObject PortaF;
    WindowGeneric UI_WG;
    

    /// <summary>
    /// Stato di vincita
    /// </summary>
    bool IsWinning = false;

    /// <summary>
    /// Stato di pausa del gioco.
    /// </summary>
    public bool IsGamePaused = false;
    

	// Use this for initialization
	void Start () {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        MaxCoins = coins.Length;
        UpdateCoinUI();
        PortaF = GameObject.Find("PortaFinale");
        UI_WG = FindObjectOfType<WindowGeneric>();


    }

    // Update is called once per frame
    void Update () {

	}
    

    /// <summary>
    /// Aggiorna il valore del TextCoin
    /// </summary>
    void UpdateCoinUI() {
        CoinText.text = CoinsCollected.ToString() + "/" + MaxCoins.ToString();
        float sliderNewValue = (float)CoinsCollected / (float)MaxCoins;
        CoinSlider.value = sliderNewValue;
        // Controllo il valore della slider
        if (sliderNewValue <= 0.3f) {
            // rosso
            CoinSlider.fillRect.gameObject.GetComponent<Image>().color = Color.red;
        } else if (sliderNewValue > 0.3f && sliderNewValue <= 0.7f) {
            // giallo
            CoinSlider.fillRect.gameObject.GetComponent<Image>().color = Color.yellow;
        } else {
            // verde
            CoinSlider.fillRect.gameObject.GetComponent<Image>().color = Color.green;
        }
    }

    #region API
    /// <summary>
    /// Settala variabile di vittoria(IsWinning) a true
    /// </summary>
    public void DoWin() {
        IsWinning = true;
        UI_WG.DisplayText("Hai Vinto", true);        
    }

    /// <summary>
    /// Incrementa il contatore delle monete raccolte dal player
    /// </summary>
    public void AddCoins() {
        CoinsCollected = CoinsCollected + 1;
        if (CoinsCollected == MaxCoins) {
            PortaF.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        UpdateCoinUI();
    }

    /// <summary>
    /// Mette in pausa il gioco.
    /// </summary>
    public void PauseGame() {
        if (IsGamePaused == true) {
            // Sono già in pausa
            IsGamePaused = false;
            UI_WG.Display(false);
            Time.timeScale = 1f;
        } else {
            // non sono in pausa
            IsGamePaused = true;
            UI_WG.DisplayTextWithBackToMain("Pause", true);
            Time.timeScale = 0f;
        }
        
    }

    public void BackToMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
