using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public string Name { get; set; }
    public int Cooldown { get; set; }
    public int SpellID { get; set; }
    public int Mana { get; set; }
    public List<Vector3> SpellCastingSign { get; set; }

    public Transform ParticuleSpawn { get; set; }
    public GameObject ParticulePrefab { get; set; }

    public SpellManager spellManager { get; set; }
    public GenericPlayer player { get; set; }

    protected Spell()
    {
    }

    public virtual bool Cast()
    {
        if (player.SpellsCooldown[Name] > 0)
            return false;
        UnityEngine.Debug.Log("Cast " + Name);

        if (player.Mana < Mana)
        {
            player.Mana -= Mana;
            return false;
        }

        return true;
    }
}




// Specific Spells
//

#region Specific Spells
public class Spawn : Spell
{
    public Spawn()
    {
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;

        GenericParticule newParticule = new(ParticulePrefab);
        player.AddParticule(newParticule);

        spellManager.StartCoroutine(PendAndKillParticule(newParticule.LifeTime, newParticule));
        return true;
    }
    protected IEnumerator PendAndKillParticule(float time, GenericParticule particule)
    {
        GameObject.Destroy(particule.ParticuleGO, time);
        yield return new WaitForSeconds(time);
        GameStateContext.Player1.RemoveParticule(particule);
    }
}

public class Tornado : Spell
{
    public Tornado()
    {
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;
        spellManager.StartCoroutine(RotateParticules());
        return true;
    }

    private IEnumerator RotateParticules()
    {
        bool turning = true;
        int loop = 0;
        while (turning)
        {
            foreach (GenericParticule part in player.Particules)
            {
                part.ParticuleGO.transform.RotateAround(ParticuleSpawn.transform.position, part.ParticuleGO.transform.forward, 1);
            }
            loop++;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(1.0f);
    }
}

public class Centre : Spell
{
    public Centre()
    {
    }

    public override bool Cast()
    {
        if (!base.Cast())
            return false;
        return true;
    }
}
#endregion