using UnityEngine;

public class GMPause : GMBaseState
{
    private GameStateManager GSManager;
    public GMPause(GameStateManager.EGameStates key, GameStateManager GSManager) : base(key)
    {
        this.GSManager = GSManager;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter Pause");

        foreach (GameObject go in GSManager.Pause)
        {
            go.SetActive(true);
        }
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update Pause");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        foreach (GameObject go in GSManager.Pause)
        {
            go.SetActive(false);
        }

        if (isDebugging)
            Debug.Log("Exit Pause");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.MainMenu;
    }
}
