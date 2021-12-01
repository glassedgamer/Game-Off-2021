using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    private void Awake() {
        instance = this;
    }

    public IEnumerator Respawn() {
        yield return new WaitForSeconds(1f);
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
