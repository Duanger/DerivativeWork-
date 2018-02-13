using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerLook : MonoBehaviour {

    [HideInInspector] public float mouseSense = 2.0f;

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

        float mouseRotX = m_xPos * mouseSense;
        float mouseRotY = m_yPos * mouseSense;

        m_xClamp -= mouseRotY;

        Vector3 m_targetRot = transform.rotation.eulerAngles;
        Vector3 m_targetRotBody = m_PlayerController.transform.rotation.eulerAngles;

        m_targetRot.x -= mouseRotY;
        m_targetRot.z = 0;
        m_targetRotBody.y += mouseRotX;

        if(m_xClamp > 90)
        {
            m_xClamp = 90;
            m_targetRot.x = 90;
        }
        else if(m_xClamp < -90)
        {
            m_xClamp = -90;
            m_targetRot.x = 270;
        }
        m_PlayerController.transform.rotation = Quaternion.Euler(m_targetRotBody);
    }
}
