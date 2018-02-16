using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerLook : MonoBehaviour {

    public float mouseSense = 200f;

    private float m_xClamp = 0.0f;
    
    private GameObject m_PlayerController;

	// Use this for initialization
	void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
	}
    private void Start()
    {
        m_PlayerController = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        camMouseRot();
	}
    void camMouseRot()
    {
        float m_xPos = Input.GetAxis("Mouse X");
        float m_yPos = Input.GetAxis("Mouse Y");


       transform.Rotate(-m_yPos * Time.deltaTime * mouseSense, m_xPos * Time.deltaTime * mouseSense, 0f);
       
      Vector3 clampRot = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,0f);
      transform.eulerAngles = clampRot;
    }
}
