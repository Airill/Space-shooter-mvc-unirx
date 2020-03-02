using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerView : MonoBehaviour
{
    public PlayerModel playerModel { get; set; }

    private void Start() {

        playerModel.direction // ReactiveProperty count
           .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
           .Subscribe(xs => { // подписываемся
               SetDirection(xs);
            }).AddTo(this);
    }

    public void SetDirection(Vector3 dir) {
        Rigidbody rb = GetComponent<Rigidbody>();
        Debug.Log((rb != null) + "+");
        Debug.Log(rb.velocity != null);
        if (dir != null) {
            rb.velocity = new UnityEngine.Vector3(dir.x, dir.y, dir.z);
            Debug.Log(rb.velocity);
        }
        
    }
}
