
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManagerFSM : MonoBehaviour
{
    //Dans un vrai système, cette variable serait chargée depuis une sauvegarde, ou choisie depuis un menu de
    //sélection de niveau : 
    public SceneReference selectedLevel;
    
    private GameState currentState;
    
    private void Start()
    {
        GameState[] states = GetComponents<GameState>();
        foreach (GameState state in states)
        {
            state.Initialize(this);
        }
        
        //Make persistent (EZ version)
        DontDestroyOnLoad(gameObject);
       
        currentState = GetComponent<MainMenuGameState>();
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Tick();
    }

    public void ChangeState(GameState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}