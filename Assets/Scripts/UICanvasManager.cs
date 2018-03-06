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

   
   /* public void FirstChoicePressed()
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
    }*/

    
}