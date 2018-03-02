using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasManager : MonoBehaviour
{
    private AudioSource descriptiveAudioSource;
    [SerializeField]private bool reitRunOnce;
    private bool finishedRunning;
    private int npcNumero;
    private string descriptiveText;
    private Text firstChoice;
    private Text secondChoice;
    private playerLook playLooker;
    private GameManager _gameManager;
    private NPCBehaviour[] npcBehaviours = new NPCBehaviour[4];

   
    public GameObject[] NPC = new GameObject[4];
    public int ChoiceNumber;
    public GameObject FirstChoice;
    public GameObject SecondChoice;
    public Text DescriptiveText;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        firstChoice = FirstChoice.GetComponentInChildren<Text>();
        secondChoice = SecondChoice.GetComponentInChildren<Text>();
        for (int i = 1; i < npcBehaviours.Length; i++)
        {
            npcBehaviours[i] = NPC[i].GetComponent<NPCBehaviour>();
        }

        descriptiveAudioSource = GetComponentInChildren<AudioSource>();
        descriptiveText = DescriptiveText.text;
        DescriptiveText.text = descriptiveText;
        DescriptiveText.text = "";
        FirstChoice.SetActive(false);
        SecondChoice.SetActive(false);
    }

    public void NPCEntered(int npcNum)
    {
        if (!reitRunOnce && _gameManager.NpcInteracted[npcNum])
        {
            npcNumero = npcNum;
            StartCoroutine(reiterateDescriptionText(npcBehaviours[npcNum], descriptiveText, DescriptiveText, firstChoice, secondChoice,
                npcBehaviours[npcNum].ChoiceOne, npcBehaviours[npcNum].ChoiceTwo, ChoiceNumber));
            reitRunOnce = true;
        }
        /*if (reitRunOnce && finishedRunning)
        {
            if (!firstNPCBehave.FirstNPCEntered)
            {
                reitRunOnce = false;
                finishedRunning = false;
            }
        }*/

    }
   
   
    public void FirstChoicePressed()
    {
        
            if (firstChoice.text != npcBehaviours[npcNumero].ChoiceOne[ChoiceNumber])
            {
                DescriptiveText.text = "";
                descriptiveText = npcBehaviours[npcNumero].ChoiceOne[ChoiceNumber];
                StartCoroutine(reiterateDescriptionText(npcBehaviours[npcNumero], descriptiveText, DescriptiveText,
                    firstChoice, secondChoice, npcBehaviours[npcNumero].ChoiceOne, npcBehaviours[npcNumero].ChoiceTwo,
                    1));
            }
            else if (firstChoice.text == npcBehaviours[npcNumero].ChoiceOne[npcNumero])
            {
                _gameManager.NpcInteracted[npcNumero] = false;
                gameObject.SetActive(false);
            }
        
    }

    public void SecondChoicePressed()
    {
       
            if (secondChoice.text != npcBehaviours[npcNumero].ChoiceTwo[ChoiceNumber])
            {
                DescriptiveText.text = "";
                descriptiveText = npcBehaviours[npcNumero].ConversationText[2];
                StartCoroutine(reiterateDescriptionText(npcBehaviours[npcNumero],descriptiveText, DescriptiveText, firstChoice,
                    secondChoice,
                    npcBehaviours[npcNumero].ChoiceOne, npcBehaviours[npcNumero].ChoiceTwo, ChoiceNumber));
            }
        
        else if (secondChoice.text == npcBehaviours[npcNumero].ChoiceTwo[1])
        {
            _gameManager.NpcInteracted[npcNumero] = false;
            gameObject.SetActive(false);
        }
    }

    public IEnumerator reiterateDescriptionText(NPCBehaviour npcBehave,string descriptionText,Text descriptionTextObj, Text firstText, Text secondText, string[] firstNPCString,
        string[] secondNPCString, int choiceNumber)
    {
        descriptionText = npcBehave.ConversationText[choiceNumber];
        foreach (char letter in descriptionText.ToCharArray())
        {
            descriptionTextObj.text += letter;
            descriptiveAudioSource.PlayOneShot(descriptiveAudioSource.clip);
            yield return 0;
            yield return new WaitForSeconds(0.09f);
        }

        if (descriptionTextObj.text == npcBehave.ConversationText[choiceNumber])
        {
            finishedRunning = true;
            EnableChoiceText(npcBehave,FirstChoice,SecondChoice,firstChoice,secondChoice,choiceNumber);
            ChoiceNumber++;
            StopCoroutine(reiterateDescriptionText(npcBehave,descriptionText, descriptionTextObj, firstText, secondText,
                firstNPCString, secondNPCString, choiceNumber));
        }
    }

    private void EnableChoiceText(NPCBehaviour npcBehaviour, GameObject choice1, GameObject choice2, Text choice1Text,Text choice2Text, int choiceNumber)
    {
        if (finishedRunning)
        {
            choice1.SetActive(true);
            choice2.SetActive(true);
            choice1Text.text = npcBehaviour.ChoiceOne[choiceNumber];
            choice2Text.text = npcBehaviour.ChoiceTwo[choiceNumber];
            finishedRunning = false;
        }
    }
}