using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject confirmBox;
    [SerializeField] public GameObject gui;
    private PopUpSystem popUpSystem;

    private void Start()
    {
        pauseMenu = FindObjectOfType<Canvas>().transform.Find("PauseMenu").gameObject;
        pauseMenu.SetActive(false);
        confirmBox = FindObjectOfType<Canvas>().transform.Find("ConfirmBox").gameObject;
        confirmBox.SetActive(false);
        gui = FindObjectOfType<Canvas>().transform.Find("GUI").gameObject;
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
        gui.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gui.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ExitToMenu()
    {
        confirmBox.SetActive(true);
    }

    public void ConfirmYes()
    {
        SceneManager.LoadScene(0);
    }

    public void ConfirmNo()
    {
        confirmBox.SetActive(false);
    }
}
