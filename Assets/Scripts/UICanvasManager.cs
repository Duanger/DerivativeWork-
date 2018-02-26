using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasManager : MonoBehaviour
{
    private bool reitRunOnce;
    private bool deleteRunOnce;
    private bool finishedRunning;
    private string descriptiveText;
    private playerLook playLooker;
    private NPCBehaviour firstNPCBehave;
    private NPCBehaviour secondNPCBehave;

    public AudioSource DescriptiveAudioSource;
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
        descriptiveText = DescriptiveText.text;
        DescriptiveText.text = descriptiveText;
        FirstChoice.enabled = false;
        SecondChoice.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstNPCBehave.FirstNPCEntered && !reitRunOnce)
        {
            descriptiveText = "";
            descriptiveText = "You are a piece of shit!";
            StartCoroutine(reiterateDescriptionText(descriptiveText, DescriptiveText, FirstChoice,
                SecondChoice,
                FirstNPChoice1, FirstNPChoice2, 0));
        }

        if (reitRunOnce && finishedRunning)
        {
            if (!firstNPCBehave.FirstNPCEntered)
            {
                reitRunOnce = false;
                finishedRunning = false;
            }
        }

        if (secondNPCBehave.SecondNPCEntered && !reitRunOnce)
        {
            descriptiveText = "";
            descriptiveText = "Yo yo I'm a pole-tergeist.";
            StartCoroutine(reiterateDescriptionText(descriptiveText, DescriptiveText, FirstChoice,
                FirstChoice, SecondNPChoice1, SecondNPChoice2, 0));
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
        if (FirstChoice.text != FirstNPChoice1[1])
        {
            if (firstNPCBehave.FirstNPCEntered)
            {
                DescriptiveText.text = "";
                descriptiveText = DescriptiveText.text;
                DescriptiveText.text = descriptiveText;
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = "Good. Your highly inflated sens-I mean self is not here.";
                StartCoroutine(reiterateDescriptionText(descriptiveText, DescriptiveText, FirstChoice,
                    SecondChoice,
                    FirstNPChoice1, FirstNPChoice2, 1));
            }
        }

        else if (FirstChoice.text == FirstNPChoice1[1])
        {
            gameObject.SetActive(false);
            firstNPCBehave.FirstNPCEntered = false;
        }
    }

    public void SecondChoicePressed()
    {
        if (FirstChoice.text != FirstNPChoice1[1])
        {
            if (firstNPCBehave.FirstNPCEntered)
            {
                DescriptiveText.text = "";
                descriptiveText = DescriptiveText.text;
                DescriptiveText.text = descriptiveText;
                FirstChoice.enabled = false;
                SecondChoice.enabled = false;
                descriptiveText = "Believe what you want buddy, I calls it as I sees it.";
                StartCoroutine(reiterateDescriptionText(descriptiveText, DescriptiveText, FirstChoice,
                    SecondChoice,
                    FirstNPChoice1, FirstNPChoice2, 1));
            }
        }
        else if (FirstChoice.text == FirstNPChoice1[1])
        {
            firstNPCBehave.FirstNPCEntered = false;
        }
    }

    private IEnumerator reiterateDescriptionText(string descriptionText,
        Text descriptionTextObj, Text firstText, Text secondText, string[] firstNPCString,
        string[] secondNPCString, int choiceNumber)
    {
        reitRunOnce = true;
        foreach (char letter in descriptionText.ToCharArray())
        {
            descriptionTextObj.text += letter;
            DescriptiveAudioSource.PlayOneShot(DescriptiveAudioSource.clip);
            yield return 0;
            yield return new WaitForSeconds(0.09f);
        }

        if (descriptionTextObj.text == descriptiveText)
        {
            firstText.enabled = true;
            secondText.enabled = true;
            firstText.text = firstNPCString[choiceNumber];
            secondText.text = secondNPCString[choiceNumber];
            finishedRunning = true;
            StopCoroutine(reiterateDescriptionText(descriptionText, descriptionTextObj, firstText, secondText,
                firstNPCString, secondNPCString, choiceNumber));
        }
    }
}