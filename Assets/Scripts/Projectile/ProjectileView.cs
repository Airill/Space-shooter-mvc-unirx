using MarchingBytes;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class ProjectileView : MonoBehaviour
{
    public ProjectileModel projectileModel { get; set; }
    public ProjectileController projectileController { get; set; }

    void OnEnable() {
        this.transform.position = projectileController.transform.position;
        this.OnCollisionEnterAsObservable()
            .Where(x => x.gameObject.tag != "Player")
            .Subscribe(_ => ReturnToPool())
            .AddTo(this);
    }
     void ReturnToPool() {
        EasyObjectPool.instance.ReturnObjectToPool(this.gameObject.transform.parent.gameObject);
    }
}
