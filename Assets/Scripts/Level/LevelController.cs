using System.Collections;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public LevelModel levelModel { get; set; }
    public LevelView levelView { get; set; }

    public GameObject asteroidPrefab;
    public ReactiveCollection<GameObject> asteroids = new ReactiveCollection<GameObject>(); 
    App app;
    GlobalControl gc;
    public LevelData currentLvl;


    void Start() {
        app = FindObjectOfType<App>();
        gc = FindObjectOfType<GlobalControl>();
        currentLvl = gc.GetSelectedLevel();

        app.playerFactory.playerModel.lives 
        .ObserveEveryValueChanged(l => l.Value) 
        .Subscribe(l => { 
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
        currentLvl.asteroidsLeft = currentLvl.asteroids;
        curLvl.inProgress = true;
        app.ui_LevelFactory.ui_LevelController.SetAsteridsLeft(currentLvl.asteroidsLeft);
        levelView.StartLevel();
    }
     
    public void LevelFail() {
        currentLvl.inProgress = false;
        app.ui_LevelFactory.ui_LevelController.LevelFail();
    }

    public void LevelComplete() {
        currentLvl.inProgress = false;
        currentLvl.isCompleted = true;
        app.ui_LevelFactory.ui_LevelController.LevelComplete();
        gc.SaveGame();
    }

    public void GoToMap() {
        SceneManager.LoadScene(0);
    }
    
    public void PlayerDie() {
        levelView.FailLevel();
    }           

    public void OnAsteroidDestroy() {
        currentLvl.asteroidsLeft--;
        app.ui_LevelFactory.ui_LevelController.SetAsteridsLeft(currentLvl.asteroidsLeft);
        if ((currentLvl.asteroidsLeft <= 0) && (currentLvl.inProgress)) {
            levelView.CompleteLevel();
        } 
    }

    public void OnAsteroidSpawn(GameObject av) {
        av.transform.parent = levelView.transform; 
    }

    public void OnProjectileSpawn(GameObject pr) {
           pr.transform.parent = app.weaponFactory.weaponView.transform; 
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
