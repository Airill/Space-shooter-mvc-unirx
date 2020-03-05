using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel { get; set; }
    public PlayerView playerView { get; set; }

    void Start()
    {

        // player moving
        var moveHorizontalStream = Observable.EveryFixedUpdate()
                    .Select(_ => Input.GetAxis("Horizontal"));

        var moveVerticalStream = Observable.EveryFixedUpdate()
            .Select(_ => Input.GetAxis("Vertical"));

        var movementStream = moveHorizontalStream.CombineLatest(moveVerticalStream,
            (horizontal, vertical) => new Vector3(horizontal, 0.0f, vertical));

        movementStream.Subscribe(movement => {
                playerModel.direction.Value = movement;
  
        }).AddTo(this);
    }

    public void TakeDamage(int dmg) {
        playerModel.lives -= dmg;
        Debug.Log("Damage taken!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
