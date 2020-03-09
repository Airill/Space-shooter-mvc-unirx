using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour
{
    public ProjectileController projectileController { get; private set; }
    public ProjectileModel projectileModel { get; private set; }
    public ProjectileView projectileView { get; private set; }

    void Awake() {

        this.projectileController = GetComponentInChildren<ProjectileController>();
        projectileModel = new ProjectileModel();
        projectileController.projectileModel = projectileModel;
        projectileView = GetComponentInChildren<ProjectileView>();
        projectileController.projectileView = projectileView;
        projectileView.projectileModel = projectileModel;
        projectileView.projectileController = projectileController;
    }
}
