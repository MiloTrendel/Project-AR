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

    protected void SetupSpellWithID(int jsonID = 0)
    {
        JSONSpellsInfoReader.JsonSpell jsonSpell = SpellManager.SpellInfoReader.SpellsInfo[jsonID];
        Name = jsonSpell.Name;
        Cooldown = jsonSpell.Cooldown;
        SpellID = jsonSpell.SpellID;
        Mana = jsonSpell.Mana;
        SpellCastingSign = SpellManager.SpellPosReader.SpeelsPos[jsonID].spellCastingSign;
    }

    public virtual void Cast()
    {
        UnityEngine.Debug.Log("Cast " + SpellID);
    }
}




// Specific Spells
//

#region Specific Spells
public class Spell0 : Spell
{
    public Spell0(GameObject particulePrefab, Transform particuleSpawn)
    {
        base.SetupSpellWithID(0);
        ParticuleSpawn = particuleSpawn;
        ParticulePrefab = particulePrefab;
    }

    public override void Cast()
    {
        GameStateContext.Player1.AddParticule(new GenericParticule(ParticulePrefab));
    }
}

public class Spell1 : Spell
{
    public Spell1()
    {
        base.SetupSpellWithID(1);
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell2 : Spell
{
    public Spell2()
    {
        base.SetupSpellWithID(2);
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell3 : Spell
{
    public Spell3()
    {
        base.SetupSpellWithID(3);
    }

    public override void Cast()
    {
        base.Cast();
    }

}

public class Spell4 : Spell
{
    public Spell4()
    {
        base.SetupSpellWithID(4);
    }

    public override void Cast()
    {
        base.Cast();
    }
}
#endregion