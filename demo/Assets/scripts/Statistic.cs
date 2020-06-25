
public class Statistic
{
    private int point = 0;
    private int map = 1;
    private string NextScene;
    private bool[] success=new bool[4];
    private static Statistic instance = new Statistic();
    private Statistic() { 
        success[0]=true;
        for(int i=1;i<4;i++){
            success[i]=false;
        }
    }
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
    public void setSuccess(int n){
        this.success[n]=true;
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
    public bool getSuccess(int n){
        return success[n];
    }
}
