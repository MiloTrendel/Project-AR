using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : StateManager<GameStateManager.EGameStates>
{
    private static bool isDebugging = false;

    [SerializeField] private Transform ParticuleSpawn1;
    [SerializeField] private Transform ParticuleSpawn2;

    public List<GameObject> MainMenu = new();
    public List<GameObject> Game = new();

    public List<GameObject> Inventory = new();
    public List<GameObject> Pause = new();

    public enum EGameStates
    {
        MainMenu,
        Game,

        Inventory,
        Pause
    }


    private void Awake()
    {
        GameStateContext.Player1 ??= new Player();
        GameStateContext.Player2 ??= new AI();

        GameStateContext.Player1.Enemy = GameStateContext.Player2;
        GameStateContext.Player2.Enemy = GameStateContext.Player1;

        GameStateContext.Player1.ParticuleSpawn = ParticuleSpawn1;
        GameStateContext.Player2.ParticuleSpawn = ParticuleSpawn2;

        InitializeStates();

        CurrentState = States[EGameStates.MainMenu];

        foreach (List<GameObject> list in new List<List<GameObject>>() { MainMenu, Game } )
        {
            foreach (GameObject item in list)
            {
                item.SetActive(false);
            }
        }
    }

    private void InitializeStates()
    {
        States = new()
        {
            { EGameStates.MainMenu, new GMMainMenu(EGameStates.MainMenu, this) },
            { EGameStates.Game, new GMGame(EGameStates.Game, this) },
            { EGameStates.Inventory, new GMInventory(EGameStates.Inventory, this) },
            { EGameStates.Pause, new GMPause(EGameStates.Pause, this) }
        };
    }

    public void FixedUpdate()
    {
        UpdateTick();
    }

    public void Update()
    {
    }

    public void CheckDebugNextFightStateIterate()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GameStateContext.Player1.SetState(GenericPlayer.EGenericPlayerStates.Attack);
        if (Input.GetKeyDown(KeyCode.Z))
            GameStateContext.Player1.SetState(GenericPlayer.EGenericPlayerStates.Defend);
        if (Input.GetKeyDown(KeyCode.E))
            GameStateContext.Player1.SetState(GenericPlayer.EGenericPlayerStates.Dance);
        if (Input.GetKeyDown(KeyCode.R))
            GameStateContext.Player1.SetState(GenericPlayer.EGenericPlayerStates.Idle);

        if (Input.GetKeyDown(KeyCode.Q))
            GameStateContext.Player2.SetState(GenericPlayer.EGenericPlayerStates.Attack);
        if (Input.GetKeyDown(KeyCode.S))
            GameStateContext.Player2.SetState(GenericPlayer.EGenericPlayerStates.Defend);
        if (Input.GetKeyDown(KeyCode.D))
            GameStateContext.Player2.SetState(GenericPlayer.EGenericPlayerStates.Dance);
        if (Input.GetKeyDown(KeyCode.F))
            GameStateContext.Player2.SetState(GenericPlayer.EGenericPlayerStates.Idle);
    }

    public void DebugNextGameStateIterate()
    {
        ((GMBaseState)CurrentState).DebugNextStateIterate();
    }

    public void SetState(string state)
    {
        EGameStates nextState;
        if (!Enum.TryParse<EGameStates>(state, out nextState))
            return;

        ((GMBaseState)CurrentState).SetState(nextState);
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
    public GameStateManager.EGameStates NextStateKey { get; protected set; }

    public GMBaseState(GameStateManager.EGameStates key) : base(key)
    {
        NextStateKey = key;
    }
    public abstract void DebugNextStateIterate();
    public void SetState(GameStateManager.EGameStates key)
    {
        NextStateKey = key;
    }
}