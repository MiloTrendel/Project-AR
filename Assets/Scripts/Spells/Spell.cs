using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spell
{
    SpellManager spellManager = new SpellManager();

    public string name;
    public int cooldown;
    public int spellID;
    public int mana;
    public List<Vector3> spellCastingSign;

    public Spell(int id, JSONSpellsInfoReader spellInfoReader, JSONSpellsPointsPosReader spellPosReader)
    {
        name = spellInfoReader.spellList.spells[id - 1].name;
        cooldown = spellInfoReader.spellList.spells[id - 1].cooldown;
        spellID = spellInfoReader.spellList.spells[id - 1].spellID;
        mana = spellInfoReader.spellList.spells[id - 1].mana;
        spellCastingSign = spellPosReader.spellPosList.spells[id - 1].spellCastingSign;
    }

    public void CastSpell()
    {
        spellManager.CastSpell(spellID, this);
    }
}
