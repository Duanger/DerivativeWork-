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
    private GameObject m_PlayerController;

	// Use this for initialization
	void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
	}
    private void Start()
    {
        m_PlayerController = GameObject.FindGameObjectWithTag("Player");
        NPCBehave1 = ProtoTypeNPC.GetComponent<NPCBehaviour>();
        NPCBehave2 = ProtoTypeNPC2.GetComponent<NPCBehaviour>();
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


       transform.Rotate(-m_yPos * Time.deltaTime * mouseSense, m_xPos * Time.deltaTime * mouseSense, 0f);
       
      Vector3 clampRot = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,0f);
      transform.eulerAngles = clampRot;
        if (NPCBehave1.FirstNPCEntered || NPCBehave2.SecondNPCEntered || NPCBehave1.ThirdNPCEntered || NPCBehave1.FourthNPCEntered)
        {
            mouseSense = 0f;
        }
        else if(!NPCBehave1.FirstNPCEntered || !NPCBehave2.SecondNPCEntered || !NPCBehave1.ThirdNPCEntered || !NPCBehave1.FourthNPCEntered)
        {
            mouseSense = 200f;
        }
    }

    void RaycastSpawning()
    {
        var leftCommuteRaycastHit = new RaycastHit();
        var rightCommuteRaycastHit = new RaycastHit();
        int spawnerLayerMask = LayerMask.GetMask("Spawner");
        int spawnerLayerMask2 = LayerMask.GetMask("Spawner1");
        Debug.DrawRay(transform.position,transform.forward, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out rightCommuteRaycastHit, RayCastDistance,spawnerLayerMask))
        {
            RightSpawnerHit = true;
        }
        else if(!Physics.Raycast(transform.position, transform.forward, out rightCommuteRaycastHit, RayCastDistance,spawnerLayerMask))
        {
            RightSpawnerHit = false;
        }
        if (Physics.Raycast(transform.position, transform.forward, out leftCommuteRaycastHit, RayCastDistance,spawnerLayerMask2))
        {
            LeftSpawnerHit = true;
        }
        if (!Physics.Raycast(transform.position, transform.forward, out leftCommuteRaycastHit, RayCastDistance,spawnerLayerMask2))
        {
            LeftSpawnerHit = false;
        }

    }
}
