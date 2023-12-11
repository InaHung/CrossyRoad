using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public float moveUpDistance;
    public float moveRightDistance;
    public Action OnPlayerMove;
    public PlayerSensor playerSensorRight;
    public PlayerSensor playerSensorLeft;
    public PlayerSensor playerSensorUP;
    public PlayerSensor playerSensorDown;
    private Transform myParent;
    
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
            OnPlayerMove();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && playerSensorDown.canPass)
        {
            transform.position -= new Vector3(0, 0, moveUpDistance);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag=="wood")
        {
            transform.position = collision.GetComponent<Wood>().GetNearPosition(transform.position);
            transform.SetParent(collision.transform);
            
        }
        if(collision.tag=="barrier")
        {

        }
       
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "wood")
        {
           
            transform.SetParent(myParent);

        }
    }
}
