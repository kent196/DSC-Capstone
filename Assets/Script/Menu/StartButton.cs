using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private GameManager gamemanager;
    public void StartGame()
    {
        SceneManager.LoadScene("Map");
        Time.timeScale = 1f;
    }
}
