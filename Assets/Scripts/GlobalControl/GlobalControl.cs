using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public LevelData[] levels;

    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    public void Start() {
        for (int i = 0; i < levels.Length; i++) {
          //  levels[i].levelNum = i + 1;
        }
    }
}
