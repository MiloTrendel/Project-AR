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
        Spells.Add(new Spell0(ParticulePrefab, GameStateContext.Player1.ParticuleSpawn));
        Spells.Add(new Spell1());
        Spells.Add(new Spell2());
        Spells.Add(new Spell3());
        Spells.Add(new Spell4());
    }

    public void ButtonSpellCast(int spellId)
    {
        Spells[spellId].Cast();
    }
}
