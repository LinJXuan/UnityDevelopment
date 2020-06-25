

public class Player : PlayerAttribute
{
    private int levelPoint;

    private static Player instance = new Player(200,100,10,10,0);

    public Player(int hp, int energy,int attack, int defense,int levelPoint) : base(hp,energy,attack, defense)
    {
        this.levelPoint=levelPoint;
    }

    public static Player getInstance()
    {
        return instance;
    }

    public void setlevelPoint(int n){
        this.levelPoint=n;
    }

    public int getlevelPoint(){
        return this.levelPoint;
    }
}