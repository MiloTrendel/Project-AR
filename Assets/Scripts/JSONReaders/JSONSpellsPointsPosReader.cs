using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JSONSpellsInfoReader;

public class JSONSpellsPointsPosReader : MonoBehaviour
{
    public TextAsset jsonText;

    [System.Serializable]
    public class JsonSpellsPointPos
    {
        public List<Vector3> spellCastingSign;
    }

    [System.Serializable]
    public class SpellPosList
    {
        public JsonSpellsPointPos[] spells;
    }

    public SpellPosList spellPosList = new SpellPosList();


    // Start is called before the first frame update
    void Awake()
    {
        spellPosList = JsonConvert.DeserializeObject<SpellPosList>(jsonText.text);
    }
}
