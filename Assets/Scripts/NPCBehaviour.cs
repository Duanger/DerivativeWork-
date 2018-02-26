using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{

	private GameObject overlayUIGameObject;

	public int NPCNumber;
	public bool FirstNPCEntered;
	public bool SecondNPCEntered;
	public bool ThirdNPCEntered;
	public bool FourthNPCEntered;
	void Start () {
		overlayUIGameObject = GameObject.FindGameObjectWithTag("Overlay");
		overlayUIGameObject.SetActive(false);
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if(Input.GetKey(KeyCode.E))
			{
				overlayUIGameObject.SetActive(true);
				if (NPCNumber == 1)
				{
					FirstNPCEntered = true;
				}
				if (NPCNumber == 2)
				{
					SecondNPCEntered = true;
				}

				if (NPCNumber == 3)
				{
					ThirdNPCEntered = true;
				}

				if (NPCNumber == 4)
				{
					FourthNPCEntered = true;
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			overlayUIGameObject.SetActive(false);
			if (NPCNumber == 1)
			{
				FirstNPCEntered = false;
			}
			if (NPCNumber == 2)
			{
				SecondNPCEntered = false;
			}

			if (NPCNumber == 3)
			{
				ThirdNPCEntered = false;
			}

			if (NPCNumber == 4)
			{
				FourthNPCEntered = false;
			}
		}
	}
}
