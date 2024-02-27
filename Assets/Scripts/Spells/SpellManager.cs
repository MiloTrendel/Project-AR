using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public static JSONSpellsInfoReader SpellInfoReader = null;
    public static JSONSpellsPointsPosReader SpellPosReader = null;

    [SerializeField] public TextAsset jsonInfoText;
    [SerializeField] public TextAsset jsonPosText;

    List<Spell> Spells = new();

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
        Spells.Add(new Spell0Cast());
        Spells.Add(new Spell1Cast());
        Spells.Add(new Spell2Cast());
        Spells.Add(new Spell3Cast());
        Spells.Add(new Spell4Cast());
    }

    public void ButtonSpellCast(int spellId)
    {
        Spells[spellId].Cast();
    }
}
