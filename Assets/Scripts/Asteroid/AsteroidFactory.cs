using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : MonoBehaviour
{
    public AsteroidController asteroidController { get; private set; }
    public AsteroidModel asteroidModel { get; private set; }
    public AsteroidView asteroidView { get; private set; }

    // Start is called before the first frame update
    void Awake() {

        asteroidController = GetComponentInChildren<AsteroidController>();
        asteroidModel = new AsteroidModel();
        asteroidController.asteroidModel = asteroidModel;
        asteroidView = GetComponentInChildren<AsteroidView>();
        asteroidController.asteroidView = asteroidView;
        asteroidView.asteroidModel = asteroidModel;
    }
}
 