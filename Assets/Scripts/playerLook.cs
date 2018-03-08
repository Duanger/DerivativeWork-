using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerLook : MonoBehaviour {

    public float mouseSense = 200f;
    public float RayCastDistance;
    public GameObject ProtoTypeNPC;
    public GameObject ProtoTypeNPC2;
    public GameObject ProtoTypeNPC3;
    public GameObject ProtoTypeNPC4;
    public bool LeftSpawnerHit;
    public bool RightSpawnerHit;

    private float m_xClamp = 0.0f;
    private NPCBehaviour NPCBehave1;
    private NPCBehaviour NPCBehave2;
    private NPCBehaviour NPCBehave3;
    private NPCBehaviour NPCBehave4;
    private GameManager _gameManager;
    private GameObject m_PlayerController;
    private Transform _playerTrans;

	// Use this for initialization
	void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
	}
    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        _playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        NPCBehave1 = ProtoTypeNPC.GetComponent<NPCBehaviour>();
        NPCBehave2 = ProtoTypeNPC2.GetComponent<NPCBehaviour>();
        NPCBehave3 = ProtoTypeNPC3.GetComponent<NPCBehaviour>();
        NPCBehave4 = ProtoTypeNPC4.GetComponent<NPCBehaviour>();
        //NPCBehave3 = ProtoTypeNPC3.GetComponent<NPCBehaviour>();
        //NPCBehave4 = ProtoTypeNPC4.GetComponent<NPCBehaviour>()
    }

    // Update is called once per frame
    void Update () {
        camMouseRot();
        RaycastSpawning();
	}
    void camMouseRot()
    {
        float m_xPos = Input.GetAxis("Mouse X");
        float m_yPos = Input.GetAxis("Mouse Y");

        Vector3 playerTargetRot = _playerTrans.transform.rotation.eulerAngles;

       transform.Rotate(-m_yPos * Time.deltaTime * mouseSense, m_xPos * Time.deltaTime * mouseSense, 0f);
        Vector3 clampRot = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0f);
        transform.eulerAngles = clampRot;

        m_xClamp -= transform.rotation.eulerAngles.y;
        playerTargetRot.x -= transform.rotation.eulerAngles.x;

        if (m_xClamp > 90)
        {
            m_xClamp = 90;
            playerTargetRot.x = 90;
        }
        else if (m_xClamp < -90)
        {
            m_xClamp = -90;
            playerTargetRot.x = 270;
        }
    }
    public void DisableMouseLook()
    {
            mouseSense = 0f;
    }

    public void EnableMouseLook()
    {
            mouseSense = 200f;
    }

    void RaycastSpawning()
    {
        var commuterRaycastHit = new RaycastHit();
        int commuterLayerMask = LayerMask.GetMask("Commuters");
        Debug.DrawRay(transform.position,transform.forward, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out commuterRaycastHit, RayCastDistance,commuterLayerMask))
        {
            for (int i = 1; i < _gameManager.NpcRaycastHitted.Length; i++)
            {
                if (commuterRaycastHit.collider.gameObject.GetComponent<NPCBehaviour>().NPCNumber == i)
                {
                    _gameManager.NpcRaycastHitted[i] = true;
                }
            }
        }
        else if(!Physics.Raycast(transform.position, transform.forward, out commuterRaycastHit, RayCastDistance,commuterLayerMask))
        {
            for (int i = 1; i < _gameManager.NpcRaycastHitted.Length; i++)
            {
                    _gameManager.NpcRaycastHitted[i] = false;
            }
        }
    }
}
