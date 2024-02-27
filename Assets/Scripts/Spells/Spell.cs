using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public string Name { get; private set; }
    public int Cooldown { get; private set; }
    public int SpellID { get; private set; }
    public int Mana { get; private set; }
    public List<Vector3> SpellCastingSign { get; private set; }

    public Spell(int jsonID)
    {
        JSONSpellsInfoReader.JsonSpell jsonSpell = SpellManager.SpellInfoReader.SpellsInfo[jsonID - 1];

        Name = jsonSpell.Name;
        Cooldown = jsonSpell.Cooldown;
        SpellID = jsonSpell.SpellID;
        Mana = jsonSpell.Mana;
        SpellCastingSign = SpellManager.SpellPosReader.SpeelsPos[jsonID - 1].spellCastingSign;
    }

    public virtual void Cast()
    {
        UnityEngine.Debug.Log("Cast " + SpellID);
    }
}




// Specific Spells
//

#region Specific Spells
public class Spell1Cast : Spell
{
    public Spell1Cast(int jsonID) : base(jsonID)
    {
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell2Cast : Spell
{
    public Spell2Cast(int jsonID) : base(jsonID)
    {
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell3Cast : Spell
{
    public Spell3Cast(int jsonID) : base(jsonID)
    {
    }

    public override void Cast()
    {
        base.Cast();
    }

}

public class Spell4Cast : Spell
{
    public Spell4Cast(int jsonID) : base(jsonID)
    {
    }

    public override void Cast()
    {
        base.Cast();
    }
}

public class Spell5Cast : Spell
{
    public Spell5Cast(int jsonID) : base(jsonID)
    {
    }

    public override void Cast()
    {
        base.Cast();
    }
}
#endregion