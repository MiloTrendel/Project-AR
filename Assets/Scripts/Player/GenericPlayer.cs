using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GenericPlayer
{
    public List<Spell> Spells { get; protected set; } = new();
    public int Level { get; protected set; } = 0;
    public int Score { get; protected set; } = 0;

    public float Fame { get; protected set; } = 0.0f;
    public float Mana { get; protected set; } = 0.0f;

    protected float FameDelta = 0.1f;
    protected float ManaDelta = 0.1f;
    
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

    protected GenericPlayer()
    {
        InitializeStates();

        CurrentState = States[EGenericPlayerStates.Idle];
    }
    private void InitializeStates()
    {
        States = new()
        {
            { EGenericPlayerStates.Attack, new Attack(this, EGenericPlayerStates.Attack) },
            { EGenericPlayerStates.Defend, new Defend(this, EGenericPlayerStates.Defend) },
            { EGenericPlayerStates.Dance, new Dance(this, EGenericPlayerStates.Dance) },
            { EGenericPlayerStates.Idle, new Idle(this, EGenericPlayerStates.Idle) }
        };
    }

    public void UpdateGenericPlayer()
    {
        if (Enemy == null)
        {
            Debug.LogWarning("no enemy.");
            return;
        }

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
        Mana = 100.0f;
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
        protected GenericPlayerState(GenericPlayer currentPlayer, EGenericPlayerStates key)
        {
            CurrentPlayer = currentPlayer;
            Key = key;
        }

        public EGenericPlayerStates Key;
        protected GenericPlayer CurrentPlayer;

        public abstract void Update();
    }

    // vvv Derived GenericPlayerState vvv

    protected class Dance : GenericPlayerState
    {
        public Dance(GenericPlayer currentPlayer, EGenericPlayerStates key) : base(currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Fame += CurrentPlayer.FameDelta;
            CurrentPlayer.Mana += CurrentPlayer.ManaDelta;
        }
    }

    protected class Defend : GenericPlayerState
    {
        public Defend(GenericPlayer currentPlayer, EGenericPlayerStates key) : base(currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Mana += CurrentPlayer.ManaDelta * 2;
            if (CurrentPlayer.Enemy != null)
                CurrentPlayer.Fame -= CurrentPlayer.FameDelta;
        }
    }

    protected class Attack : GenericPlayerState
    {
        public Attack(GenericPlayer currentPlayer, EGenericPlayerStates key) : base(currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Fame += CurrentPlayer.FameDelta;
            if (CurrentPlayer.Enemy != null)
                CurrentPlayer.Mana -= CurrentPlayer.ManaDelta;
        }
    }

    protected class Idle : GenericPlayerState
    {
        public Idle(GenericPlayer currentPlayer, EGenericPlayerStates key) : base(currentPlayer, key)
        {
        }

        public override void Update() { }
    }
#endregion
}