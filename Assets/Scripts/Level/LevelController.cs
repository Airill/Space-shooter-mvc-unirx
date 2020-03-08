using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LevelController : MonoBehaviour
{
    public LevelModel levelModel { get; set; }
    public LevelView levelView { get; set; }

    public GameObject asteroidPrefab;
    public ReactiveCollection<GameObject> asteroids = new ReactiveCollection<GameObject>(); //for Unirx
    App app;


    void Start() {
        app = FindObjectOfType<App>();

        LevelStart();




        app.playerFactory.playerModel.lives // ReactiveProperty movement
          .ObserveEveryValueChanged(l => l.Value) // отслеживаем изменения в нем
          .Subscribe(l => { // подписываемся
               if (l <= 0) {
                  PlayerDie();
              }
          }).AddTo(this);
    }

    public void LevelStart() {
       levelModel.score = levelModel.score_base;
        StartCoroutine(SpawnAsteroids()); 
    }

 
           
    public void levelRestart() {
        levelView.GenerateLevel(levelModel.currentLevel);
    }

    public void LevelGenerate() {
        Debug.Log("LevelGenerate");
/*
        var num = (int)p_data[0];
        var cur_lvl = m.data;
        var base_lbl = m.data_base;
        var coef = m.genCoef_base;

        // Level generating formulas
        m.currentLevel = num;
        cur_lvl.asteroids = (int)(base_lbl.asteroids + base_lbl.asteroids * Mathf.Pow(num, 2) / coef);
        cur_lvl.asteroidSpeedMultiplier = base_lbl.asteroidSpeedMultiplier + num / coef;
        cur_lvl.asteroidSpawnDelay = base_lbl.asteroidSpawnDelay - num / coef;
        cur_lvl.levelStartDelay = base_lbl.levelStartDelay;

        cur_lvl.asteroidsLeft = cur_lvl.asteroids;
        cur_lvl.inProgress = true;
        v.StartLevel();*/
    }
     
    public void LevelFail() {
        levelModel.data.inProgress = false;
        app.ui_LevelFactory.ui_LevelController.LevelFail();
        Debug.Log("LevelFail");

    }
    public void LevelComplete() {
        Debug.Log("levelController.LevelComplete");
        levelModel.data.inProgress = false;
        app.ui_LevelFactory.ui_LevelController.LevelComplete();
    }
    
    public void PlayerDie() {
        levelView.FailLevel();
    }           

    public void OnAsteroidDestroy() {
        Debug.Log(levelModel.data.asteroidsLeft);
        levelModel.data.asteroidsLeft--;
        Debug.Log(levelModel.data.asteroidsLeft);
        if (levelModel.data.asteroidsLeft <= 0) {
            levelView.CompleteLevel();
        } 
    }

    public void OnAsteroidSpawn(GameObject av) {
        //move view to view Parent

        av.transform.parent = levelView.transform; 
    }

    public void OnProjectileSpawn() {
        //move view to view Parent
        /*   var pr = (ProjectileView)p_target;
           pr.transform.parent = v.transform; */
    }

    private IEnumerator SpawnAsteroids() {

        yield return new WaitForSeconds(levelModel.data.levelStartDelay);
        for (int i = 0; i < levelModel.data.asteroids; i++) {
            if (levelModel.data.inProgress) {
                UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(Random.Range(-levelModel.spawnValues.x, levelModel.spawnValues.x), levelModel.spawnValues.y, levelModel.spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                var aster = Instantiate(asteroidPrefab, spawnPosition, spawnRotation) as GameObject;
                asteroids.Add(aster);
                aster.GetComponentInChildren<AsteroidController>().OnSpawn();

                yield return new WaitForSeconds(levelModel.data.asteroidSpawnDelay);
            }
            else {
                foreach (var a in asteroids) {
                    Destroy(a);
                }
                break;
            }
        }
    }
}
