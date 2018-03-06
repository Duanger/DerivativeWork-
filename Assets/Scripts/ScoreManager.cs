using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public float ColoringInDuration;
	public Color ColorDefault;
	public Color FinalColor;
	public GameObject[] VictorySphere = new GameObject[5];

	private float _floatAlone;
	private Renderer[] VictoryRenderers = new Renderer[5];
	private GameManager _gameMan;
	void Start ()
	{
		_gameMan = GetComponent<GameManager>();
		for (int i = 1; i < 5; i++)
		{
			VictoryRenderers[i] = VictorySphere[i].GetComponent<Renderer>();
			VictoryRenderers[i].material.color = ColorDefault;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach (var npcWonIt in _gameMan.NpcWon)
		{
			if (npcWonIt)
			{
				foreach (var vicSphererend in VictoryRenderers)
				{
					_floatAlone += Time.deltaTime / ColoringInDuration;
					vicSphererend.material.color = Color.Lerp(ColorDefault, FinalColor, Time.deltaTime * _floatAlone);
				}
			}
		}
	}
}
