using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScreen : MonoBehaviour {

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
