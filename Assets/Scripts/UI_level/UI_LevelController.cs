using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelController : MonoBehaviour
{
    public UI_LevelView ui_LevelView { get; set; }
    
    public void LevelFail() {
        ui_LevelView.menuLevelFailRef.SetActive(true);
       // if (ui_LevelView.menuLevelFailRef) {
       //  ui_LevelView.menuLevelFailRef = Instantiate(ui_LevelView.menuLevelFail, ui_LevelView.menuLevelFail.transform.position, ui_LevelView.menuLevelFail.transform.rotation) as GameObject;
       //  ui_LevelView.menuLevelFailRef.transform.SetParent(ui_LevelView.gameObject.transform.parent, false);
       //  }
    }

    public void UiButtonRestart() {
        if (ui_LevelView.menuLevelFailRef) {
            Destroy(ui_LevelView.menuLevelFailRef);
        }
        Debug.Log("Level restart");
    }
    /*		
    public void LevelComplete() {
        if (!v.menuLevelCompleteRef) {
            v.menuLevelCompleteRef = Instantiate(v.menuLevelComplete, v.menuLevelComplete.transform.position, v.menuLevelComplete.transform.rotation) as GameObject;
            v.menuLevelCompleteRef.transform.SetParent(v.transform, false);
        }
    }
    */


    public void UiButtonMap() {
            		//	case Q_Notification.UiButtonMap:
				Debug.Log("Map");
    }
    

    /*
    public void UiButtonNext() {
        Notify(Q_Notification.LevelNext);

        if (v.menuLevelCompleteRef) {
            Destroy(v.menuLevelCompleteRef);
        }
    }

    public void 

			case Q_Notification.UiButtonPrev:
				Notify(Q_Notification.LevelPrev);

				if (v.menuLevelCompleteRef) {
					Destroy(v.menuLevelCompleteRef);
				}
			break;

			case Q_Notification.UiButtonMenu:
				Log("Menu");
				
			break;  */


}
