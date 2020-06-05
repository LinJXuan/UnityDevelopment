
public class PlayerAttribute
{
    private int Hp;
    private int currentHp;
    private int Attack;
    private int Range;
    private int Shield;
    private int Defense;
 
    public PlayerAttribute() { currentHp = this.Hp; }
    public PlayerAttribute(int hp,int attack,int range,int shield,int defense)
    {
        this.Hp = hp;
        this.currentHp = hp;
        this.Attack = attack;
        this.Range = range;
        this.Shield = shield;
        this.Defense = defense;
    }
    public int getHp()
    {
        return this.Hp;
    }
    public int getcurrentHp()
    {
        return this.currentHp;
    }
    public int getAttack()
    {
        return this.Attack;
    }
    public int getRange()
    {
        return this.Range;
    }
    public int getShield()
    {
        return this.Shield;
    }
    public int getDefense()
    {
        return this.Defense;
    }

    public void setHp(int hp)
    {
        this.Hp=hp;
    }
    public void setcurrentHp(int hp){
        this.currentHp=hp;
    }
    public void reloadcurrentHp(){
        this.currentHp=this.Hp;
    }
    public void setAttack(int attack){
        this.Attack=attack;
    }
    public void setRange(int range){
        this.Range=range;
    }
    public void setShield(int shield){
        this.Shield=shield;
    }
    public void setDefense(int defense){
        this.Defense=defense;
    }
}
