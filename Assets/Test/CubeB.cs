using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("B Trigger");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("B Collision");
    }
}
