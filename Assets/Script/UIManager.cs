using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject endGameObject;

    // Update is called once per frame
    private void Awake()
    {
        endGameObject.SetActive(false);
    }
    void EndGame()
    {
        endGameObject.SetActive(true);
    }
}
