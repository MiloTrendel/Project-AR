using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateContext
{
    // Propreties here

    public GenericPlayer Player1, Player2;

    public GameStateContext()
    {
    }

    public GenericPlayer GetEnemy(GenericPlayer target)
    {
        if (target == null)
            return null;
        if (Player1 == null || Player2 == null)
            return null;

        if (Player1.Equals(target))
            return Player2;
        if (Player2.Equals(target))
            return Player1;
        return null;
    }
}