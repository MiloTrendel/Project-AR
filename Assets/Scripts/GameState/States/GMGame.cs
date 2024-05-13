using UnityEngine;

public class GMGame : GMBaseState
{
    private GameStateManager GSManager;
    public GMGame(GameStateManager.EGameStates key, GameStateManager GSManager) : base(key)
    {
        this.GSManager = GSManager;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter Game");

        foreach (GameObject go in GSManager.Game)
        {
            go.SetActive(true);
        }
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update Game");
        GameStateContext.Player1.UpdateGenericPlayer();
        GameStateContext.Player2.UpdateGenericPlayer();
    }
    
    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        foreach (GameObject go in GSManager.Game)
        {
            go.SetActive(false);
        }

        if (isDebugging)
            Debug.Log("Exit Game");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.MainMenu;
    }
}
