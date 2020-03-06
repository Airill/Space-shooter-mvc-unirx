using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory : MonoBehaviour
{
    public GameController gameController { get; private set; }
    public GameModel gameModel { get; private set; }
    public GameView gameView { get; private set; }

    // Start is called before the first frame update
    void Start() {
        this.gameController = GetComponentInChildren<GameController>();
        gameModel = new GameModel();
        gameController.gameModel = gameModel;
        gameView = GetComponentInChildren<GameView>();
        gameController.gameView = gameView;
        gameView.gameModel = gameModel;
        gameView.gameController = gameController;
    }
}
