
public class Statistic
{
    private int point = 0;
    private int level = 0;
    private string NextScene;
    private static Statistic instance = new Statistic();
    private Statistic() { }
    public static Statistic getInstance()
    {
        return instance;
    }
    public void setPoint(int point)
    {
        this.point = point;
    }
    public void setLevel(int level){
        this.level = level;
    }
    public void setNextScene(string name){
        this.NextScene=name;
    }

    public int getPoint()
    {
        return this.point;
    }
    public int getLevel(){
        return this.level;
    }
    public string getNextScene(){
        return this.NextScene;
    }
}
