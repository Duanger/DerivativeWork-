using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondChoiceBehaviour : MonoBehaviour {

	
	private GameManager _gameManager;
	private NPCBehaviour[] _npcBehaviours = new NPCBehaviour[5];
	private Text thisText;
	private Text otherText;
	
	public GameObject[] CommuterPeople;
	public GameObject OvertChoice;
	public GameObject CanvasOverlay;
	void Start ()
	{
		thisText = GetComponentInChildren<Text>();
		otherText = OvertChoice.GetComponentInChildren<Text>();
		for (int i = 1; i < _npcBehaviours.Length;i++)
		{
			_npcBehaviours[i] = CommuterPeople[i].GetComponent<NPCBehaviour>();
		}

		_gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
	}
	public void SecondChoiceClicked()
	{
		if (!_npcBehaviours[_gameManager.CurrentInteractedNPC].RunnedDown && !_npcBehaviours[_gameManager.CurrentInteractedNPC].MadeAChoice)
		{
			thisText.text = "";
			otherText.text = "";
			StartCoroutine(_npcBehaviours[_gameManager.CurrentInteractedNPC].reiterateDescriptionText(_npcBehaviours[_gameManager.CurrentInteractedNPC].ConversationText[1],
				_npcBehaviours[_gameManager.CurrentInteractedNPC].ConversationalTextComp, _npcBehaviours[_gameManager.CurrentInteractedNPC].FirstChoiceTextComp,
				_npcBehaviours[_gameManager.CurrentInteractedNPC].SecondChoiceTextComp, _npcBehaviours[_gameManager.CurrentInteractedNPC].ChoiceTwo[0], 
				_npcBehaviours[_gameManager.CurrentInteractedNPC].ChoiceTwo[1],
				1));
			_npcBehaviours[_gameManager.CurrentInteractedNPC].MadeAChoice = true;

		}
		if (!_npcBehaviours[_gameManager.CurrentInteractedNPC].RunnedDown &&
		    _npcBehaviours[_gameManager.CurrentInteractedNPC].MadeAChoice)
		{
			_gameManager.NpcInteracted[_gameManager.CurrentInteractedNPC] = false;
			_gameManager.CurrentInteractedNPC = 0;
			CanvasOverlay.SetActive(false);
		}
	}
}
