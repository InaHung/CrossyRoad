using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : IPoolable
{
    public float moveSpeed; 
    float originMoveSpeed;
    private void Awake()
    {
        originMoveSpeed = moveSpeed;
    }
    protected void Update()
    {
        CarMove();
    }

    public void CarMove()
    {
        transform.position += new Vector3(moveSpeed, 0, 0);

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "barrier")
        {
            moveSpeed = originMoveSpeed;
            Dispose();

        }

    }

}
