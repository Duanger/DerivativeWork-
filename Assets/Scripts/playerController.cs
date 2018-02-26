using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

	private Rigidbody playerRigidbody;
	private NPCBehaviour NPCBehave;
	
	public bool PlayerStandstill;
	public float walkingSpeed = 2f;
	public GameObject ProtoNPC;
 
	void Awake ()
	{
		playerRigidbody = GetComponent<Rigidbody>();
		NPCBehave = ProtoNPC.GetComponent<NPCBehaviour>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerMoves();
	}
    public void playerMoves()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
	    Vector3 targetDirection = new Vector3(horizontalInput,0f,verticalInput).normalized;
	    targetDirection = Camera.main.transform.TransformDirection(targetDirection);
	  
	    playerRigidbody.MovePosition(playerRigidbody.transform.position + targetDirection *Time.deltaTime  * walkingSpeed);
	    if (NPCBehave.FirstNPCEntered)
	    {
		    walkingSpeed = 0f;
	    }
	    else
	    {
		    walkingSpeed = 4f;
	    }
	    /*if (PlayerStandstill)
	    {
		    walkingSpeed = 0f;
	    }
	    else
	    {
		    walkingSpeed = 4f;
	    }*/
    }
  
}
