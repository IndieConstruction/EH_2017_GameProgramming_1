using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WindowGeneric : MonoBehaviour {

    public Text TestoVittoria;
    public Image VictoryScreen;

    // Use this for initialization
    void Start () {
        
    }
	
    public void Display(bool _active) {
        TestoVittoria.enabled = _active;
        VictoryScreen.enabled = _active;
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
}
