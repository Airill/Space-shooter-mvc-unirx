using System.Collections;
using System.Collections.Generic;


public class LevelModel
{
    public Boundary boundary;
    public LevelData data_base;

    public float genCoef_base = 10;
    public Vector3 spawnValues = new Vector3(6f, 0f, 16f);

    public int levelCount;
    public int currentLevel;

    public int score;
    public int score_base = 0;

    public LevelData data = new LevelData();
}

[System.Serializable]
public class Boundary
{
    public float xMin = -6f, xMax = 6f, zMin = -3f, zMax = 3f;

}

[System.Serializable]
public class LevelData
{
    public bool inProgress = true;
    public int asteroidsLeft;
    public int asteroids = 10;
    public float asteroidSpeedMultiplier = 1f;
    public float asteroidSpawnDelay = 1f;
    public float levelStartDelay =1f;
}
