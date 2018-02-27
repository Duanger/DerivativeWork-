using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasManager : MonoBehaviour
{
    private AudioSource descriptiveAudioSource;
    private bool reitRunOnce;
    private bool finishedRunning;
    private int npcNumero;
    private string descriptiveText;
    private playerLook playLooker;
    private NPCBehaviour[] npcBehaviours = new NPCBehaviour[4];
    private NPCBehaviour firstNPCBehave;
    private NPCBehaviour secondNPCBehave;
   
    public GameObject[] NPC = new GameObject[4]; 
    public Text DescriptiveText;
    public Text FirstChoice;
    public Text SecondChoice;

    void Start()
    {
        for (int i = 1; i < npcBehaviours.Length; i++)
        {
            npcBehaviours[i] = NPC[i].GetComponent<NPCBehaviour>();
        }
        descriptiveAudioSource = GetComponentInChildren<AudioSource>();
        descriptiveText = DescriptiveText.text;
        DescriptiveText.text = descriptiveText;
        DescriptiveText.text = "";
        FirstChoice.enabled = false;
        SecondChoice.enabled = false;
    }

    public void NPCEntered(int npcNum)
    {
        if (!reitRunOnce && npcBehaviours[1].FirstNPCEntered ||!reitRunOnce && npcBehaviours[2].SecondNPCEntered 
         || !reitRunOnce && npcBehaviours[3].ThirdNPCEntered || !reitRunOnce && npcBehaviours[4].FourthNPCEntered)
        {
            npcNumero = npcNum;
            StartCoroutine(reiterateDescriptionText(npcBehaviours[npcNum], descriptiveText, DescriptiveText, FirstChoice, SecondChoice,
                npcBehaviours[npcNum].ChoiceOne, npcBehaviours[npcNum].ChoiceTwo, 0));
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
        if (npcBehaviours[1].FirstNPCEntered || npcBehaviours[2].SecondNPCEntered
                                             || npcBehaviours[3].ThirdNPCEntered || npcBehaviours[4].FourthNPCEntered)
        {
            if (FirstChoice.text != npcBehaviours[npcNumero].ChoiceOne[1])
            {
                DescriptiveText.text = "";
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = npcBehaviours[npcNumero].ChoiceOne[1];
                StartCoroutine(reiterateDescriptionText(npcBehaviours[npcNumero], descriptiveText, DescriptiveText,
                    FirstChoice, SecondChoice, npcBehaviours[npcNumero].ChoiceOne, npcBehaviours[npcNumero].ChoiceTwo,
                    1));
            }
            else if (FirstChoice.text == npcBehaviours[npcNumero].ChoiceOne[1])
            {
                npcBehaviours[1].FirstNPCEntered = false;
                npcBehaviours[2].SecondNPCEntered = false;
                npcBehaviours[3].ThirdNPCEntered = false;
                npcBehaviours[4].FourthNPCEntered = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void SecondChoicePressed()
    {
        if (npcBehaviours[1].FirstNPCEntered || npcBehaviours[2].SecondNPCEntered
                                             || npcBehaviours[3].ThirdNPCEntered || npcBehaviours[4].FourthNPCEntered)
        {
            if (FirstChoice.text != npcBehaviours[npcNumero].ChoiceTwo[1])
            {
                DescriptiveText.text = "";
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = npcBehaviours[npcNumero].ConversationText[2];
                StartCoroutine(reiterateDescriptionText(npcBehaviours[npcNumero],descriptiveText, DescriptiveText, FirstChoice,
                    SecondChoice,
                    npcBehaviours[npcNumero].ChoiceOne, npcBehaviours[npcNumero].ChoiceTwo, 1));
            }
        }
        else if (SecondChoice.text == npcBehaviours[npcNumero].ChoiceTwo[1])
        {
            npcBehaviours[1].FirstNPCEntered = false;
            npcBehaviours[2].SecondNPCEntered = false;
            npcBehaviours[3].ThirdNPCEntered = false;
            npcBehaviours[4].FourthNPCEntered = false;
            gameObject.SetActive(false);
        }
    }

    public IEnumerator reiterateDescriptionText(NPCBehaviour npcBehave,string descriptionText,Text descriptionTextObj, Text firstText, Text secondText, string[] firstNPCString,
        string[] secondNPCString, int choiceNumber)
    {
        reitRunOnce = true;
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
            firstText.enabled = true;
            secondText.enabled = true;
            firstText.text = firstNPCString[choiceNumber];
            secondText.text = secondNPCString[choiceNumber];
            finishedRunning = true;
            StopCoroutine(reiterateDescriptionText(npcBehave,descriptionText, descriptionTextObj, firstText, secondText,
                firstNPCString, secondNPCString, choiceNumber));
        }
    }
}