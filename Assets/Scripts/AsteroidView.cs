using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class AsteroidView : MonoBehaviour
{
    public AsteroidModel asteroidModel { get; set; }

    // Start is called before the first frame update
    void Awake() {
        this.OnCollisionEnterAsObservable()
            // .Where(x => x)
            .Subscribe(x => {
                var pc = x.transform.root.gameObject.GetComponentInChildren<PlayerController>();
                if (pc != null) {
                    pc.TakeDamage(asteroidModel.damage);

                }
                Destroy(this.gameObject.transform.root.gameObject);
            })
            .AddTo(this);
    }

}
