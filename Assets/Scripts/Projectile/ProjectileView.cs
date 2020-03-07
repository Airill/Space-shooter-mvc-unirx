using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class ProjectileView : MonoBehaviour
{
    public ProjectileModel projectileModel { get; set; }

    private void Start() {


        this.OnCollisionEnterAsObservable()
            .Where(x => x.gameObject.tag != "Player")
            .Subscribe(_ => Destroy(this.gameObject.transform.root.gameObject))
            .AddTo(this);

        Destroy(this.gameObject.transform.root.gameObject, projectileModel.lifetime);
    }
}
