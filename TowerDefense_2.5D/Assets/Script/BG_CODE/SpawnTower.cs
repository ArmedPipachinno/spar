using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    // Keep Tower Type (note : maybe can keep in form of array)
    [SerializeField] private GameObject Tower_1;
    [SerializeField] private GameObject Tower_2;
    [SerializeField] private GameObject Tower_3;

    [SerializeField] private int costTower_1;
    [SerializeField] private int costTower_2;
    [SerializeField] private int costTower_3;

    private GameManage gameManageSC;

    private void Start()
    {
        gameManageSC = GetComponent<GameManage>();
    }

    public void GenTower_1()
    {
        if (gameManageSC.GetMoney() >= costTower_1)
        {
            print("GenTower1");
            Vector2 placePos = GameManage.clickPos;
            GameObject T1 = Instantiate(Tower_1, placePos, Quaternion.identity);
            GameManage.currentGameStatus = GameManage.GameStatus.PLAY;
            MapGenerator.mapCheck[(int)placePos.x, (int)-placePos.y] = true;
            GetComponent<MapGenerator>().SetTower((int)placePos.x, (int)-placePos.y, T1);
            gameManageSC.AddMoney(-costTower_1);
        }
    }

    public void GenTower_2()
    {
        if (gameManageSC.GetMoney() >= costTower_2)
        {
            print("GenTower2");
            Vector2 placePos = GameManage.clickPos;
            GameObject T2 = Instantiate(Tower_2, placePos, Quaternion.identity);
            GameManage.currentGameStatus = GameManage.GameStatus.PLAY;
            MapGenerator.mapCheck[(int)placePos.x, (int)-placePos.y] = true;
            GetComponent<MapGenerator>().SetTower((int)placePos.x, (int)-placePos.y, T2);
            gameManageSC.AddMoney(-costTower_2);
        }
    }

    public void GenTower_3()
    {
        if (gameManageSC.GetMoney() >= costTower_3)
        {
            print("GenTower3");
            Vector2 placePos = GameManage.clickPos;
            GameObject T3 = Instantiate(Tower_3, placePos, Quaternion.identity);
            GameManage.currentGameStatus = GameManage.GameStatus.PLAY;
            MapGenerator.mapCheck[(int)placePos.x, (int)-placePos.y] = true;
            GetComponent<MapGenerator>().SetTower((int)placePos.x, (int)-placePos.y, T3);
            gameManageSC.AddMoney(-costTower_3);
        }
    }

    public void Sell()
    {
        int _xPos = (int)GameManage.clickPos.x;
        int _yPos = (int)GameManage.clickPos.y;
        Destroy(GetComponent<MapGenerator>().GetTower(_xPos, -_yPos));
        MapGenerator.mapCheck[_xPos, -_yPos] = false;
        GameManage.currentGameStatus = GameManage.GameStatus.PLAY;
    }

    public void Upgrade()
    {

    }
}
