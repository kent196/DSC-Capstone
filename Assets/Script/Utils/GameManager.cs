using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public HealthStats playerHealth;
    public HealthStats spiderHealth;
    public static bool GameIsPaused = false;
    public static bool GameHasEnded = false;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject confirmBox;
    [SerializeField] public GameObject gui;
    [SerializeField] private GameObject endMenu;



    private void Awake()
    {
        playerHealth = new HealthStats(1000, 1000);
        spiderHealth = new HealthStats(50, 50);
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }




    private void Start()
    {
        pauseMenu = FindObjectOfType<Canvas>().transform.Find("PauseMenu").gameObject;
        pauseMenu.SetActive(false);
        confirmBox = FindObjectOfType<Canvas>().transform.Find("ConfirmBox").gameObject;
        confirmBox.SetActive(false);
        gui = FindObjectOfType<Canvas>().transform.Find("GUI").gameObject;
        endMenu = FindObjectOfType<Canvas>().transform.Find("EndMenu").gameObject;
        endMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        HandlePauseGame();
    }

    public void HandlePauseGame()
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
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
    }

    public void ConfirmYes()
    {
        SceneManager.LoadScene(0);
    }

    public void ConfirmNo()
    {
        confirmBox.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            Time.timeScale = 0f;
            GameHasEnded = true;
            endMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        playerHealth = new HealthStats(1000, 1000);
        Time.timeScale = 1f;
        GameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        {

            GameHasEnded = false;
            SceneManager.LoadScene("Start");
        }
    }
}