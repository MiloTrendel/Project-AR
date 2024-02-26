using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public JSONSpellReader spellReader;

    public Spell spell1;
    public Spell spell2;
    public Spell spell3;
    public Spell spell4;
    public Spell spell5;

    void Start()
    {
        Debug.Log(spellReader.spellList.spells.Count());
        Debug.Log("Spell 1");
        spell1 = new Spell(1, spellReader);
        Debug.Log("Spell 2");
        spell2 = new Spell(2, spellReader);
        Debug.Log("Spell 3");
        spell3 = new Spell(3, spellReader);
        Debug.Log("Spell 4");
        spell4 = new Spell(4, spellReader);
        Debug.Log("Spell 5");
        spell5 = new Spell(5, spellReader);
        
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
