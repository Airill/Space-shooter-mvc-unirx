using UnityEngine;
using System.Collections;
using UniRx;
using System;

public class WeaponController : MonoBehaviour
{
    public WeaponModel weaponModel { get; set; }
    public WeaponView weaponView { get; set; }

    public GameObject shot;
    public Transform shotSpawn;

    void Start() {
        App app = FindObjectOfType<App>();

        Observable.EveryUpdate()
           .Where(_ => Input.GetButton("Fire1"))
           .ThrottleFirst(TimeSpan.FromSeconds(weaponModel.fireRate))
           .Subscribe(_ => {
               if (app.levelFactory.levelController.currentLvl.inProgress) {
                   var sh = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
                   var pc = ((ProjectileController)sh.GetComponentInChildren<ProjectileController>());
                   pc.OnSpawn();
               }

               //  GetComponent<AudioSource>().Play();
           }).AddTo(this); 


    }
}

