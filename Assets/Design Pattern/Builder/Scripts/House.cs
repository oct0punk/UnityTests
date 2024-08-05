using System;
using System.Collections.Generic;
using UnityEngine;

public class House
{
    List<string> extensions = new List<string>();
    public RoofType roof = RoofType.flat;

    public void AddExtension(string part)
    {
        if (!extensions.Contains(part))
             extensions.Add(part);
    }

    public GameObject Generate(HouseComponents components)
    {
        GameObject houseGo = UnityEngine.Object.Instantiate(components.house);
        foreach (string extension in extensions)
        {
            GameObject extensionGo = null;
            switch (extension)
            {   
                case "Statues":
                    extensionGo = UnityEngine.Object.Instantiate(components.statues);
                    extensionGo.name = "Statues";
                    break;
                case "Garage":
                    extensionGo = UnityEngine.Object.Instantiate(components.garage);
                    extensionGo.name = "Garage";
                    break;
                case "Garden":
                    extensionGo = UnityEngine.Object.Instantiate(components.garden);
                    extensionGo.name = "Garden";
                    break;
                case "SwimmingPool":
                    extensionGo = UnityEngine.Object.Instantiate(components.pool);
                    extensionGo.name = "Pool";
                    break;
                default:
                    continue;
            }
            extensionGo.transform.SetParent(houseGo.transform);
        }
        GameObject roofObj = null;
        switch (roof)
        {
            case RoofType.flat:
                roofObj = UnityEngine.Object.Instantiate(components.flatRoof); 
                break;
            case RoofType.round:
                roofObj = UnityEngine.Object.Instantiate(components.roundRoof);
                break;
            case RoofType.pointy:
                roofObj = UnityEngine.Object.Instantiate(components.pointyRoof);
                break;
        }
        roofObj.transform.SetParent(houseGo.transform);
        return houseGo;
    }

    public string print()
    {
        string description = "";
        foreach (string part in extensions)
        {
            description += part + ", ";
        }
        return $"House with {description} and a {Enum.GetName(typeof(RoofType), roof)} roof";
    }
}
