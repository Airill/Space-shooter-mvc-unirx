using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelView : MonoBehaviour
{
    public UI_LevelController ui_LevelController { get; set; }
    // Start is called before the first frame update
    public GameObject menuLevelFail;
    public GameObject menuLevelComplete;

  //  [HideInInspector]
    public GameObject menuLevelCompleteRef;

  //  [HideInInspector]
    public GameObject menuLevelFailRef;

    public void Start() {
        menuLevelFailRef.SetActive(false);
        menuLevelCompleteRef.SetActive(false);
    }
}
