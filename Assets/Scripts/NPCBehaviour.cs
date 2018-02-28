using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCBehaviour : MonoBehaviour
{
    private GameManager _gameManager;
    private UICanvasManager overlayManager;

    public int NPCNumber;
    public GameObject OverlayUIGameObject;
    public string[] ConversationText = new string[3];
    public string[] ChoiceOne = new string[2];
    public string[] ChoiceTwo = new string[2];

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        overlayManager = OverlayUIGameObject.GetComponent<UICanvasManager>();
        OverlayUIGameObject.SetActive(false);
    }

    void Update()
    {
        for (int i = 1; i < _gameManager.NpcRaycastHitted.Length; i++)
        {
            if (_gameManager.NpcRaycastHitted[i])
            {
                if (Input.GetKey(KeyCode.E))
                {
                    _gameManager.NpcInteracted[i] = true;
                    OverlayUIGameObject.SetActive(true);
                    overlayManager.NPCEntered(i);
                }
            }
        }
    }
}



