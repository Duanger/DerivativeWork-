using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float CurrentGameplayTime;
	private CameraShake camShake;
	private playerController PlayerController;
	void Start ()
	{
		PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
		camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		CurrentGameplayTime += Time.deltaTime;
		if (camShake.SubwayShaking)
		{
			PlayerController.PlayerStandstill = true;
		}
		else
		{
			PlayerController.PlayerStandstill = false;
		}
	}
}
