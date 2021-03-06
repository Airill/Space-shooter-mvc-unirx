﻿using UnityEngine;

public class UI_LevelFactory : MonoBehaviour
{
    public UI_LevelController ui_LevelController { get; private set; }
    public UI_LevelView ui_LevelView { get; private set; }

    void Awake() {
        ui_LevelController = GetComponentInChildren<UI_LevelController>();
        ui_LevelView = GetComponentInChildren<UI_LevelView>();
        ui_LevelController.ui_LevelView = ui_LevelView;
        ui_LevelView.ui_LevelController = ui_LevelController;
    }
}
