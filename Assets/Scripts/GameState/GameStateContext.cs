public static class GameStateContext
{
    // Propreties here

    public static GenericPlayer Player1, Player2;

    public static GenericPlayer GetEnemy(GenericPlayer target)
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