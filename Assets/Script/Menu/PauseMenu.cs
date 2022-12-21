using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu = FindObjectOfType<Canvas>().transform.Find("PauseMenu").gameObject;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Debug.Log("Resume");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Debug.Log("Pause");
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
