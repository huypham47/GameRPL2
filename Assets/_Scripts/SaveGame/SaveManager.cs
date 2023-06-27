using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] protected static SaveManager instance;
    public static SaveManager Instance => instance;
    private const string SAVE_1 = "save_1";

    private void Awake()
    {
        if (SaveManager.instance != null) return;
        SaveManager.instance = this;
    }

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        this.LoadSaveGame();
    }

    private void OnApplicationQuit()
    {
        this.SaveGame();
    }

    protected virtual void LoadSaveGame()
    {
        string inventoryName = "Inventory";
        string playerName = "Player";
        if (StateGameCtrl.isNewGame || PlayerCtrl.Instance.PlayerDamageReceiver.Isdead)
        {
            inventoryName = "Inventory_Default";
            playerName = "Player_Default";

        }
        string jsonInventory = SaveSystem.GetString(inventoryName);
        PlayerCtrl.Instance.Inventory.InventoryFromJson(jsonInventory);

        string jsonPlayer = SaveSystem.GetString(playerName);
        PlayerData playerData = this.PlayerFromJson(jsonPlayer);
        Player.Instance.SetData(playerData);
    }

    public virtual void SaveGame()
    {
        Debug.Log("save");
        Player.Instance.LoadData();

        string jsonInventory = JsonUtility.ToJson(PlayerCtrl.Instance.Inventory);
        SaveSystem.SetString("Inventory", jsonInventory);

        string jsonPlayer = JsonUtility.ToJson(Player.Instance);
        SaveSystem.SetString("Player", jsonPlayer);
        Debug.Log(jsonPlayer);
    }

    public virtual PlayerData PlayerFromJson(string jsonString)
    {
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonString);
        return playerData;
    }
}
