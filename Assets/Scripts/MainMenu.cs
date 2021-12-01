using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Animator transition;

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits() {
        transition.SetTrigger("Credits");
    }

    public void Menu() {
        transition.SetTrigger("Menu");
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
