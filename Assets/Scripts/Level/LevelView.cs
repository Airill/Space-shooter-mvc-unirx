using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LevelView : MonoBehaviour
{
    public LevelModel levelModel { get; set; }
    public LevelController levelController { get; set; }

    void Start()
    {
        var app = FindObjectOfType<App>();
        var playerFactory = app.GetComponentInChildren<PlayerFactory>();

        playerFactory.playerModel.lives 
      .ObserveEveryValueChanged(x => x.Value) 
      .Where(x => x <= 0)
      .Subscribe(_ => { 
          levelController.PlayerDie();
      }).AddTo(this);

        levelController.asteroids.ObserveAdd()
            .Subscribe(x => {
                levelController.OnAsteroidSpawn(x.Value);
            })
            .AddTo(this);
    }

    public void GenerateLevel(LevelData currentLevel) {
        levelController.LevelGenerate(currentLevel);
    }
    
    public void CompleteLevel() {
        levelController.LevelComplete();
    }

    public void FailLevel() {
        levelController.LevelFail();
    }

    public void StartLevel() {
        levelController.LevelStart();
    }
}
