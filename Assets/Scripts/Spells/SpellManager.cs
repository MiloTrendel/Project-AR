using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager
{
    List<Spells> spells = new List<Spells>();

    public SpellManager()
    {
        spells.Add(new Spell1Cast());
        spells.Add(new Spell2Cast());
        spells.Add(new Spell3Cast());
        spells.Add(new Spell4Cast());
        spells.Add(new Spell5Cast());
    }
    public abstract class Spells
    {
        public abstract void Do(Spell spell);
    }

    public void CastSpell(int spellID, Spell spell)
    {
        spells[spellID - 1].Do(spell);
    }

    private class Spell1Cast : Spells
    {
        public override void Do(Spell spell)
        {
            Debug.Log("Cast " + spell.name);
        }
    }

    private class Spell2Cast : Spells
    {
        public override void Do(Spell spell)
        {
            Debug.Log("Cast " + spell.name);
        }
    }

    private class Spell3Cast : Spells
    {
        public override void Do(Spell spell)
        {
            Debug.Log("Cast " + spell.name);
        }

    }

    private class Spell4Cast : Spells
    {
        public override void Do(Spell spell)
        {
            Debug.Log("Cast " + spell.name);
        }
    }

    private class Spell5Cast : Spells
    {
        public override void Do(Spell spell)
        {
            Debug.Log("Cast " + spell.name);
        }
    }
}
