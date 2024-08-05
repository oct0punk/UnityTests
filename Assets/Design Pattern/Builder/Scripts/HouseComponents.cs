using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New House", menuName = "House")]
public class HouseComponents : ScriptableObject
{
    public GameObject house;
    public GameObject garage;
    public GameObject statues;
    public GameObject pool;
    public GameObject garden;
    [Space]
    public GameObject flatRoof;
    public GameObject roundRoof;
    public GameObject pointyRoof;
}
