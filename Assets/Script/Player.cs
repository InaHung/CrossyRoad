using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public float moveUpDistance;
    public float moveRightDistance;
    public Action OnPlayerMove;
    public Action OnGetScore;
    public PlayerSensor playerSensorRight;
    public PlayerSensor playerSensorLeft;
    public PlayerSensor playerSensorUP;
    public PlayerSensor playerSensorDown;
    private Transform myParent;
    public UIManager uIManager;
    float farPoint;
    float i = 0;
    private void Awake()
    {
        myParent = transform.parent;
    }


    void Update()
    {
       
        PlayerMove();
       
       
       
    }
    void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)&& playerSensorRight.canPass)
        {
                transform.position += new Vector3(moveRightDistance, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerSensorLeft.canPass)
        {
            transform.position -= new Vector3(moveRightDistance, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerSensorUP.canPass)
        {
            transform.position += new Vector3(0, 0, moveUpDistance);
            GetPoint();
            OnPlayerMove();
           
        }
       if (Input.GetKeyDown(KeyCode.DownArrow) && playerSensorDown.canPass)
        {
            transform.position -= new Vector3(0, 0, moveUpDistance);
           

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
       if( collision.gameObject.tag == "barrier"|| collision.gameObject.tag == "dieCollider")
        {
            uIManager.EndGame();
            transform.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "wood")
        {
            transform.position = collision.gameObject.GetComponent<Wood>().GetNearPosition(transform.position);
            transform.SetParent(collision.transform);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.tag == "moveObject" || collision.gameObject.tag == "CameraCollider"||collision.gameObject.tag=="tree")
        {
            uIManager.EndGame();
            transform.gameObject.SetActive(false);
        }
       if(collision.gameObject.tag=="riverPlane")
        {
            transform.position = collision.transform.position;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "wood")
        {

            transform.SetParent(myParent);

        }
    }
    public void GetPoint()
    {
       
        farPoint = transform.position.z;
        if (farPoint > i)
        {
            OnGetScore();
            i=farPoint;
        }
           
    }
       
}
