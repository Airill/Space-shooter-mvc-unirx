using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerView : MonoBehaviour
{
    public PlayerModel playerModel { get; set; }

    private void Start() {

        playerModel.direction // ReactiveProperty direction
           .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
           .Subscribe(xs => { // подписываемся
               SetDirection(xs);
            }).AddTo(this);
    }

    public void SetDirection(Vector3 dir) {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (dir != null) {
            rb.velocity = new UnityEngine.Vector3(dir.x * playerModel.speed_base, 0.0f, dir.z * playerModel.speed_base);
        }
        
    }
}
