using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel { get; set; }
    public PlayerView playerView { get; set; }
    Boundary boundary;

    void Start()
    {
        boundary = new Boundary();
        playerModel.position.Value = new Vector3(playerView.transform.position.x, playerView.transform.position.y, playerView.transform.position.z);


        // player moving
        var moveHorizontalStream = Observable.EveryFixedUpdate()
                    .Select(_ => Input.GetAxis("Horizontal"));

        var moveVerticalStream = Observable.EveryFixedUpdate()
            .Select(_ => Input.GetAxis("Vertical"));

        var movementStream = moveHorizontalStream.CombineLatest(moveVerticalStream,
            (horizontal, vertical) => new Vector3(horizontal, 0.0f, vertical));

        movementStream.Subscribe(movement => {
            playerModel.movement.Value = movement;
            playerModel.position.Value = new Vector3(Mathf.Clamp(playerView.rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(playerView.rb.position.z, boundary.zMin, boundary.zMax));
        }).AddTo(this);
       
    }

    public void TakeDamage(int dmg) {
        playerModel.lives.Value -= dmg;
        Debug.Log("Damage taken!");
    }

    public void PlayerDie() {
        Debug.Log("Controller: player die");
    }
}
