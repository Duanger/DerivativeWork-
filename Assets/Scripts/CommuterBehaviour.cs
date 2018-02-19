using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommuterBehaviour : MonoBehaviour
{

	public float SittingDuration;
	public Color DefaultColor;
	public Color TargetColor;
	
	private float currentTime;
	private Renderer communterRenderer;
	private Rigidbody communterRigid;
		
	void Start ()
	{
		communterRenderer = GetComponent<Renderer>();
		communterRigid = GetComponent<Rigidbody>();
		communterRenderer.material.color = DefaultColor;
	}
	
	void FixedUpdate ()
	{
		currentTime += Time.deltaTime;
		StartCoroutine(CommuterColoring(SittingDuration));
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
