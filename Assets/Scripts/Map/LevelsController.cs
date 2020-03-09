using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelsController : MonoBehaviour
{
    GlobalControl gc;
    LevelsView lv;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GlobalControl>();
        lv = FindObjectOfType<LevelsView>();

        SetButtons();
        SetLevelsState();
    }

    public void SetLevelsState() {
        var buttons = lv.levelButtons;
        for (int i = 0; i < gc.levels.Length; i++) {
            gc.levels[i].SetLevelSelect(false);
            if (gc.levels[i].isCompleted == false) {
                var colors = buttons[i].GetComponent<Button>().colors;
                colors.normalColor = Color.yellow;
                buttons[i].GetComponent<Button>().colors = colors;
                break;
            } else {
                var colors = buttons[i].GetComponent<Button>().colors;
                colors.normalColor = Color.green;
                buttons[i].GetComponent<Button>().colors = colors;
            }
        }
    }

    public void SetButtons() {
        var buttons = lv.levelButtons;
        for (int i = 0; i < buttons.Length; i++) {
            int tempI = i;
            int startIndex = 1;
            buttons[i].GetComponent<Button>().onClick.AddListener(delegate { LevelChoice(tempI); });
            buttons[i].GetComponentInChildren<Text>().text = ("Level " + (startIndex + tempI));
        }
    }

    public void LevelChoice(int ch) {
        if ((gc.levels[ch].isCompleted) || (ch == 0) || (gc.levels[ch-1].isCompleted)) {
            gc.levels[ch].SetLevelSelect(true);
            SceneManager.LoadScene(1);
        }
    }
}
