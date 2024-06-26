using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveObject : IPoolable
{
    public float moveSpeed;
    float originMoveSpeed;
    Tween delayDisposeTween;
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
            if (delayDisposeTween != null)
                delayDisposeTween.Kill();
        }

    }

    private void OnDestroy()
    {
        if (delayDisposeTween != null)
            delayDisposeTween.Kill();
    }

    public void DisposeMyself()
    {
        delayDisposeTween = DOVirtual.DelayedCall(10f, () =>
         {
             if (gameObject != null)
                 Dispose();


         });
    }



}
