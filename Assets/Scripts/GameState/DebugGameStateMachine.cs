using UnityEngine;
using TMPro;

public class DebugGameStateMachine : MonoBehaviour
{
    public GameStateManager StateManager;
    [SerializeField]
    private KeyCode debugNextStateKeyCode;

    [SerializeField]
    private KeyCode toggleDebugKeyCode;

    [SerializeField]
    private TMP_Text debugText;
    void Update()
    {
        if (Input.GetKeyDown(debugNextStateKeyCode))
            StateManager.DebugNextStateIterate();

        if (Input.GetKeyDown(toggleDebugKeyCode))
            StateManager.ToggleDebug();

        if (debugText != null)
            debugText.text = StateManager.CurrentState.ToString();
    }
}
