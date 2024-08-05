using System;
using UnityEngine;

[ExecuteAlways]
public class HouseDirector : MonoBehaviour
{
    public HouseComponents houseComponents;
    public IHouseBuilder builder { get; private set; }
    GameObject go;

    private void OnEnable()
    {
        builder = new HouseBuilder();
    }

    public House full_house()
    {
        return builder.Reset().WithFancyStatues().WithSwimmingPool().WithGarage().WithGarden().Build();
    }

    public void Generate(House house)
    {

        if (go != null)
        {
#if UNITY_EDITOR
            DestroyImmediate(go);
#else
            Destroy(go);
#endif
        }
        go = house.Generate(houseComponents);
        go.name = houseComponents.name;
        go.transform.position = transform.position;

        //GameObject roof;
        //switch (house.roof)
        //{
        //    case RoofType.round:
        //        roof = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //        roof.transform.SetParent(go.transform);
        //        roof.transform.localPosition = Vector3.up * house.stories * attributes.heightOfCeiling;
        //        roof.transform.localScale = new Vector3(house.L, 1, house.l) *.99f;
        //        break;
        //    case RoofType.pointy:
        //        roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        roof.transform.SetParent(houseObj.transform);
        //        roof.transform.localPosition = Vector3.up * attributes.heightOfCeiling * house.stories;
        //        roof.transform.localRotation = Quaternion.Euler(0, 0, 45);

        //        float sideSize = (float)(1.0f * house.L / Math.Sqrt(2));
        //        roof.transform.localScale = new Vector3(sideSize, sideSize, house.l) * .99f;
        //        break;
        //    default:
        //        roof = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //        roof.transform.SetParent(houseObj.transform);
        //        roof.transform.localPosition = Vector3.up * (.01f + attributes.heightOfCeiling * house.stories);
        //        roof.transform.localRotation = Quaternion.Euler(90, 0, 0);
        //        roof.transform.localScale = new Vector3(house.L, house.l, 1) * .99f;
        //        break;
        //}

    }

}