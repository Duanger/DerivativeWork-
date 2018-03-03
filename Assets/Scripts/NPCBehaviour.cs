using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCBehaviour : MonoBehaviour
{
    private GameManager _gameManager;
    private UICanvasManager overlayManager;

    public int NPCNumber;
    public GameObject OverlayUIGameObject;
    [TextArea(1,3)]
    public string IntroductoryText;
    [TextArea(1,3)]
    public string[] ConversationText;
    public string[] ChoiceOne;
    public string[] ChoiceTwo;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        overlayManager = OverlayUIGameObject.GetComponent<UICanvasManager>();
        OverlayUIGameObject.SetActive(false);
    }

    void Update()
    {
            if (_gameManager.NpcRaycastHitted[NPCNumber])
            {
                if (Input.GetKey(KeyCode.E))
                {
                    _gameManager.NpcInteracted[NPCNumber] = true;
                    OverlayUIGameObject.SetActive(true);
                    overlayManager.EnteringNPC(NPCNumber);
                }
            }
    }
}



