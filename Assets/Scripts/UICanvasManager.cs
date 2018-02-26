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
    private string descriptiveText;
    private playerLook playLooker;
    private NPCBehaviour firstNPCBehave;
    private NPCBehaviour secondNPCBehave;
   

    
    public GameObject FirstNPC;
    public GameObject SecondNPC; 
    public string[] FirstNPChoice1 = new string[2];
    public string[] FirstNPChoice2 = new string[2];
    public string[] SecondNPChoice1 = new string[3];
    public string[] SecondNPChoice2 = new string[3];
    public Text DescriptiveText;
    public Text FirstChoice;
    public Text SecondChoice;

    void Start()
    {
        firstNPCBehave = FirstNPC.GetComponent<NPCBehaviour>();
        secondNPCBehave = SecondNPC.GetComponent<NPCBehaviour>();
        descriptiveAudioSource = GetComponentInChildren<AudioSource>();
        descriptiveText = DescriptiveText.text;
        DescriptiveText.text = descriptiveText;
        DescriptiveText.text = "";
        FirstChoice.enabled = false;
        SecondChoice.enabled = false;
    }

    // Update is called once per frame
    public void EnteringNPCOne()
    {
        if (firstNPCBehave.FirstNPCEntered && !reitRunOnce)
        {
            bool stringEquated = false;
            if (!stringEquated)
            {
                StartCoroutine(reiterateDescriptionText(firstNPCBehave,descriptiveText, DescriptiveText, FirstChoice,
                    SecondChoice,firstNPCBehave.ChoiceOne, firstNPCBehave.ChoiceTwo, 0));
            }
        }
    }

    public void EnteringNPCTwo()
    {
        if (secondNPCBehave.SecondNPCEntered && !reitRunOnce)
        {
            bool stringEquated = false;
            if (!stringEquated)
            {
                descriptiveText = secondNPCBehave.ConversationText[0];
                StartCoroutine(reiterateDescriptionText(secondNPCBehave,descriptiveText, DescriptiveText, FirstChoice,
                    FirstChoice, secondNPCBehave.ChoiceOne, secondNPCBehave.ChoiceTwo, 0));
            }
        }
        if (reitRunOnce && finishedRunning)
        {
            if (!secondNPCBehave.SecondNPCEntered)
            {
                reitRunOnce = false;
                finishedRunning = false;
            }
        }
    }
   
    public void FirstChoicePressed()
    {
        if (FirstChoice.text != firstNPCBehave.ChoiceOne[1])
        {
            if (firstNPCBehave.FirstNPCEntered)
            {
                DescriptiveText.text = "";
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = firstNPCBehave.ConversationText[1];
                StartCoroutine(reiterateDescriptionText(firstNPCBehave,descriptiveText, DescriptiveText, FirstChoice,SecondChoice,
                    firstNPCBehave.ChoiceOne, firstNPCBehave.ChoiceTwo, 1));
            }
        }
        else if (FirstChoice.text == firstNPCBehave.ChoiceOne[1])
        {
            firstNPCBehave.FirstNPCEntered = false;
            gameObject.SetActive(false);
        }
        if (FirstChoice.text != secondNPCBehave.ChoiceOne[1])
        {
            if (secondNPCBehave.FirstNPCEntered)
            {
                DescriptiveText.text = "";
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = secondNPCBehave.ConversationText[1];
                StartCoroutine(reiterateDescriptionText(secondNPCBehave,descriptiveText, DescriptiveText, FirstChoice,SecondChoice,
                    secondNPCBehave.ChoiceOne, secondNPCBehave.ChoiceTwo, 1));
            }
        }
        else if (FirstChoice.text == secondNPCBehave.ChoiceOne[1])
        {
            firstNPCBehave.FirstNPCEntered = false;
            gameObject.SetActive(false);
        } 
    }

    public void SecondChoicePressed()
    {
        if (SecondChoice.text != firstNPCBehave.ChoiceTwo[1])
        {
            if (firstNPCBehave.FirstNPCEntered)
            {
                DescriptiveText.text = "";
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = firstNPCBehave.ConversationText[2];
                StartCoroutine(reiterateDescriptionText(firstNPCBehave,descriptiveText, DescriptiveText, FirstChoice,
                    SecondChoice,
                    firstNPCBehave.ChoiceOne, firstNPCBehave.ChoiceTwo, 1));
            }
        }
        else if (SecondChoice.text == firstNPCBehave.ChoiceTwo[1])
        {
            firstNPCBehave.FirstNPCEntered = false;
            gameObject.SetActive(false);
        }
        if (SecondChoice.text != secondNPCBehave.ChoiceTwo[1])
        {
            if (secondNPCBehave.SecondNPCEntered)
            {
                DescriptiveText.text = "";
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = secondNPCBehave.ConversationText[2];
                StartCoroutine(reiterateDescriptionText(firstNPCBehave,descriptiveText, DescriptiveText, FirstChoice,
                    SecondChoice,
                    secondNPCBehave.ChoiceOne, secondNPCBehave.ChoiceTwo, 1));
            }
        }
        else if (SecondChoice.text == secondNPCBehave.ChoiceTwo[1])
        {
            secondNPCBehave.FirstNPCEntered = false;
            gameObject.SetActive(false);
        }
    }

    private IEnumerator reiterateDescriptionText(NPCBehaviour npcBehave,string descriptionText,Text descriptionTextObj, Text firstText, Text secondText, string[] firstNPCString,
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