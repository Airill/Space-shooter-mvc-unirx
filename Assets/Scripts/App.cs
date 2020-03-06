using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public PlayerFactory playerFactory { get; private set; }
    public WeaponFactory weaponFactory { get; private set; }
    public ProjectileFactory projectileFactory { get; private set; }
    public AsteroidFactory asteroidFactory { get; private set; }
    public LevelFactory levelFactory { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        playerFactory = GetComponentInChildren<PlayerFactory>();
        weaponFactory = GetComponentInChildren<WeaponFactory>();
        projectileFactory = GetComponentInChildren<ProjectileFactory>();
        asteroidFactory = GetComponentInChildren<AsteroidFactory>();
        levelFactory = GetComponentInChildren<LevelFactory>();
    }


}
