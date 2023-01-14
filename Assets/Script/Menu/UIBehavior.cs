using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
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
