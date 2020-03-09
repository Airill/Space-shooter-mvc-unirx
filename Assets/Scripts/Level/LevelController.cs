using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public LevelModel levelModel { get; set; }
    public LevelView levelView { get; set; }

    public GameObject asteroidPrefab;
    public ReactiveCollection<GameObject> asteroids = new ReactiveCollection<GameObject>(); //for Unirx
    App app;
    GlobalControl gc;
    public LevelData currentLvl;


    void Start() {
        app = FindObjectOfType<App>();
        gc = FindObjectOfType<GlobalControl>();
        currentLvl = gc.GetSelectedLevel();

        app.playerFactory.playerModel.lives // ReactiveProperty movement
  .ObserveEveryValueChanged(l => l.Value) // отслеживаем изменения в нем
  .Subscribe(l => { // подписываемся
              if (l <= 0) {
          PlayerDie();
      }
  }).AddTo(this);

        LevelGenerate(currentLvl);
    }

    public void LevelStart() {
        StartCoroutine(SpawnAsteroids()); 
    }

 
           
    public void levelRestart() {
        currentLvl.asteroidsLeft = currentLvl.asteroids;
        levelView.GenerateLevel(currentLvl);
        app.playerFactory.playerController.PlayerRessurect();

    }

    public void LevelGenerate(LevelData curLvl) {


        // var num = (int)p_data[0];

        // var base_lbl = m.data_base;
        // var coef = m.genCoef_base;

        // Level generating formulas
        // m.currentLevel = num;
        /*
         curLvl.asteroids = (int)(base_lbl.asteroids + base_lbl.asteroids * Mathf.Pow(num, 2) / coef);
         curLvl.asteroidSpeedMultiplier = base_lbl.asteroidSpeedMultiplier + num / coef;
         curLvl.asteroidSpawnDelay = base_lbl.asteroidSpawnDelay - num / coef;
         curLvl.levelStartDelay = base_lbl.levelStartDelay;

         curLvl.asteroidsLeft = cur_lvl.asteroids; */
        currentLvl.asteroidsLeft = currentLvl.asteroids;
        curLvl.inProgress = true;
        levelView.StartLevel(); //command levelView to start
        Debug.Log("LevelGenerated");
    }
     
    public void LevelFail() {
        currentLvl.inProgress = false;
        app.ui_LevelFactory.ui_LevelController.LevelFail();
        Debug.Log("LevelFail");

    }
    public void LevelComplete() {
        Debug.Log("levelController.LevelComplete");
        currentLvl.inProgress = false;
        currentLvl.isCompleted = true;
        app.ui_LevelFactory.ui_LevelController.LevelComplete();
    }

    public void GoToMap() {
        SceneManager.LoadScene(0);
    }
    
    public void PlayerDie() {
        levelView.FailLevel();
    }           

    public void OnAsteroidDestroy() {
        Debug.Log(currentLvl.asteroidsLeft);
        currentLvl.asteroidsLeft--;
        Debug.Log(currentLvl.asteroidsLeft);
        if ((currentLvl.asteroidsLeft <= 0) && (currentLvl.inProgress)) {
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

        yield return new WaitForSeconds(currentLvl.levelStartDelay);
        for (int i = 0; i < currentLvl.asteroids; i++) {
            if (currentLvl.inProgress) {
                UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(Random.Range(-levelModel.spawnValues.x, levelModel.spawnValues.x), levelModel.spawnValues.y, levelModel.spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                var aster = Instantiate(asteroidPrefab, spawnPosition, spawnRotation) as GameObject;
                asteroids.Add(aster);
                aster.GetComponentInChildren<AsteroidController>().OnSpawn();

                yield return new WaitForSeconds( currentLvl.asteroidSpawnDelay);
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
