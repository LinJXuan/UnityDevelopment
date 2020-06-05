

public class Player : PlayerAttribute
{
    private static Player instance = new Player(100,5,3,10,10);

    public Player(int hp, int attack, int range, int shield, int defense) : base(hp, attack, range, shield, defense)
    {
    }

    public static Player getInstance()
    {
        return instance;
    }
}