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
        GenericPlayer player1 = GameStateContext.Player1;
        Spells.Add(new Spell0(ParticulePrefab, player1.ParticuleSpawn, this, 5, player1));
        Spells.Add(new Spell1(this, 25, player1));
        Spells.Add(new Spell2(this, 0, player1));
        Spells.Add(new Spell3(this, 0, player1));
        Spells.Add(new Spell4(this, 0, player1));
    }

    public void ButtonSpellCast(int spellId)
    {
        Spells[spellId].Cast();
    }
}
