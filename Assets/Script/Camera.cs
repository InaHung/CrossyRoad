using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class Camera : MonoBehaviour
{

    public Player player;
    public float moveSpeed;
    public float leaveDistance;
    bool isCatching;
    Tween catchUpTween;

    private void Awake()
    {
        player.OnPlayerMove += CatchUpPlayer;
    }

    private void Update()
    {

        if (isCatching == false)
        {
            transform.position += new Vector3(0, 0, moveSpeed);
            CatchUpPlayer();
        }




    }
    public void CatchUpPlayer()
    {

        if (player.transform.position.z - transform.position.z > leaveDistance)
        {
            if (catchUpTween!=null)
            {
                catchUpTween.Kill();
            }
            Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - leaveDistance);
            catchUpTween = transform.DOLocalMove(playerPosition, 2f);
            isCatching = true;

            catchUpTween.OnComplete(() =>
            {
                isCatching = false;
            });
           

        }



    }
    private void OnDestroy()
    {
        if (catchUpTween != null)
        {
            catchUpTween.Kill();
        }
    }



}
