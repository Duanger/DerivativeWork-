using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private playerLook _playerLook;
    private playerController _playerController;
    private UICanvasManager _canvas;

    public bool[] NpcRaycastHitted = new bool [5];
    public bool[] NpcInteracted = new bool [5];


    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        _playerLook = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var npcInteracted in NpcInteracted)
        {
            if (npcInteracted)
            {
                _playerLook.DisableMouseLook();
                _playerController.StopWalking();
            }

            if (!npcInteracted)
            {
                _playerLook.EnableMouseLook();
                _playerController.RestartWalking();
            }
        }
        
  
    }
}

