using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public GameObject boss;
    public GameObject portal;

    void Start() {
        boss.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Death Barrier") {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(gameObject);
            LevelManager.instance.StartCoroutine(LevelManager.instance.Respawn());
        } else if(coll.gameObject.name == "Next Level") {
            Debug.Log("Next Level");
            NextLevel();
        } else if(coll.gameObject.name == "Boss Trigger") {
            BossSpawn();
        } 
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void BossSpawn() {
        boss.SetActive(true);
        Destroy(portal);
    }
}
