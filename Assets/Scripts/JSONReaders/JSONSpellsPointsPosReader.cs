using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class JSONSpellsPointsPosReader
{
    private TextAsset jsonText;

    [System.Serializable] public class JsonSpellPos
    {
        public List<Vector3> spellCastingSign;
    }

    public JsonSpellPos[] SpeelsPos = null;

    public JSONSpellsPointsPosReader(TextAsset jsonText)
    {
        this.jsonText = jsonText;
    }

    public void SetupSpells()
    {
        SpeelsPos = JsonConvert.DeserializeObject<JsonSpellPos[]>(jsonText.text);
    }
}
