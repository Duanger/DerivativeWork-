using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
	public float FloatingSpeed;
	private Rigidbody balloonRigid;
	void Start ()
	{
		balloonRigid = GetComponent<Rigidbody>();
		balloonRigid.AddForce(balloonRigid.transform.up *Time.deltaTime * FloatingSpeed);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//balloonRigid.AddForce(balloonRigid.transform.up * FloatingSpeed);
		//balloonRigid.transform.position += balloonRigid.transform.up * Time.deltaTime * FloatingSpeed;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Roof"))
		{
			//FloatingSpeed = 0;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (other.collider.CompareTag("Roof"))
		{
			FloatingSpeed = 4;
		}
	}
}
