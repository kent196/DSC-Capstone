using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float volumeValue;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    
    void Update()
    {
        audioMixer.SetFloat("volume", volumeValue);
        PlayerPrefs.SetFloat("volume", volumeValue);
    }
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        volumeValue = volume;
    }
    public void PauseGame()
    {
        GameManager.gameManager.PauseGame();
    }

    public void ResumeGame()
    {
        GameManager.gameManager.ResumeGame();
    }

    public void MainMenu()
    {
        GameManager.gameManager.Menu();
    }

    public void RestartGame()
    {
        GameManager.gameManager.Restart();
    }

    public void ExitToMenu()
    {
        GameManager.gameManager.ExitToMenu();
    }

    public void ConfirmYes()
    {
        GameManager.gameManager.ConfirmYes();
    }

    public void ConfirmNo()
    {
        GameManager.gameManager.ConfirmNo();

    }


}
