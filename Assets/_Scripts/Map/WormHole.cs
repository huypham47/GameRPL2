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
            transform.position = new Vector3(0, 20, 0);
            UILevel.Instance.Toggle();
            
        }
    }
}
