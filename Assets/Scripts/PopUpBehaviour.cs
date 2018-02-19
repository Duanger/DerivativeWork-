using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBehaviour : MonoBehaviour {

	// Use this for initialization
	private CanvasRenderer popUpCanvasRenderer;
	private Text popUpImage;
	private Transform playerLookTransform;
	void Start ()
	{
		popUpImage = GetComponent<Text>();
		popUpCanvasRenderer = GetComponent<CanvasRenderer>();
		playerLookTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
		Vector3 playerDirection = playerLookTransform.position - transform.position;
		playerDirection.x = 0;
		playerDirection.z = 0;
		transform.LookAt(playerLookTransform.position - playerDirection);
		transform.Rotate(0,180,0);
		StartCoroutine(PopUpFade());
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position += transform.up * 0.01f;
	}

	IEnumerator PopUpFade()
	{
		popUpImage.CrossFadeAlpha(0,3,false);
		if (popUpCanvasRenderer.GetAlpha() == 0)
		{
			Destroy(gameObject);
		}
		yield return null;
	}
}
