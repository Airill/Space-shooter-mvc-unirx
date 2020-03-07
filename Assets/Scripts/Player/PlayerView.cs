using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerView : MonoBehaviour
{
    public PlayerModel playerModel { get; set; }
    public PlayerController playerController { get; set; }
    public Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        playerModel.movement // ReactiveProperty movement
           .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
           .Subscribe(xs => { // подписываемся
               SetDirection(xs);
            }).AddTo(this);

        playerModel.position // ReactiveProperty position
           .ObserveEveryValueChanged(y => y.Value) // отслеживаем изменения в нем
           .Subscribe(ys => { // подписываемся 
               SetPosition(ys);
           }).AddTo(this);

        playerModel.lives // ReactiveProperty lives
   .ObserveEveryValueChanged(z => z.Value) // отслеживаем изменения в нем
   .Where(z => z <= 0)
   .Subscribe(z => {
// подписываемся 
           playerController.PlayerDie();
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            this.gameObject.SetActive(false);
       
   }).AddTo(this);
    }

    public void SetDirection(Vector3 dir) {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (dir != null) {
            rb.velocity = new UnityEngine.Vector3(dir.x * playerModel.speed, 0.0f, dir.z * playerModel.speed);
        }        
    }
    public void SetPosition(Vector3 pos) {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (pos != null) {
            rb.position = new UnityEngine.Vector3(pos.x, 0.0f, pos.z);
        }
    }
}
