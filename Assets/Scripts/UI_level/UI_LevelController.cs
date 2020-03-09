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
    }
    	
    public void LevelComplete() {
        ui_LevelView.menuLevelCompleteRef.SetActive(true);
    }
 
    public void UiButtonMap() {
    }

    public void SetLivesText(int lives) {
        ui_LevelView.textLives.text = ("Lives: " + lives.ToString());
    }

    public void SetAsteridsLeft(int asLeft) {
        ui_LevelView.textMission.text = ("Mission: avoid or kill " + asLeft.ToString() + " asteroids");
    }
}
