using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : MonoBehaviour
{
    protected string sceneName = "Game";

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerDamageReceiver")
        {
            SaveManager.Instance.SaveGame();
            EnemySpawnerCtrl.Instance.EnemySpawnerRandom.randomLimit = 1;
            transform.position = new Vector3(0, 20, 0);
            StateGameCtrl.nextLevel = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
