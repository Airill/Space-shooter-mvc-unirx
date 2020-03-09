using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelController : MonoBehaviour
{
    public UI_LevelView ui_LevelView { get; set; }
    
    public void LevelFail() {
        ui_LevelView.menuLevelFailRef.SetActive(true);
    }

    public void UiButtonRestart() {
        if (ui_LevelView.menuLevelFailRef) {
            ui_LevelView.menuLevelFailRef.SetActive(false);
        }
        Debug.Log("Level restart");
    }
    	
    public void LevelComplete() {
        ui_LevelView.menuLevelCompleteRef.SetActive(true);
    }
    


    public void UiButtonMap() {
				Debug.Log("Map");
    }

    public void SetLivesText(int lives) {
        ui_LevelView.textLives.text = ("Lives: " + lives.ToString());
    }
}
