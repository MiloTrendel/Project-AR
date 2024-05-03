using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugGameStateMachine : MonoBehaviour
{
    public GameStateManager StateManager;
    [SerializeField] private KeyCode debugNextStateKeyCode;

    [SerializeField] private KeyCode toggleDebugKeyCode;

    [SerializeField] private Slider FameSlide1;
    [SerializeField] private Slider FameSlide2;
    [SerializeField] private Slider ManaSlide1;
    [SerializeField] private Slider ManaSlide2;

    [SerializeField] private TMP_Text Player1State;
    [SerializeField] private TMP_Text Player2State;

    [SerializeField] private SpellManager spellManager;

    void Update()
    {
        if (Input.GetKeyDown(debugNextStateKeyCode))
            StateManager.DebugNextGameStateIterate();

        if (Input.GetKeyDown(toggleDebugKeyCode))
            StateManager.ToggleDebug();
        StateManager.CheckDebugNextFightStateIterate();


        Player1State.text = "State " + GameStateContext.Player1.GetState().ToString();
        Player2State.text = "State " + GameStateContext.Player2.GetState().ToString();


        if (FameSlide1 != null)
            FameSlide1.value = GameStateContext.Player1.Fame / 100.0f;
        if (FameSlide2 != null)
            FameSlide2.value = GameStateContext.Player2.Fame / 100.0f;
        if (ManaSlide1 != null)
            ManaSlide1.value = GameStateContext.Player1.Mana / 100.0f;
        if (ManaSlide2 != null)
            ManaSlide2.value = GameStateContext.Player2.Mana / 100.0f;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellManager.CastSpell("Spawn", GameStateContext.Player1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spellManager.CastSpell("Tornado", GameStateContext.Player1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            spellManager.CastSpell("Spawn", GameStateContext.Player2);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            spellManager.CastSpell("Tornado", GameStateContext.Player2);
        }
    }
}