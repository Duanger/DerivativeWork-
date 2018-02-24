using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommuterBehaviour : MonoBehaviour
{

	public float SittingDuration;
	public Color DefaultColor;
	public Color TargetColor;
	
	private float currentTime;
	private GameObject playerObj;
	private Renderer communterRenderer;
	private Rigidbody communterRigid;
	
	void Start ()
	{
		communterRenderer = GetComponent<Renderer>();
		communterRigid = GetComponent<Rigidbody>();
	    playerObj = GameObject.FindGameObjectWithTag("Player");
		communterRenderer.material.color = DefaultColor;
		//Vector3 intialSpawnVelocity = new Vector3(communterRigid.transform.position.x ,0,0);
	}
	
	void FixedUpdate ()
	{
		currentTime += Time.deltaTime;
		transform.LookAt(playerObj.transform);
		communterRigid.transform.position += communterRigid.transform.forward * Time.deltaTime * 4f;
		//StartCoroutine(CommuterColoring(SittingDuration));
	}

	
	IEnumerator CommuterColoring(float sitDuration)
	{
		communterRenderer.material.color = Color.Lerp(DefaultColor, TargetColor, currentTime / sitDuration);
		if (communterRenderer.material.color == TargetColor)
		{
			communterRigid.useGravity = true;
		}
		yield return null;
		StopCoroutine(CommuterColoring(sitDuration));
	}
}
