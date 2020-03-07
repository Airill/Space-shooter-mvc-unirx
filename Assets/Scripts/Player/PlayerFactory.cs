using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{

    public PlayerController playerController { get; private set; }
    public PlayerModel playerModel { get; private set; }
    public PlayerView playerView { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        this.playerController = GetComponentInChildren<PlayerController>();
        playerModel = new PlayerModel();
        playerController.playerModel = playerModel;
        playerView = GetComponentInChildren<PlayerView>();
        playerController.playerView = playerView;
        playerView.playerModel = playerModel;
        playerView.playerController = playerController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
