using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public static JSONSpellsInfoReader SpellInfoReader = null;
    public static JSONSpellsPointsPosReader SpellPosReader = null;

    [SerializeField] public TextAsset jsonInfoText;
    [SerializeField] public TextAsset jsonPosText;

    [SerializeField] private GameObject ParticulePrefab;

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
        AddSpell("Double", player1);

        GenericPlayer player2 = GameStateContext.Player2;
        AddSpell("Centre", player2);
        AddSpell("Spawn", player2);
        AddSpell("Tornado", player2);
        AddSpell("Double", player2);
    }

    private void Update()
    {
        UpdateCooldown(GameStateContext.Player1.SpellsCooldown);
        UpdateCooldown(GameStateContext.Player2.SpellsCooldown);
    }
    private void UpdateCooldown(Dictionary<string, float> cooldowns)
    {
        foreach (var cooldown in cooldowns.ToList())
        {
            if (cooldown.Value > 0)
                cooldowns[cooldown.Key] -= Time.deltaTime;
        }
    }

    public void CastSpell(string spellName, GenericPlayer player)
    {
        try
        {
            if (!player.Spells[spellName].Cast())
                return;

            player.SpellsCooldown[spellName] = player.Spells[spellName].Cooldown;
        } catch { }
    }

    private void AddSpell(string spellName, GenericPlayer player)
    {
        Spell spell = CreateSpell(spellName, player);

        player.Spells.Add(spellName, spell);
        player.SpellsCooldown[spellName] = spell.Cooldown;
    }

    private Spell CreateSpell(string spellName, GenericPlayer player)
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
