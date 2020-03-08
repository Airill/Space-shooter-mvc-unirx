using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class AsteroidView : MonoBehaviour
{
    public AsteroidModel asteroidModel { get; set; }
    App app;

    // Start is called before the first frame update
    void Awake() {
        app = FindObjectOfType<App>();

        this.OnCollisionEnterAsObservable()
            // .Where(x => x)
            .Subscribe(x => {
                var pc = x.transform.root.gameObject.GetComponentInChildren<PlayerController>();
                if (pc != null) {
                    pc.TakeDamage(asteroidModel.damage);

                }
                Destroy(this.gameObject.transform.parent.gameObject);
            })
            .AddTo(this);
    }

    public void OnDisable() {
        app.levelFactory.levelController.OnAsteroidDestroy();
    }

}
