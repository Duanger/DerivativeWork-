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
	private Renderer communterRenderer;
	private Rigidbody communterRigid;
	private NavMeshAgent commuterNavMeshAgent;
	void Start ()
	{
		communterRenderer = GetComponent<Renderer>();
		communterRigid = GetComponent<Rigidbody>();
		commuterNavMeshAgent = GetComponent<NavMeshAgent>();
		communterRenderer.material.color = DefaultColor;
		GoTo();
	}
	
	void FixedUpdate ()
	{
		
		currentTime += Time.deltaTime;
		//StartCoroutine(CommuterColoring(SittingDuration));
	}

	void GoTo()
	{
		Vector3 targetVector3 = new Vector3(0.194908f,0f,4.103632f);
		commuterNavMeshAgent.SetDestination(targetVector3);
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
