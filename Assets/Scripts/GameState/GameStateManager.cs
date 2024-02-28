using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameStateManager : StateManager<GameStateManager.EGameStates>
{
    private static bool isDebugging = false;

    public enum EGameStates
    {
        MainMenu,
        Map,
        Show,

        Inventory,
        Walk,
        StartMenu,
        ShowAR
    }

    public GameStateContext Context { get; private set; } = null;
    private GenericPlayer Player1, Player2 = null;

    private void Awake()
    {
        if (Context == null)
            Context = new GameStateContext();

        if (Player1 == null)
            Player1 = new Player(Context);
        if (Player2 == null)
            Player2 = new AI(Context);

        Context.Player1 = Player1;
        Context.Player2 = Player2;
        InitializeStates();

        CurrentState = States[EGameStates.MainMenu];
    }

    private void InitializeStates()
    {
        States.Add(EGameStates.MainMenu, new GMMainMenu(Context, EGameStates.MainMenu));
        States.Add(EGameStates.Map, new GMMap(Context, EGameStates.Map));
        States.Add(EGameStates.Show, new GMShow(Context, EGameStates.Show));

        States.Add(EGameStates.Inventory, new GMInventory(Context, EGameStates.Inventory));
        States.Add(EGameStates.Walk, new GMWalk(Context, EGameStates.Walk));
        States.Add(EGameStates.StartMenu, new GMStartMenu(Context, EGameStates.StartMenu));
        States.Add(EGameStates.ShowAR, new GMShowAR(Context, EGameStates.ShowAR));
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.A))
            Player1.SetState(GenericPlayer.EGenericPlayerStates.Attack);
        if (Input.GetKeyDown(KeyCode.Z))
            Player1.SetState(GenericPlayer.EGenericPlayerStates.Defend);
        if (Input.GetKeyDown(KeyCode.E))
            Player1.SetState(GenericPlayer.EGenericPlayerStates.Dance);
        if (Input.GetKeyDown(KeyCode.R))
            Player1.SetState(GenericPlayer.EGenericPlayerStates.Idle);

        Debug.Log("State " + Player1.GetState().ToString());
    }


    public void DebugNextStateIterate()
    {
        ((GMBaseState)CurrentState).DebugNextStateIterate();
    }

    public void ToggleDebug()
    {
        if (!isDebugging)
        {
            GMBaseState.isDebugging = true;
            isDebugging = true;
            Debug.Log("Debug enabled");
        }
        else
        {
            GMBaseState.isDebugging = false;
            isDebugging = false;
            Debug.Log("Debug disabled");
        }
    }
}

public abstract class GMBaseState : BaseState<GameStateManager.EGameStates>
{
    public static bool isDebugging = false;
    public GameStateContext Context { get; private set; }
    public GameStateManager.EGameStates NextStateKey { get; protected set; }

    public GMBaseState(GameStateContext context, GameStateManager.EGameStates key) : base(key)
    {
        Context = context;
        NextStateKey = key;
    }
    public abstract void DebugNextStateIterate();
}