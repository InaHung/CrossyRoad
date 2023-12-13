using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class Map : MonoBehaviour
{
    public Scene scene;
    float creatPosition;
    Tween createSceneTween;
    int sceneNumber;
  //  Scene newScene;
    private void Awake()
    {
        
        Scene newScene = Instantiate(scene, transform);
        newScene.onPlayerExit += CreateNewScene;
        newScene.transform.position = new Vector3(0, 0,0);
        Scene SecondScene = Instantiate(scene, transform);
        SecondScene.onPlayerExit += CreateNewScene;
        SecondScene.transform.position = new Vector3(0, 0, 300f);
       
    }
    private void Update()
    {

    }
    public void CreateNewScene()
    {
        sceneNumber += 1;
        Scene newScene = Instantiate(scene, transform);
        newScene.onPlayerExit += CreateNewScene;
        creatPosition = (sceneNumber+1) * 300;
        newScene.transform.position = new Vector3(0, 0, creatPosition);

    }

}
