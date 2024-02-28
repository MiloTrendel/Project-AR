using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GenericPlayer
{
    private GameStateContext _context;

    public List<Spell> Spells { get; protected set; } = new();
    public int Level { get; protected set; } = 0;
    public int Score { get; protected set; } = 0;

    public float Fame { get; protected set; } = 0.0f;
    public float Mana { get; protected set; } = 0.0f;
    
    public GenericPlayer Enemy;

    protected GenericPlayerState CurrentState;

    protected Dictionary<EGenericPlayerStates, GenericPlayerState> States;
    public enum EGenericPlayerStates
    {
        Attack,
        Defend,
        Dance,
        Idle
    }

    protected GenericPlayer(GameStateContext context)
    {
        _context = context;

        InitializeStates();

        CurrentState = States[EGenericPlayerStates.Idle];
    }
    private void InitializeStates()
    {
        States = new();
        States.Add(EGenericPlayerStates.Attack, new Attack(_context, this, EGenericPlayerStates.Attack));
        States.Add(EGenericPlayerStates.Defend, new Defend(_context, this, EGenericPlayerStates.Defend));
        States.Add(EGenericPlayerStates.Dance, new Dance(_context, this, EGenericPlayerStates.Dance));
        States.Add(EGenericPlayerStates.Idle, new Idle(_context, this, EGenericPlayerStates.Idle));
    }

    public void UpdateGenericPlayer()
    {
        if (Enemy == null)
            return;

        CurrentState.Update();
        ClampStats();

        Debug.Log(Fame + " de fame / " + Mana + " de Mana.");
    }

    private void ClampStats()
    {
        if (Fame < 0.0f)
            Fame = 0.0f;
        if (Mana < 0.0f)
            Mana = 0.0f;

        if (Fame > 100.0f)
            Win();
        if (Mana > 100.0f)
            ManaOverload();
    }

    private void Win()
    {
        // TODO
    }

    private void ManaOverload()
    {
        // TODO
    }

    public void SetState(EGenericPlayerStates key)
    {
        CurrentState = States[key];
    }

    public EGenericPlayerStates GetState()
    {
        return CurrentState.Key;
    }

    #region FightState
    protected abstract class GenericPlayerState
    {
        protected GenericPlayerState(GameStateContext context, GenericPlayer currentPlayer, EGenericPlayerStates key)
        {
            CurrentPlayer = currentPlayer;
            CurrentPlayer._context = context;
            this.Key = key;
            CurrentPlayer.Enemy = CurrentPlayer._context.GetEnemy(CurrentPlayer);
        }

        public EGenericPlayerStates Key;
        protected GenericPlayer CurrentPlayer;

        public abstract void Update();
    }

    // vvv Derived GenericPlayerState vvv

    protected class Dance : GenericPlayerState
    {
        public Dance(GameStateContext context, GenericPlayer currentPlayer, EGenericPlayerStates key) : base(context, currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Fame += 2.0f;
            CurrentPlayer.Mana += 2.0f;
        }
    }

    protected class Defend : GenericPlayerState
    {
        public Defend(GameStateContext context, GenericPlayer currentPlayer, EGenericPlayerStates key) : base(context, currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Mana += 4.0f;
            if (CurrentPlayer.Enemy != null)
                CurrentPlayer.Enemy.Fame -= 2.0f;
        }
    }

    protected class Attack : GenericPlayerState
    {
        public Attack(GameStateContext context, GenericPlayer currentPlayer, EGenericPlayerStates key) : base(context, currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Fame += 2.0f;
            if (CurrentPlayer.Enemy != null)
                CurrentPlayer.Enemy.Mana -= 2.0f;
        }
    }

    protected class Idle : GenericPlayerState
    {
        public Idle(GameStateContext context, GenericPlayer currentPlayer, EGenericPlayerStates key) : base(context, currentPlayer, key)
        {
        }

        public override void Update() { }
    }
#endregion
}