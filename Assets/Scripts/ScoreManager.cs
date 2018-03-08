using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public float ColoringInDuration;
	public Color ColorDefault;
	public Color FinalColor;
	public AudioSource[] VictorySphereAudio = new AudioSource[5];
	public GameObject[] VictorySphere = new GameObject[5];

	//private float _floatAlone;
	private bool _runOnce;
	private Renderer[] VictoryRenderers = new Renderer[5];
	private GameManager _gameMan;
	void Start ()
	{
		_gameMan = GetComponent<GameManager>();
		for (int i = 1; i < 5; i++)
		{
			VictoryRenderers[i] = VictorySphere[i].GetComponent<Renderer>();
			VictoryRenderers[i].material.color = ColorDefault;
			VictorySphereAudio[i] = VictorySphere[i].GetComponent<AudioSource>();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
			if (_gameMan.NpcWon[_gameMan.RecentWonIndex] && !_runOnce)
			{
				if (VictoryRenderers[_gameMan.RecentWonIndex].material.color != FinalColor)
				{
					StartCoroutine(LerpColor(VictoryRenderers
						[_gameMan.RecentWonIndex],VictorySphereAudio[_gameMan.RecentWonIndex]));
				}
			}
	}

 IEnumerator LerpColor(Renderer rend,AudioSource audioSource)
 {
	 _runOnce = true;
	 float timeElapsed = 0;
	 rend.material.color = ColorDefault;
	 while (timeElapsed < 1)
	 {
		 timeElapsed += Time.deltaTime / ColoringInDuration;
		 rend.material.color = Color.Lerp(ColorDefault, FinalColor, timeElapsed);
		 yield return null;
	 }

	 if (rend.material.color == FinalColor)
	 {
		 audioSource.PlayOneShot(audioSource.clip);
		 _runOnce = false;
		 StopCoroutine(LerpColor(rend,audioSource));
	 }	
	}
}
