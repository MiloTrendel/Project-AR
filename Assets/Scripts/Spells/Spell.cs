using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public string Name { get; private set; }
    public int Cooldown { get; private set; }
    public int SpellID { get; private set; }
    public int Mana { get; private set; }
    public List<Vector3> SpellCastingSign { get; private set; }

    public Transform ParticuleSpawn { get; protected set; }
    public GameObject ParticulePrefab { get; protected set; }

    protected SpellManager spellManager;
    protected GenericPlayer player;

    protected Spell(SpellManager newSpellManager, int Mana, GenericPlayer player)
    {
        spellManager = newSpellManager;
        this.Mana = Mana;
        this.player = player;
    }

    protected void SetupSpellWithID(int jsonID = 0)
    {
        JSONSpellsInfoReader.JsonSpell jsonSpell = SpellManager.SpellInfoReader.SpellsInfo[jsonID];
        Name = jsonSpell.Name;
        Cooldown = jsonSpell.Cooldown;
        SpellID = jsonSpell.SpellID;
        Mana = jsonSpell.Mana;
        SpellCastingSign = SpellManager.SpellPosReader.SpeelsPos[jsonID].spellCastingSign;
    }

    public virtual bool Cast()
    {
        UnityEngine.Debug.Log("Cast " + SpellID);

        if (player.Mana < Mana)
        {
            player.Mana -= Mana;
            return false;
        }

        return true;
    }
}




// Specific Spells
//

#region Specific Spells
public class Spell0 : Spell
{
    public Spell0(GameObject particulePrefab, Transform particuleSpawn, SpellManager newSpellManager, int Mana, GenericPlayer player) : base(newSpellManager, Mana, player)
    {
        base.SetupSpellWithID(0);
        ParticuleSpawn = particuleSpawn;
        ParticulePrefab = particulePrefab;
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;

        GenericParticule newParticule = new(ParticulePrefab);
        player.AddParticule(newParticule);

        spellManager.StartCoroutine(PendAndKillParticule(newParticule.LifeTime, newParticule));
        return true;
    }
    protected IEnumerator PendAndKillParticule(float time, GenericParticule particule)
    {
        GameObject.Destroy(particule.ParticuleGO, time);
        yield return new WaitForSeconds(time);
        GameStateContext.Player1.RemoveParticule(particule);
    }
}

public class Spell1 : Spell
{
    public Spell1(SpellManager newSpellManager, int Mana, GenericPlayer player) : base(newSpellManager, Mana, player)
    {
        base.SetupSpellWithID(1);
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;

        short NbPart = (short)player.Particules.Count;
        short NbEnnPart = (short)GameStateContext.GetEnemy(player).Particules.Count;

        if (NbPart < NbEnnPart)
            return false;

        short Diff = (short)(NbPart - NbEnnPart);

        GameStateContext.GetEnemy(player).Fame -= Diff * Mana;
        player.Fame += Diff * Mana;

        return true;
    }
}

public class Spell2 : Spell
{
    public Spell2(SpellManager newSpellManager, int Mana, GenericPlayer player) : base(newSpellManager, Mana, player)
    {
        base.SetupSpellWithID(2);
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;
        short NbPart = (short)player.Particules.Count;
        short NbEnnPart = (short)GameStateContext.GetEnemy(player).Particules.Count;

        if (NbPart < NbEnnPart)
            return false;

        short Diff = (short)(NbPart - NbEnnPart);

        player.Mana -= Diff * Mana;
        player.Fame += Diff * Mana;

        return true;
    }
}

public class Spell3 : Spell
{
    public Spell3(SpellManager newSpellManager, int Mana, GenericPlayer player) : base(newSpellManager, Mana, player)
    {
        base.SetupSpellWithID(3);
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;

        foreach (GenericParticule genericParticule in player.Particules)
        {
            genericParticule.LifeTime *= 2;
        }

        return true;
    }

}

public class Spell4 : Spell
{
    public Spell4(SpellManager newSpellManager, int Mana, GenericPlayer player) : base(newSpellManager, Mana, player)
    {
        base.SetupSpellWithID(4);
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;
        return true;
    }
}
#endregion