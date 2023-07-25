using UnityEngine;

public class WormHole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SaveManager.Instance.SaveGame();
            transform.position = new Vector3(0, 20, 0);
            UILevel.Instance.Toggle();
            
        }
    }
}
