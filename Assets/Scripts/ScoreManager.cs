﻿using System.Collections;
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
	
			if (_gameMan.NpcWon[_gameMan.RecentWonIndex])
			{				
				LerpColor(VictoryRenderers[_gameMan.RecentWonIndex]);
			}
		
	}

 void LerpColor(Renderer rend)
	{
		_floatAlone += Time.deltaTime / ColoringInDuration;
		rend.material.color = Color.Lerp(ColorDefault, FinalColor, 1f);
	}
}
