using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private TextAsset mapText;
    private string[] mapData;
    private int width, height;

    [SerializeField] private GameObject spawn;
    [SerializeField] private Vector2 spawnPos;


    private void Start()
    {
        GenerateGrid();
    }

    private string[] ReadText()
    {
        return mapText.text.Split('\n');
    }

    private void GenerateGrid()
    {
        mapData = ReadText();

        height = mapData.Count();
        width = mapData[0].Length;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width-1; x++)
            {
                float z = 0;
                int index = mapData[y][x] - '0';
                if(index == 0)
                {
                    z = -0.5f;
                }
                var spawnPlatform = Instantiate(platform[index], new Vector3(x, -y, z), Quaternion.identity);
                platform[index].name = $"Platform {x} {y}";
            }
        }

        Instantiate(spawn, new Vector3(spawnPos.x, -spawnPos.y, -1), Quaternion.identity);

        cameraPos.transform.position = new Vector3((float)width / 2 - 0.5f, (float)-height / 2 - 0.5f, -10.0f);
    }
}
