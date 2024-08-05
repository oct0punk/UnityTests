using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Composite : MonoBehaviour
{
    public abstract void Operation();
}

public class Branch : Composite
{
    public List<Composite> content = new List<Composite>();
    public SpriteRenderer spr;
    
    [Min(0.0f)] public float height = 1.0f;
    [Range(10.0f, 170.0f)] public float angle = 45;

    public Leaf leafPrefab;
    public Branch branchPrefab;


    private void OnValidate()
    {
        Operation();
    }


    public void AddBranch()
    {
        Branch b = Instantiate(branchPrefab, transform);
        b.transform.localPosition = Vector3.up * height;
        content.Add(b);
        Operation();
    }


    public void AddLeaf()
    {
        Leaf l = Instantiate(leafPrefab, transform);
        l.transform.localPosition = Vector3.up * Random.Range(0.0f, height);
        content.Add(l);
        Operation();
    }

    public void Clear()
    {
        foreach (Composite c in content)
        {
            if (c is Branch)
                DestroyImmediate(c.gameObject);
            if (c is Leaf)
                DestroyImmediate(c.gameObject);
        }
        content.Clear();
    }


    public override void Operation()
    {
        spr.transform.localPosition = Vector3.up * height / 2;
        spr.transform.localScale = new Vector3(.2f, height, 1.0f);
        

        int length = content.Count;
        if (length == 0) return;

        for (int i = 0; i <= (length - 1) / 2; i++)
        {
            float alpha = 1.0f * i / length;
            float val = Mathf.Lerp(angle * 1.0f, 0.0f, alpha * 2.0f);

            content[i].transform.localRotation              = Quaternion.Euler(0, 0, val);
            content[length-1 - i].transform.localRotation   = Quaternion.Euler(0, 0, -val);
        }

        foreach (Composite composite in content)
            composite.Operation();
    }
}

[CustomEditor(typeof(Branch))]
public class BranchEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(10);

        if (GUILayout.Button("Add Branch"))
        {
            ((Branch)target).AddBranch();
        }
        if (GUILayout.Button("Add Leaf"))
        {
            ((Branch)target).AddLeaf();
        }

        if (GUILayout.Button("Clear"))
        {
            ((Branch)target).Clear();
        }
    }
}
