using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ProjectileModel projectileModel { get; set; }
    public ProjectileView projectileView { get; set; }

    public void OnSpawn() {
        var rb = projectileView.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileModel.speed;
    }
}
