using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommuterCollision : MonoBehaviour
{

	public GameObject PopUpCanvas;

	//private Transform playerTransform;
	private CameraShake camShakey;
    private Transform playerRotation;
	// Use this for initialization
	void Start ()
	{
		//playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		camShakey = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		playerRotation = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
	}

	private void OnCollisionEnter(Collision other)
	{
		
		if (other.collider.CompareTag("Player"))
		{
			GameObject popUp = Instantiate(PopUpCanvas, transform.position,Quaternion.Euler(new Vector3(0f,playerRotation.rotation.y,0f)));
			camShakey.SubwayShaking = true;
		}
	}
}
