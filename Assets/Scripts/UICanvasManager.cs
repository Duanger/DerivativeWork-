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
	private NPCBehaviour NPCBehave;

	public AudioSource DescriptiveAudioSource;
	public GameObject NPC;
	public string[] FirstNPChoice1 = new string[2];
	public string[] FirstNPChoice2 = new string[2];
	public Text DescriptiveText;
	public Text FirstNPChoiceText1;
	public Text FirstNPChoiceText2;
	void Start ()
	{
		NPCBehave = NPC.GetComponent<NPCBehaviour>();
		descriptiveText = DescriptiveText.text;
		DescriptiveText.text = descriptiveText;
		descriptiveText = "You are a piece of shit!";
		FirstNPChoiceText1.enabled = false;
		FirstNPChoiceText2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (NPCBehave.FirstNPCEntered & !reitRunOnce)
		{
				StartCoroutine(reiterateDescriptionText(descriptiveText,DescriptiveText,FirstNPChoiceText1,FirstNPChoiceText2,
					FirstNPChoice1,FirstNPChoice2,0));
		}

		if (reitRunOnce && finishedRunning)
		{
			if (!NPCBehave.FirstNPCEntered)
			{
				reitRunOnce = false;
				finishedRunning = false;
			}
		}
	}

	public void FirstChoicePressed()
	{
		DescriptiveText.text = "";
		descriptiveText = DescriptiveText.text;
		DescriptiveText.text = descriptiveText;
		if (NPCBehave.FirstNPCEntered)
		{
			FirstNPChoiceText1.enabled = false;
			FirstNPChoiceText2.enabled = false;
			descriptiveText = "Good. Your highly inflated sens- I mean self is not here";
			StartCoroutine(reiterateDescriptionText(descriptiveText,DescriptiveText,FirstNPChoiceText1,FirstNPChoiceText2,
				FirstNPChoice1,FirstNPChoice2,1));
		}
		
	}

	public void SecondChoicePressed()
	{
		FirstNPChoiceText1.enabled = false;
		FirstNPChoiceText2.enabled = false;
		DescriptiveText.text = "";
		descriptiveText = DescriptiveText.text;
		DescriptiveText.text = descriptiveText;
	}
	private IEnumerator reiterateDescriptionText(string descriptionText,
		Text descriptionTextObj,Text firstText,Text secondText,string[] firstNPCString,
		string[] secondNPCString,int choiceNumber)
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
			StopCoroutine(reiterateDescriptionText(descriptionText,descriptionTextObj,firstText,secondText,
				firstNPCString,secondNPCString,choiceNumber));
		}
	}
}
