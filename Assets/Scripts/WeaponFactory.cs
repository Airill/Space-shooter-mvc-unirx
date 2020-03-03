using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    public WeaponController weaponController { get; private set; }
    public WeaponModel weaponModel { get; private set; }
    public WeaponView weaponView { get; private set; }

    // Start is called before the first frame update
    void Start() {

        this.weaponController = GetComponentInChildren<WeaponController>();
        weaponModel = new WeaponModel();
        weaponController.weaponModel = weaponModel;
        weaponView = GetComponentInChildren<WeaponView>();
        weaponController.weaponView = weaponView;
        weaponView.weaponModel = weaponModel;
    }

}
