using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class CarConfig : ScriptableObject
{
    public Car prefab;
    public int speed = 100;
    public Color color;
    public float timeToTurn;
}
