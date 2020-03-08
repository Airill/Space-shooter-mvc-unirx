using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UI_LevelView : MonoBehaviour
{
    public UI_LevelController ui_LevelController { get; set; }
    // Start is called before the first frame update
    public GameObject menuLevelFail;
    public GameObject menuLevelComplete;
    public Text textLives;

    //  [HideInInspector]
    public GameObject menuLevelCompleteRef;

  //  [HideInInspector]
    public GameObject menuLevelFailRef;
    App app;

    public void Start() {
        app = FindObjectOfType<App>();

        menuLevelFailRef.SetActive(false);
        menuLevelCompleteRef.SetActive(false);


        var playerFactory = app.GetComponentInChildren<PlayerFactory>();

        playerFactory.playerModel.lives // ReactiveProperty lives
      .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
      .Subscribe(x => { // подписываемся
          ui_LevelController.SetLivesText(x);
      }).AddTo(this);


    }
}
