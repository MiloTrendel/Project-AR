using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameStateManager : StateManager<GameStateManager.EGameStates>
{
    private static bool isDebugging = false;

    public enum EGameStates
    {
        MainMenu,
        Map,
        Show
    }

    private GameStateContext _context;

    private void Awake()
    {
        _context = new GameStateContext();
        InitializeStates();

        CurrentState = States[EGameStates.MainMenu];
    }

    private void InitializeStates()
    {
        States.Add(EGameStates.MainMenu, new GMMainMenu(_context, EGameStates.MainMenu));
        States.Add(EGameStates.Map, new GMMap(_context, EGameStates.Map));
        States.Add(EGameStates.Show, new GMShow(_context, EGameStates.Show));
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
    public GameStateManager.EGameStates nextStateKey { get; protected set; }

    public GMBaseState(GameStateContext context, GameStateManager.EGameStates key) : base(key)
    {
        Context = context;
        nextStateKey = key;
    }
    public abstract void DebugNextStateIterate();
}
