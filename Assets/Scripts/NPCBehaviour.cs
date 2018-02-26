﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private UICanvasManager overlayManager;

    public int NPCNumber;
    public bool FirstNPCEntered;
    public bool SecondNPCEntered;
    public bool ThirdNPCEntered;
    public bool FourthNPCEntered;
    public GameObject OverlayUIGameObject;
    public string[] ConversationText = new string[3];
    public string[] ChoiceOne = new string[2];
    public string[] ChoiceTwo = new string[2];

    void Start()
    {
        overlayManager = OverlayUIGameObject.GetComponent<UICanvasManager>();
        OverlayUIGameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //overlayUIGameObject.SetActive(true);
            if (NPCNumber == 1)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    OverlayUIGameObject.SetActive(true);
                    FirstNPCEntered = true;
                    overlayManager.EnteringNPCOne();
                }
            }

            if (NPCNumber == 2)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    OverlayUIGameObject.SetActive(true);
                    SecondNPCEntered = true;
                    overlayManager.EnteringNPCTwo();
                }
            }

            if (NPCNumber == 3)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    ThirdNPCEntered = true;
                    //overlayManager.EnteringNPCThree();
                }
            }

            if (NPCNumber == 4)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    FourthNPCEntered = true;
                    //overlayManager.EnteringNPCFour();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OverlayUIGameObject.SetActive(false);
            if (NPCNumber == 1)
            {
                FirstNPCEntered = false;
            }

            if (NPCNumber == 2)
            {
                SecondNPCEntered = false;
            }

            if (NPCNumber == 3)
            {
                ThirdNPCEntered = false;
            }

            if (NPCNumber == 4)
            {
                FourthNPCEntered = false;
            }
        }
    }
}