using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{

    public PlayerController playerController { get; private set; }
    public PlayerModel playerModel { get; private set; }
    public PlayerView playerView { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
        this.playerController = GetComponentInChildren<PlayerController>();
        Debug.Log(playerController);
        playerModel = new PlayerModel();
        Debug.Log(playerModel);
        playerController.playerModel = playerModel;
        Debug.Log(playerController.playerModel);
        playerView = GetComponentInChildren<PlayerView>();
        playerController.playerView = playerView;
        Debug.Log(playerController.playerView);
        playerView.playerModel = playerModel;
        Debug.Log(playerView.playerModel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
