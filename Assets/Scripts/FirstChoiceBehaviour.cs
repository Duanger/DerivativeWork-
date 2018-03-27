using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FirstChoiceBehaviour : MonoBehaviour
{

	private GameManager _gameManager;

	private NPCBehaviour[] _npcBehaviours = new NPCBehaviour[5];
	private Text thisText;
	private Text otherText;
	private Button _thisButton;

	public int ChoiceIteratedIndex;
	public GameObject OverlayCanvas;
	public GameObject OtherChoice;
	public GameObject[] CommuterPeople;
	void Start ()
	{
		thisText = GetComponentInChildren<Text>();
		otherText = OtherChoice.GetComponentInChildren<Text>();
		_thisButton = GetComponent<Button>();
		for (int i = 1; i < _npcBehaviours.Length;i++)
		{
			_npcBehaviours[i] = CommuterPeople[i].GetComponent<NPCBehaviour>();
		}

		_gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
	}

	void Update()
	{
		if (ChoiceIteratedIndex == 2)
		{
			_gameManager.RecentWonIndex = _gameManager.CurrentInteractedNPC;
			if (_gameManager.NpcInteracted[4])
			{
				_gameManager.NpcWon[4] = true;
				CommuterPeople[4].SetActive(false);
			}
			else
			{
				_gameManager.NpcWon[_gameManager.CurrentInteractedNPC] = true;
			}
			_gameManager.NpcInteracted[_gameManager.CurrentInteractedNPC] = false;
			_gameManager.CurrentInteractedNPC = 0;
			ChoiceIteratedIndex = 0;
			OverlayCanvas.SetActive(false);
		}
		if (_npcBehaviours[3].ConversationalTextComp.text == _npcBehaviours[3].ConversationText[0] && ChoiceIteratedIndex == 1)
		{
			SceneManager.LoadScene(0);
		}
	}

	public void FirstChoiceClicked()
	{
		ChoiceIteratedIndex++;
		if (!_npcBehaviours[_gameManager.CurrentInteractedNPC].RunnedDown && !_npcBehaviours[_gameManager.CurrentInteractedNPC].MadeAChoice)
		{
			
			thisText.text = "";
			otherText.text = "";
			StartCoroutine(_npcBehaviours[_gameManager.CurrentInteractedNPC].reiterateDescriptionText(_npcBehaviours[_gameManager.CurrentInteractedNPC].ConversationText[0], 
				_npcBehaviours[_gameManager.CurrentInteractedNPC].ConversationalTextComp, _npcBehaviours[_gameManager.CurrentInteractedNPC].FirstChoiceTextComp,
				_npcBehaviours[_gameManager.CurrentInteractedNPC].SecondChoiceTextComp, _npcBehaviours[_gameManager.CurrentInteractedNPC].ChoiceTwo[0], 
				_npcBehaviours[_gameManager.CurrentInteractedNPC].ChoiceTwo[1],
				0));
		}

		/*if (_npcBehaviours[_gameManager.CurrentInteractedNPC].ConversationalTextComp.text ==
		    _npcBehaviours[_gameManager.CurrentInteractedNPC].ChoiceTwo[0])
		{
			_npcBehaviours[_gameManager.CurrentInteractedNPC].MadeAChoice = true;
		}*/
		
	}
}
