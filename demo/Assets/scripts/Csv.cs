﻿using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Csv 
{
    private static Csv csv;
    private int[,] map;
    public static Csv getInstance(){
        if(csv==null){
            csv=new Csv();
        }
        return csv;
    }
    public string FileCSV(string _str)
    {
        string path = "";
    #if UNITY_EDITOR     
	path = Application.dataPath + "/StreamingAssets/Csv/" + _str + ".csv";
    #elif UNITY_IPHONE
	path = Application.dataPath + "/Raw/Csv/" + _str + ".csv";
    #elif UNITY_ANDROID
	path = Application.streamingAssetsPath + "/StreamingAssets/Csv/"+ _str +".csv";
    #endif
      	Debug.Log (path);
        return path;
}
    public void readCsv(int[,] number , string path,int map,ref int count){
        int start;
        try{
                using(var sr= new System.IO.StreamReader(path)){
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

    public void readMap(int map,int[,] number,ref int count){
        int start;
        string line = "1,0,1,15,1,0,0,1,1,0,2,40,1,0,0,1,1,0,3,65,0,1,0,1,1,0,4,85,0,1,0,1,1,1,1,110,2,0,0,1,1,1,2,125,2,0,0,1,1,1,3,145,1,1,0,1,1,1,4,165,2,1,0,1,1,1,5,185,1,2,0,1,1,2,1,210,1,1,0,1,1,2,2,225,1,1,0,1,1,2,3,245,1,1,0,1,1,2,4,265,2,1,0,1,1,2,5,285,2,1,0,1,1,3,1,310,2,1,0,1,1,3,2,325,2,1,0,1,1,3,3,345,2,1,0,1,1,3,4,365,2,1,0,1,1,3,5,385,2,1,0,1,1,4,1,410,2,1,0,1,1,4,2,425,3,2,0,1,1,4,3,445,4,3,0,1,1,4,4,465,5,4,0,1,1,4,5,485,6,5,0,1,1,5,1,510,2,2,0,1,1,5,2,525,3,3,0,1,1,5,3,545,5,5,0,1,1,5,4,565,5,5,0,1,1,5,5,585,0,0,1,0,2,1,1,10,2,0,0,1,2,1,2,25,2,0,0,1,2,1,3,45,1,1,0,1,2,1,4,65,3,2,0,1,2,1,5,85,2,2,0,1,2,2,1,110,1,1,0,1,2,2,2,125,1,1,0,1,2,2,3,145,0,2,0,0,2,2,4,165,4,3,0,1,2,2,5,185,5,3,0,1,2,3,1,210,2,1,0,1,2,3,2,225,2,1,0,1,2,3,3,245,2,2,0,1,2,3,4,265,4,3,0,1,2,3,5,285,5,3,0,1,2,4,1,310,3,1,0,1,2,4,2,325,4,2,0,1,2,4,3,345,5,3,0,1,2,4,4,365,6,4,0,1,2,4,5,385,7,5,0,1,2,5,1,410,4,4,0,1,2,5,2,425,8,6,0,1,2,5,3,445,8,8,0,1,2,5,4,465,10,7,0,1,2,5,5,485,0,0,1,0,3,1,1,10,2,0,0,1,3,1,2,25,2,0,0,1,3,1,3,45,1,1,0,1,3,1,4,65,3,2,0,1,3,1,5,85,2,2,0,1,3,2,1,110,1,1,0,1,3,2,2,125,0,2,0,0,3,2,3,145,0,2,0,0,3,2,4,165,4,3,0,1,3,2,5,185,5,3,0,1,3,3,1,210,2,1,0,1,3,3,2,225,2,1,0,1,3,3,3,245,2,2,0,1,3,3,4,265,4,3,0,1,3,3,5,285,5,3,0,1,3,4,1,310,2,1,0,1,3,4,2,325,3,2,0,1,3,4,3,345,4,3,0,1,3,4,4,365,5,4,0,1,3,4,5,385,6,5,0,1,3,5,1,410,4,4,0,1,3,5,2,425,6,6,0,1,3,5,3,445,7,7,0,1,3,5,4,465,8,8,0,1,3,5,5,485,0,0,1,0,4,1,1,10,1,1,0,1,4,1,2,25,2,0,0,1,4,1,3,45,1,1,0,1,4,1,4,65,2,2,0,1,4,1,5,85,0,4,0,0,4,2,1,110,0,2,0,0,4,2,2,125,1,2,0,1,4,2,3,145,1,3,0,1,4,2,4,165,3,2,0,1,4,2,5,185,3,5,0,1,4,3,1,210,1,2,0,1,4,3,2,225,1,2,0,1,4,3,3,245,2,2,0,1,4,3,4,265,3,4,0,1,4,3,5,285,3,5,0,1,4,4,1,310,1,2,0,1,4,4,2,325,2,3,0,1,4,4,3,345,3,4,0,1,4,4,4,365,4,5,0,1,4,4,5,385,5,6,0,1,4,5,1,410,2,2,0,1,4,5,2,425,3,3,0,1,4,5,3,445,7,7,0,1,4,5,4,465,8,8,0,1,4,5,5,485,0,0,1,0";
        string[] values=line.Split(',');
        for(int i=0;i<104;i++){
        if(int.TryParse(values[i*8],out start)&&start==map){
            for(int j=0;j<8;j++){
                int.TryParse(values[i*8+j],out number[count,j]);
            }
         count++;
        }
        }


    }
}