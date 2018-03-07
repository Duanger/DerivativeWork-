using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private playerLook _playerLook;
    private playerController _playerController;
    private UICanvasManager _canvas;

    public int CurrentInteractedNPC;
    public int RecentWonIndex;
    public bool[] NpcRaycastHitted = new bool [5];
    public bool[] NpcInteracted = new bool [5];
    public bool[] NpcWon = new bool[5];

    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        _playerLook = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerLook>();
    }

    void FixedUpdate()
    {
        foreach (var npcInteracted in NpcInteracted)
        {
            if (npcInteracted)
            {
                _playerLook.DisableMouseLook();
                _playerController.StopWalking();
            }
        }

        for (int i = 1; i < 6; i++)
        {
            if (!NpcInteracted[i])
            {
                _playerLook.EnableMouseLook();
                _playerController.RestartWalking();
            }
        }

    }
}

