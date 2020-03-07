﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LevelView : MonoBehaviour
{
    public LevelModel levelModel { get; set; }
    public LevelController levelController { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        var app = FindObjectOfType<App>();
        var playerFactory = app.GetComponentInChildren<PlayerFactory>();

        playerFactory.playerModel.lives // ReactiveProperty lives
      .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
      .Where(x => x <= 0)
      .Subscribe(_ => { // подписываемся
          levelController.LevelFail();
      }).AddTo(this);
    }


    public void GenerateLevel(int currentLevel) {
        Debug.Log("level generated;");
    }
    
    public void CompleteLevel() {
        Debug.Log("Completelevel!");
    }

    public void FailLevel() {

    }
}