using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stat", menuName = "Characters/Enemies")]
public class EnemyProperties : ScriptableObject
{
    public string name;

    public float health;
    public float defense;

    public float speed;
}
