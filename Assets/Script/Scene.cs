using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Scene : MonoBehaviour
{

    public Action onPlayerExit;
    

    private void OnTriggerExit(Collider collision)
    {
      
        if (collision.tag == "CameraCollider")
        {
            Debug.Log("Exit:" + gameObject.name);
            DOVirtual.DelayedCall(5f, () =>
             {
                 Destroy(transform.gameObject);
             });

            if (onPlayerExit != null)
                onPlayerExit();
        }
    }
}
