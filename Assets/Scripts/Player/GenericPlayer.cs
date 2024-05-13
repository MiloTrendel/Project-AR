using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GenericPlayer
{
    public Dictionary<string, Spell> Spells { get; set; } = new();
    public Dictionary<string, float> SpellsCooldown { get; set; } = new();
    public int Level { get; protected set; } = 0;
    public int Score { get; protected set; } = 0;

    public float Fame { get; set; } = 0.0f;
    public float Mana { get; set; } = 0.0f;

    protected float FameDelta = 0.1f;
    protected float ManaDelta = 0.1f;
    
    public GenericPlayer Enemy;

    public Transform ParticuleSpawn;

    public List<GenericParticule> Particules = new();

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

        foreach (GenericParticule particule in Particules.ToList())
        {
            particule.LifeTime -= Time.deltaTime;
            if (particule.LifeTime < 0)
            {
                RemoveParticule(particule);
            }
        }
    }

    protected void ClampStats()
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

    protected void Win()
    {
        // TODO
    }

    protected void ManaOverload()
    {
        // TODO
        Mana = 100.0f;
    }

    public void AddParticule(GenericParticule newParticule)
    {
        Particules.Add(newParticule);
    }

    public void RemoveParticule(GenericParticule newParticule)
    {
        Particules.Remove(newParticule);
        Object.Destroy(newParticule.ParticuleGO);
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
            CurrentPlayer.Mana += CurrentPlayer.ManaDelta / 10;
            CurrentPlayer.Fame += CurrentPlayer.FameDelta / 10;
        }
    }

    protected class Defend : GenericPlayerState
    {
        public Defend(GenericPlayer currentPlayer, EGenericPlayerStates key) : base(currentPlayer, key)
        {
        }

        public override void Update()
        {
            CurrentPlayer.Mana += CurrentPlayer.ManaDelta;
        }
    }

    protected class Attack : GenericPlayerState
    {
        public Attack(GenericPlayer currentPlayer, EGenericPlayerStates key) : base(currentPlayer, key)
        {
        }

        public override void Update()
        {
            float delta = CurrentPlayer.FameDelta;
            foreach (var part in CurrentPlayer.Particules)
            {
                delta *= part.Force;
            }

            CurrentPlayer.Fame += delta;
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