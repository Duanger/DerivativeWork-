using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{

	private GameObject overlayUIGameObject;

	public int NPCNumber;
	public bool FirstNPCEntered;
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
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			overlayUIGameObject.SetActive(false);
			FirstNPCEntered = false;
		}
	}
}
