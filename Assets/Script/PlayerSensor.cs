using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public Player player;
    public Vector3 myPosition;
    public bool canPass;

    private void Awake()
    {
        canPass = true;
    }
    void Update()
    {
        transform.position = player.transform.position + myPosition;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "barrier")
            canPass = false;

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "barrier")
            canPass = true;
    }
}
