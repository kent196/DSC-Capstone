using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;
    private GameManager gameManager;

    void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();  
        transform.position = gameMaster.lastCheckPointPos;
    }

    void Start() {
        
    }

    void Update()
    {

    }
}
