using UnityEngine;

public class GMMainMenu : GMBaseState
{
    private GameStateManager GSManager;
    public GMMainMenu(GameStateManager.EGameStates key, GameStateManager GSManager) : base(key)
    {
        this.GSManager = GSManager;
    }
    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter MainMenu ");

        foreach(GameObject go in GSManager.MainMenu)
        {
            go.SetActive(true);
        }
    }
    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update MainMenu");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        foreach (GameObject go in GSManager.MainMenu)
        {
            go.SetActive(false);
        }


        if (isDebugging)
            Debug.Log("Exit MainMenu");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.Game;
    }
}