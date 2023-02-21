using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private GameMaster gameMaster;
    private GameManager gamemanager;
    public void StartGame()
    {
        gameMaster = FindObjectOfType<GameMaster>();
        if(gameMaster!=null)
        {
            Destroy(gameMaster);
        }
        
        Debug.Log("start");
        SceneManager.LoadScene("Map");
        Time.timeScale = 1f;
    }
}
