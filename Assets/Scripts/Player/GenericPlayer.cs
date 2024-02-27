using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPlayer
{
    public List<Spell> spells { get; protected set; } = new();
    public int level { get; protected set; } = 0;
    public int score { get; set; } = 0;

    protected virtual void Dance()
    {

    }

    protected virtual void Block()
    {

    }

    protected virtual void Attack(GenericPlayer target)
    {

    }
}
