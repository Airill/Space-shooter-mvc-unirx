using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public AsteroidModel asteroidModel { get; set; }
    public AsteroidView asteroidView { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        var rb = asteroidView.GetComponent<Rigidbody>();

        rb.velocity = transform.forward * asteroidModel.speed * (-1);
        rb.angularVelocity = Random.insideUnitSphere * asteroidModel.tumble;

        Destroy(transform.root.gameObject, asteroidModel.lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
