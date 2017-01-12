using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WindowGeneric : MonoBehaviour {

    public Text TestoVittoria;
    public Image VictoryScreen;
    public Button BackToMainButton;

    // Use this for initialization
    void Start () {
        
    }
	
    public void Display(bool _active) {
        TestoVittoria.enabled = _active;
        VictoryScreen.enabled = _active;
        if(_active == false)
            BackToMainButton.gameObject.SetActive(_active);
    }

    /// <summary>
    /// Change text value and show
    /// </summary>
    /// <param name="_testo"> text to display</param>
    /// <param name="_show"> true == display</param>
    public void DisplayText(string _testo, bool _show) {
        TestoVittoria.text = _testo;
        Display(_show);        
    }

    /// <summary>
    /// Change text value and show with back menu button.
    /// </summary>
    /// <param name="_testo"></param>
    /// <param name="_show"></param>
    public void DisplayTextWithBackToMain(string _testo, bool _show) {
        DisplayText(_testo, _show);
        BackToMainButton.gameObject.SetActive(_show);
    }
}
