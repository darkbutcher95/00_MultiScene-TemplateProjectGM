using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInitializationGameState : GameState
{
    public override void Enter()
    {
        InitPlayer();
        fsm.ChangeState(GetComponent<PlayingGameState>());
    }
    
    private void InitPlayer()
    {
       //Todo : spawn player
    }
}