using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : MonoBehaviour
{
    public LevelController levelController { get; private set; }
    public LevelModel levelModel { get; private set; }
    public LevelView levelView { get; private set; }

    // Start is called before the first frame update
    void Awake() {

        levelController = GetComponentInChildren<LevelController>();
        levelModel = new LevelModel();
        levelController.levelModel = levelModel;
        levelView = GetComponentInChildren<LevelView>();
        levelController.levelView = levelView;
        levelView.levelModel = levelModel;
    }
}
