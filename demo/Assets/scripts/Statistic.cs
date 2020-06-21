
public class Statistic
{
    private int point = 0;
    private int map = 0;
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
    public void setMap(int map){
        this.map = map;
    }
    public void setNextScene(string name){
        this.NextScene=name;
    }

    public int getPoint()
    {
        return this.point;
    }
    public int getMap(){
        return this.map;
    }
    public string getNextScene(){
        return this.NextScene;
    }
}
