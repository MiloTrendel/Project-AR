using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.VisualScripting;

public class JSONSpellsInfoReader
{
    private TextAsset jsonText;

    [System.Serializable] public class JsonSpell
    {
        public string Name;
        public int Cooldown;
        public int SpellID;
        public int Mana;
    }
    
    public JsonSpell[] SpellsInfo = null;

    public JSONSpellsInfoReader(TextAsset jsonText)
    {
        this.jsonText = jsonText;
    }

    public void SetupSpells()
    {
        SpellsInfo = (JsonConvert.DeserializeObject<JsonSpell[]>(jsonText.text));
    }
}
