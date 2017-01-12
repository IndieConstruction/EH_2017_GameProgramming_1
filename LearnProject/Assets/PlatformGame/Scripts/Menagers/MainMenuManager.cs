using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    #region API
    /// <summary>
    /// Play level 1.
    /// </summary>
    public void PlayLevel1() {
        SceneManager.LoadScene("Level1");
    }

    /// <summary>
    /// Play test level.
    /// </summary>
    public void PlayTestLevel() {
        SceneManager.LoadScene("TestLevel");
    } 
    #endregion
}
