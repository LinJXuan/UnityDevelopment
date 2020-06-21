using System;
using System.Collections.Generic;


public class Csv 
{
    private static Csv csv;

    public static Csv getInstance(){
        if(csv==null){
            csv=new Csv();
        }
        return csv;
    }

    public void readCsv(int[,] number , string path,string filename,int map,ref int count){
        int start;
        try{
                using(var sr= new System.IO.StreamReader(path+"//"+filename)){
                    while(!sr.EndOfStream){
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');
                        if(int.TryParse(values[0],out start)&&start==map){
                            for(int i=0;i<values.Length;i++){
                            int.TryParse(values[i],out number[count,i]);
                            }
                            count++;
                        }
      
                    }
                }
            }
            catch (System.Exception e){
                Console.WriteLine(e.Message);
                //System.Environment.Exit(0);   
            }
    }


}
