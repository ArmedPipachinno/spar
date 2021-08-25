using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    // Keep Tower Type (note : maybe can keep in form of array)
    [SerializeField] private GameObject Tower_1;
    [SerializeField] private GameObject Tower_2;
    [SerializeField] private GameObject Tower_3;

    public void GenTower_1()
    {
        print("GenTower1");
        Vector2 placePos = GameManage.clickPos;
        Instantiate(Tower_1, placePos, Quaternion.identity);
        GameManage.currentGameUI = GameManage.GameUI.playing;
        MapGenerator.mapCheck[(int)placePos.x, (int)-placePos.y] = true;
    }

    public void GenTower_2()
    {
        print("GenTower2");
        Vector2 placePos = GameManage.clickPos;
        Instantiate(Tower_2, placePos, Quaternion.identity);
        GameManage.currentGameUI = GameManage.GameUI.playing;
        MapGenerator.mapCheck[(int)placePos.x, (int)-placePos.y] = true;
    }

    public void GenTower_3()
    {
        print("GenTower3");
        Vector2 placePos = GameManage.clickPos;
        Instantiate(Tower_3, placePos, Quaternion.identity);
        GameManage.currentGameUI = GameManage.GameUI.playing;
        MapGenerator.mapCheck[(int)placePos.x, (int)-placePos.y] = true;
    }
}
