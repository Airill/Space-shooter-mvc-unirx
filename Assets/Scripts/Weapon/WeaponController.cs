using UnityEngine;
using UniRx;
using System;
using MarchingBytes;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{
    public WeaponModel weaponModel { get; set; }
    public WeaponView weaponView { get; set; }

    public GameObject shot;
    public Transform shotSpawn;

    public string poolName;
    List<GameObject> goList = new List<GameObject>();

    void Start() {
        App app = FindObjectOfType<App>();

        Observable.EveryUpdate()
           .Where(_ => Input.GetButton("Fire1"))
           .ThrottleFirst(TimeSpan.FromSeconds(weaponModel.fireRate))
           .Subscribe(_ => {
               if (app.levelFactory.levelController.currentLvl.inProgress) {
                   GameObject go = EasyObjectPool.instance.GetObjectFromPool(poolName, shotSpawn.position, shotSpawn.rotation);
                   if (go) {
                       goList.Add(go);
                   }
                   var pc = ((ProjectileController)go.GetComponentInChildren<ProjectileController>());
                   pc.OnSpawn();
               }
           }).AddTo(this); 
    }
}

