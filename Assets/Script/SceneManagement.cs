using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public UIManager uIManager;
   public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        uIManager.endGameObject.SetActive(false);
    }
}
