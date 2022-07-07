using UnityEngine;


public class PlayerVirusControl : ScriptableObject
{

    public enum VIRUSCONDITION
    {
        TIRE        =    -2,
        SURPRISE    =    -1,
        NORMAL      =      0,
        HAPPY       ,
    }

    //感染領域の現在の限界値
     float InfectAreaLimitRadius;

    //感染領域の現在の半径の値
    float InfectAreaRadius;

    //感染させるためのパワー
    float InfectPower;

    //VirusのTension
   float VirusTension;

    //  [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        // EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }

    void VirusInfection()
    {

    }

    void InfectionAreaEnlargement()
    {

    }
}