using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

	private Rigidbody playerRigidbody;
	private NPCBehaviour NPCBehave1;
	private NPCBehaviour NPCBehave2;
	private NPCBehaviour NPCBehave3;
	private NPCBehaviour NPCBehave4;
	
	public bool PlayerStandstill;
	public float walkingSpeed = 2f;
	public GameObject ProtoNPC;
	public GameObject ProtoNPC2;
	public GameObject ProtoNPC3;
	public GameObject ProtoNPC4;
 
	void Awake ()
	{
		playerRigidbody = GetComponent<Rigidbody>();
		NPCBehave1 = ProtoNPC.GetComponent<NPCBehaviour>();
		NPCBehave2 = ProtoNPC2.GetComponent<NPCBehaviour>();
		//NPCBehave3 = ProtoNPC3.GetComponent<NPCBehaviour>();
		//NPCBehave4 = ProtoNPC4.GetComponent<NPCBehaviour>();
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
	    if (NPCBehave1.FirstNPCEntered || NPCBehave2.SecondNPCEntered || NPCBehave1.ThirdNPCEntered || NPCBehave1.FourthNPCEntered)
	    {
		    walkingSpeed = 0f;
	    }
	    else if(!NPCBehave1.FirstNPCEntered || !NPCBehave2.SecondNPCEntered || !NPCBehave1.ThirdNPCEntered || !NPCBehave1.FourthNPCEntered)
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
