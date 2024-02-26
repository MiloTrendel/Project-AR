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

    public Spell(int id, JSONSpellReader spellReader)
    {
        Debug.Log(id - 1);
        Debug.Log(spellReader.spellList.spells.Count());
        Debug.Log(spellReader.spellList.spells[id - 1].cooldown);
        name = spellReader.spellList.spells[id - 1].name;
        cooldown = spellReader.spellList.spells[id - 1].cooldown;
        spellID = spellReader.spellList.spells[id - 1].spellID;
        mana = spellReader.spellList.spells[id - 1].mana;
        spellCastingSign = spellReader.spellList.spells[id - 1].spellCastingSign;
    }

    public void CastSpell()
    {
        spellManager.CastSpell(spellID, this);
    }
}
