using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private RaycastHit ray;
    [SerializeField] private float rayCastDistance = 1f;


    private bool isMoving;
    public GameObject PreDash;
    public GameObject DashParent;
    public LayerMask collisionLayer;
    public static PlayerMove instance;
    public Vector3 moveDirection;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        if (isMoving)
        {
            Move();
        }
    }
    private void Swipe()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector3.right;
        }
        // kiem tra va cham
        Ray ray = new Ray(transform.position, moveDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayCastDistance, collisionLayer))
        {
            Debug.Log(1);
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    // di chuyen 
    private void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
    // pick gach
    public void PickDash(GameObject dash)
    {
        Debug.Log("A");
        dash.transform.SetParent(DashParent.transform);
        Vector3 pos = PreDash.transform.localPosition;
        pos.y -= 0.0207f;
        dash.transform.localPosition = pos;
        Vector3 CharPostion = transform.localPosition;
        CharPostion.y += 0.0207f;
        transform.localPosition = CharPostion;
        PreDash = dash;
        PreDash.GetComponent<BoxCollider>().isTrigger = false;
    }
}


