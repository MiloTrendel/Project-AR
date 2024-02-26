using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public JSONSpellsInfoReader spellInfoReader;
    public JSONSpellsPointsPosReader spellPosReader;

    public Spell spell1;
    public Spell spell2;
    public Spell spell3;
    public Spell spell4;
    public Spell spell5;

    void Start()
    {
        spell1 = new Spell(1, spellInfoReader, spellPosReader);
        spell2 = new Spell(2, spellInfoReader, spellPosReader);
        spell3 = new Spell(3, spellInfoReader, spellPosReader);
        spell4 = new Spell(4, spellInfoReader, spellPosReader);
        spell5 = new Spell(5, spellInfoReader, spellPosReader);
        
    }

    public void ButtonSpell1()
    {
        spell1.CastSpell();
    }

    public void ButtonSpell2()
    {
        spell2.CastSpell();
    }

    public void ButtonSpell3()
    {
        spell3.CastSpell();
    }

    public void ButtonSpell4()
    {
        spell4.CastSpell();
    }

    public void ButtonSpell5()
    {
        spell5.CastSpell();
    }
}
