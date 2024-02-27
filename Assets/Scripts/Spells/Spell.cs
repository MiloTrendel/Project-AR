using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public string Name { get; private set; }
    public int Cooldown { get; private set; }
    public int SpellID { get; private set; }
    public int Mana { get; private set; }
    public List<Vector3> SpellCastingSign { get; private set; }

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
public class Spell0Cast : Spell
{
    public Spell0Cast()
    {
        base.SetupSpellWithID(0);
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell1Cast : Spell
{
    public Spell1Cast()
    {
        base.SetupSpellWithID(1);
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell2Cast : Spell
{
    public Spell2Cast()
    {
        base.SetupSpellWithID(2);
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell3Cast : Spell
{
    public Spell3Cast()
    {
        base.SetupSpellWithID(3);
    }

    public override void Cast()
    {
        base.Cast();
    }

}

public class Spell4Cast : Spell
{
    public Spell4Cast()
    {
        base.SetupSpellWithID(4);
    }

    public override void Cast()
    {
        base.Cast();
    }
}
#endregion