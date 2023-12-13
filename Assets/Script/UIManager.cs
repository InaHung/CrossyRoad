using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject endGameObject;
    public TextMeshProUGUI scoreText;
    public Player player;
    int score;
    private void Awake()
    {
        player.OnGetScore += GetScore;

        endGameObject.SetActive(false);
    }
    public void EndGame()
    {
        endGameObject.SetActive(true);
    }
    public void GetScore()
    {
        
            score += 1;
            scoreText.text = score.ToString();
        
      
    }
}
