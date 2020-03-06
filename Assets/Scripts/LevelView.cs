using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public LevelModel levelModel { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateLevel(int currentLevel) {
        Debug.Log("level generated;");
    }
    
    public void CompleteLevel() {
        Debug.Log("Completelevel!");
    }

    public void FailLevel() {

    }
}
