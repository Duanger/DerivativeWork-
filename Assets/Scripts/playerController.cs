using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	private CharacterController playerCharacterController;
    [HideInInspector] public int walkingSpeed = 4;
 
	void Awake () {
        playerCharacterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerMoves();
	}
    public void playerMoves()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 sideMoveVector = transform.right * horizontalInput * walkingSpeed;
        Vector3 zMoveVector = transform.forward * verticalInput * walkingSpeed;
        playerCharacterController.SimpleMove(sideMoveVector);
        playerCharacterController.SimpleMove(zMoveVector);
    
    }
  
}
