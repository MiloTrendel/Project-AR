using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using Newtonsoft.Json;
using System.Linq;

public class JSONSpellReader : MonoBehaviour
{
    public TextAsset jsonText;

    [System.Serializable]
    public class JsonSpells
    {
        public string name;
        public int cooldown;
        public int spellID;
        public int mana;
        public List<Vector3> spellCastingSign;
    }
    
    [System.Serializable]
    public class SpellList
    {
        public JsonSpells[] spells;
    }

    public SpellList spellList = new SpellList();


    // Start is called before the first frame update
    void Awake()
    {
        spellList = JsonConvert.DeserializeObject<SpellList>(jsonText.text);
    }
}
