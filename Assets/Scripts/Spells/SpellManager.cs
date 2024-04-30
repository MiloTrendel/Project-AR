using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public static JSONSpellsInfoReader SpellInfoReader = null;
    public static JSONSpellsPointsPosReader SpellPosReader = null;

    [SerializeField] public TextAsset jsonInfoText;
    [SerializeField] public TextAsset jsonPosText;

    [SerializeField] private GameObject ParticulePrefab;

    readonly Dictionary<string, Spell> Spells = new();

    private void Awake()
    {
        if (SpellInfoReader == null)
            SpellInfoReader = new(jsonInfoText);

        if (SpellPosReader == null)
            SpellPosReader = new(jsonPosText);

        SpellInfoReader.SetupSpells();
        SpellPosReader.SetupSpells();
    }

    void Start()
    {
        GenericPlayer player1 = GameStateContext.Player1;
        AddSpell("Centre", player1);
        AddSpell("Spawn", player1);
        AddSpell("Tornado", player1);
    }

    public void CastSpell(string spellName)
    {
        Spells[spellName].Cast();
    }

    private void AddSpell(string spellName, GenericPlayer player)
    {
        Spells.Add(spellName, GetSpell(spellName, player));
    }

    private Spell GetSpell(string spellName, GenericPlayer player)
    {
        foreach (var spellInfo in SpellInfoReader.SpellsInfo)
        {
            if (spellInfo.Name != spellName)
                continue;

            Type type = Type.GetType(spellName);

            Spell spell = (Spell)Activator.CreateInstance(type);

            spell.Name = spellInfo.Name;
            spell.Cooldown = spellInfo.Cooldown;
            spell.SpellID = spellInfo.SpellID;
            spell.Mana = spellInfo.Mana;
            spell.ParticuleSpawn = player.ParticuleSpawn;
            spell.player = player;

            spell.spellManager = this;

            if (spellName == "Spawn")
                spell.ParticulePrefab = ParticulePrefab;

            return spell;
        }
        return null;
    }
}
