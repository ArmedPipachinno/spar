using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    // Keep Type of Platform (Should be Prefabs)
    [SerializeField] private GameObject[] platform;

    [SerializeField] private Transform cameraPos;
    [SerializeField] private TextAsset mapText;
    
    // Keep MapData that read from text
    private string[] mapData;

    // For Checking that this grid has tower or not
    public static bool[,] mapCheck;

    private int width, height;

    [SerializeField] private GameObject spawn;
    [SerializeField] private Vector2 spawnPos;


    private void Start()
    {
        GenerateGrid();
        // Set size of 2D Array
        mapCheck = new bool[width, height];
    }

    private string[] ReadText()
    {
        // Read Text and Split in form of String Array
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
                // Find Index(Type of Tiles)
                int index = mapData[y][x] - '0';
                // Create Type of Tiles
                var spawnPlatform = Instantiate(platform[index], new Vector3(x, -y, 0), Quaternion.identity);
                //platform[index].name = $"Platform {x} {y}";
            }
        }

        // Create Portal for Spawn Enemies
        Instantiate(spawn, new Vector3(spawnPos.x, -spawnPos.y, -1), Quaternion.identity);

        // Change CameraPosition Depend of Size of Map
        cameraPos.transform.position = new Vector3((float)width / 2 - 0.5f, (float)-height / 2 - 0.5f, -10.0f);
    }
}
