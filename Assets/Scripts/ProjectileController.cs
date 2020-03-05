using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ProjectileModel projectileModel { get; set; }
    public ProjectileView projectileView { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
       
    }



    public void OnSpawn() {
        var rb = projectileView.GetComponent<Rigidbody>();

        rb.velocity = transform.forward * projectileModel.speed;
    }
}
