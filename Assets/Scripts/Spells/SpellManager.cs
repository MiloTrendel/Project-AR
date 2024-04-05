using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public static JSONSpellsInfoReader SpellInfoReader = null;
    public static JSONSpellsPointsPosReader SpellPosReader = null;

    [SerializeField] public TextAsset jsonInfoText;
    [SerializeField] public TextAsset jsonPosText;

    [SerializeField] private GameObject ParticulePrefab;

    readonly List<Spell> Spells = new();

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
        Spells.Add(new Spell0(ParticulePrefab, GameStateContext.Player1.ParticuleSpawn, this));
        Spells.Add(new Spell1(this));
        Spells.Add(new Spell2(this));
        Spells.Add(new Spell3(this));
        Spells.Add(new Spell4(this));
    }

    public void ButtonSpellCast(int spellId)
    {
        Spells[spellId].Cast();
    }
}
