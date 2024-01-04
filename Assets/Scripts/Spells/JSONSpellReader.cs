using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using Newtonsoft.Json;

public class JSONSpellReader : MonoBehaviour
{
    public TextAsset jsonText;

    public class SpellCastingSign
    {
        public double x;
        public double y;
        public double z;
    }

    [System.Serializable]
    public class JsonSpells
    {
        public string name;
        public int cooldown;
        public List<SpellCastingSign> spellCastingSign;
    }
    
    [System.Serializable]
    public class SpellList
    {
        public JsonSpells[] spells;
    }

    public SpellList spellList = new SpellList();


    // Start is called before the first frame update
    void Start()
    {
        spellList = JsonConvert.DeserializeObject<SpellList>(jsonText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
