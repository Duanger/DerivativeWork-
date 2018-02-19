using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private Vector3 camOrigin;

	public bool SubwayShaking;
	public float ShakeForce = 0.3f;
	public float ShakingDuration = 0f;
	
	void Start ()
	{
		camOrigin = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (SubwayShaking)
		{
			StartCoroutine(ShakeCam());
			
		}
		else
		{
			StopCoroutine(ShakeCam());
		}
	}

	IEnumerator ShakeCam()
	{
		transform.localPosition = camOrigin + Random.insideUnitSphere * ShakeForce;
		yield return new WaitForSeconds(4);
		SubwayShaking = false;
	}
}
