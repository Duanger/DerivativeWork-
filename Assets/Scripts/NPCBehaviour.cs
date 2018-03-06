using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour
{

    private AudioSource _typingSource;
    private GameManager _gameManager;
    
    private UICanvasManager overlayManager;

    public bool RunnedDown;
    public bool MadeAChoice;
    public int CurrentChoiceIndex;
    public int NPCNumber;
    public GameObject OverlayUIGameObject;
    [TextArea(1,3)]
    public string IntroductoryText;
    [TextArea(1,3)]
    public string[] ConversationText;
    public string[] ChoiceOne;
    public string[] ChoiceTwo;
    public GameObject ConvoText;
    public GameObject First;
    public GameObject Second;
    [HideInInspector]public Text ConversationalTextComp;
    [HideInInspector]public Text FirstChoiceTextComp;
    [HideInInspector]public Text SecondChoiceTextComp;
    

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        ConversationalTextComp = ConvoText.GetComponent<Text>();
        _typingSource = ConvoText.GetComponent<AudioSource>();
        FirstChoiceTextComp = First.GetComponentInChildren<Text>();
        SecondChoiceTextComp = Second.GetComponentInChildren<Text>();
        OverlayUIGameObject.SetActive(false);
    }

    void Update()
    {
            if (_gameManager.NpcRaycastHitted[NPCNumber])
            {
                if (Input.GetKey(KeyCode.E))
                {
                    _gameManager.NpcInteracted[NPCNumber] = true;
                    _gameManager.CurrentInteractedNPC = NPCNumber;
                        OverlayUIGameObject.SetActive(true);
                    EnterNPC();

                }
            }
    }

    void EnterNPC()
    {
        if (!RunnedDown && _gameManager.NpcInteracted[NPCNumber])
        {
            StartCoroutine(reiterateDescriptionText(IntroductoryText, ConversationalTextComp, FirstChoiceTextComp, SecondChoiceTextComp,
                ChoiceOne[0], ChoiceOne[1], CurrentChoiceIndex));
        }
    }

    
    public IEnumerator reiterateDescriptionText(string descriptionText,Text descriptionTextObj, Text firstText, Text secondText, string firstNPCString,
        string secondNPCString, int choiceNumber)
    {
        descriptionTextObj.text = "";
        firstText.text = "";
        secondText.text = "";
        //descriptionTextObj.text = descriptionText;
        RunnedDown = true;
        foreach (char letter in descriptionText.ToCharArray())
        {
            descriptionTextObj.text += letter;
            _typingSource.PlayOneShot(_typingSource.clip);
            yield return new WaitForSeconds(0.09f);
        }

        if (descriptionTextObj.text == ConversationText[choiceNumber]|| descriptionTextObj.text == IntroductoryText)
        {
            //finishedRunning = true;
            First.SetActive(true);
            Second.SetActive(true);
            firstText.text = "";
            secondText.text = "";
            firstText.text = firstNPCString;
            secondText.text = secondNPCString;
            RunnedDown = false;
            StopCoroutine(reiterateDescriptionText(descriptionText, descriptionTextObj, firstText, secondText,
             firstNPCString, secondNPCString, choiceNumber));
        }
    }
}



