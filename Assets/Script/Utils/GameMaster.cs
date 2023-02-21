using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos = new Vector2(-46.7f, 192.4f);
    public float playerHealth = 100f;
    private ObeliskController[] obelisks;
    // data to save and load
    private Vector2 playerPos;
    void Awake(){
        if(instance == null){
            instance = this;
            PlayerPrefs.DeleteAll();
            DontDestroyOnLoad(instance);

        }else{
            Destroy(gameObject);
        }
        LoadGame();
    }

    public void SaveGame()
    {
        Debug.Log(lastCheckPointPos);
        SavePlayerData();
        SaveObelisksData();
        
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        Debug.Log("Load");
        LoadPlayerData();
        LoadObelisksData();  
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetFloat("lastCheckPointPosX", lastCheckPointPos.x);
        PlayerPrefs.SetFloat("lastCheckPointPosY", lastCheckPointPos.y);

        PlayerPrefs.SetFloat("PlayerHealth", playerHealth);
    }

    public void LoadPlayerData()
    {
        float lastCheckPointPosX = PlayerPrefs.GetFloat("lastCheckPointPosX", -46.7f);
        float lastCheckPointPosY = PlayerPrefs.GetFloat("lastCheckPointPosY", 192.4f);
        lastCheckPointPos = new Vector2(lastCheckPointPosX, lastCheckPointPosY);

        playerHealth = PlayerPrefs.GetFloat("PlayerHealth", 100f);
    }

    private void SaveObelisksData()
    {
        obelisks = FindObjectsOfType<ObeliskController>();
        foreach (ObeliskController obelisk in obelisks)
        {
            bool isActivated = obelisk.IsActivated;
            // Debug.Log("S: "+isActivated);
            PlayerPrefs.SetInt(obelisk.name, isActivated ? 1 : 0);
        }
    }
    private void LoadObelisksData()
    {
        obelisks = FindObjectsOfType<ObeliskController>();
        foreach (ObeliskController obelisk in obelisks)
        {
            int isActivated = PlayerPrefs.GetInt(obelisk.name);
            // Debug.Log("L: "+isActivated);
            obelisk.IsActivated = PlayerPrefs.GetInt(obelisk.name, 0) == 1;
        }
    }
}
