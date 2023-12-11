using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectSpawner : MonoBehaviour
{
    public Vector3 spawnPosition;
    public ObjectPool objectPool;
    public float rotationY;
    MoveObject moveObject;
    Tween spawnTween;
    public float moveDirection;
    private void Awake()
    {
       
        VehicleSpawn();
       
    }
    private void Update()
    {
      
    }
    void VehicleSpawn()
    {
        spawnTween = DOVirtual.DelayedCall(Random.Range(2f, 5f), () =>
          {
              moveObject = objectPool.GetObject() as MoveObject;
              moveObject.moveSpeed = moveObject.moveSpeed * moveDirection;
              moveObject.gameObject.transform.eulerAngles = new Vector3(0, rotationY, 0);
              moveObject.gameObject.transform.position = spawnPosition;
          });
        spawnTween.OnComplete(() =>
        {
            VehicleSpawn();

        });

    }
    private void OnDestroy()
    {
        if(spawnTween!=null)
        {
            spawnTween.Kill();
        }
    }

}
