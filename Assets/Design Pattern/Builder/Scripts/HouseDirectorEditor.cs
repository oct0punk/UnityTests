using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HouseDirector))]
public class HouseDirectorEditor : Editor
{
    string printHouse = "";
    RoofType roofType;
    bool withStatues;
    bool withPool;
    bool withGarage;
    bool withGarden;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
     
        IHouseBuilder builder = (target as HouseDirector).builder;
        GUILayout.Label(printHouse);
        if (GUILayout.Button("Reset"))
        {
            printHouse = "";
            withStatues = false;
            withPool = false;
            withGarage = false;
            withGarden = false;
            builder.Reset();
        }
        
        if (GUILayout.Toggle(withStatues, "Add Statues"))
        {
            withStatues = true;
            builder.WithFancyStatues();
        }
        if (GUILayout.Toggle(withGarden, "Add Garden"))
        {
            withGarden = true;
            builder.WithGarden();
        }
        if (GUILayout.Toggle(withGarage, "Add Garage"))
        {
            withGarage = true;
            builder.WithGarage();
        }
        if (GUILayout.Toggle(withPool, "Add SwimmingPool"))
        {
            withPool = true;
            builder.WithSwimmingPool();
        }

        roofType = (RoofType)EditorGUILayout.EnumPopup(roofType);
        if (GUILayout.Button("Generate"))
        {
            builder.SetRoofType(roofType);
            printHouse = builder.Build().print();                   // Build house from Builder AND print house description
            (target as HouseDirector).Generate(builder.Build());   //  Generate house object
        }

    }
}
