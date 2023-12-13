using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ObjectSpawner : MonoBehaviour
{
    
    public ObjectPool objectPool;
    public string objectPoolName;
    public float rotationY;
    MoveObject moveObject;
    Tween spawnTween;
    public float moveDirection;

    private void Awake()
    {
        if (objectPool == null && !string.IsNullOrEmpty(objectPoolName))
        {
            objectPool = GameObject.Find(objectPoolName).GetComponent<ObjectPool>();
        }
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
              moveObject.gameObject.transform.position = transform.position;
              moveObject.DisposeMyself();


          });
        spawnTween.OnComplete(() =>
        {
            VehicleSpawn();

        });
        
       
    }
    public void DisposeMoveObject()
    {

    }
    private void OnDestroy()
    {
        if (spawnTween != null)
        {
            spawnTween.Kill();
        }
    }

}
