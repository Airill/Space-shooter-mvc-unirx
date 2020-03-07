using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LevelController : MonoBehaviour
{
    public LevelModel levelModel { get; set; }
    public LevelView levelView { get; set; }

    public GameObject asteroidPrefab;
    private List<GameObject> asteroidRefs;
    App app;


    void Start() {
        app = FindObjectOfType<App>();

        StartCoroutine(SpawnAsteroids());//Убрать!




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
       // Notify(Q_Notification.UiScoreChange, new object[] { m.score });   //Notify to Ui_GameController
        StartCoroutine(SpawnAsteroids()); 
    }

   /* public void LevelNext() {
        Log("LevelNext");
        if (m.currentLevel < m.levelCount)
            v.GenerateLevel(m.currentLevel + 1); 
    }    */   
           
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
        levelModel.data.inProgress = false;
    }
    
    public void LevelLoad() {
      //  v.GenerateLevel((int)p_data[0]);
    }

    public void PlayerDie() {
        levelView.FailLevel();
        /*   if (app.model.game.state == GameState.Game) {
               v.FailLevel();
           }*/
    }           

    public void OnAsteroidDestroy() {
        levelModel.data.asteroidsLeft--;
        if (levelModel.data.asteroidsLeft <= 0) {
            levelView.CompleteLevel();
        } 
    }

    public void OnAsteroidSpawn() {
        //move view to view Parent
     /*   var pa = (AsteroidView)p_target;
        pa.transform.parent = v.transform; */
    }

    public void OnProjectileSpawn() {
        //move view to view Parent
        /*   var pr = (ProjectileView)p_target;
           pr.transform.parent = v.transform; */
    }

    public void LevelAddScore() {
    /*    var add_sc = (int)p_data[0];

        m.score += add_sc;

       // Notify(Q_Notification.UiScoreChange, new object[] { m.score }); */
    }

    private IEnumerator SpawnAsteroids() {

        yield return new WaitForSeconds(levelModel.data.levelStartDelay);
        asteroidRefs = new List<GameObject>();
        for (int i = 0; i < levelModel.data.asteroids; i++) {
            if (levelModel.data.inProgress) {
                UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(Random.Range(-levelModel.spawnValues.x, levelModel.spawnValues.x), levelModel.spawnValues.y, levelModel.spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                var aster = Instantiate(asteroidPrefab, spawnPosition, spawnRotation) as GameObject;
                asteroidRefs.Add(aster);
                ((AsteroidController)aster.GetComponentInChildren<AsteroidController>()).OnSpawn();

                yield return new WaitForSeconds(levelModel.data.asteroidSpawnDelay);
            }
            else {
                foreach (var a in asteroidRefs) {
                    Destroy(a);
                }
                break;
            }
        }
    }
}
