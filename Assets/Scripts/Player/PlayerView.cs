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

        playerModel.movement 
           .ObserveEveryValueChanged(x => x.Value) 
           .Subscribe(xs => { 
               SetDirection(xs);
            }).AddTo(this);

        playerModel.position 
           .ObserveEveryValueChanged(y => y.Value)
           .Subscribe(ys => { 
               SetPosition(ys);
           }).AddTo(this);

        playerModel.lives 
   .ObserveEveryValueChanged(z => z.Value) 
   .Where(z => z <= 0)
   .Subscribe(z => {
           playerController.PlayerDie();   
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
