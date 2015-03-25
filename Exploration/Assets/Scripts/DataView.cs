using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DataView {

    private Vector3 offset = Vector3.zero;   
    private List<GameObject> textMeshes = new List<GameObject>();
    private DataModel data;


    public DataView(DataModel data)
    {
        this.data = data;
        //createTextmesh();
    }


    /**
     * Creates TextMeshes according to Model-Parts
     * TODO: FIX hardcoded attributes!
     */

    public void createTextmesh (Font font, Material[] fontMaterials)
    {
        int count = 1;

        foreach (DataNode node in data.DataNodes)
        {
            //Transform txtMeshTransform = textMeshPrefab;// (Transform)Instantiate(textMeshPrefab);
            //TextMesh txtMesh = txtMeshTransform.GetComponent<TextMesh>();
            //txtMesh.text = node.Name;
            //txtMesh.color = Color.red; // Set the text's color to red
            //txtMeshTransform.position = node.Position;
            //textMeshes.Add(txtMeshTransform); //Add to list.
            GameObject textObject = new GameObject("txt" + count);
            textObject.transform.position = node.Position;
            //textObject.transform.RotateAround(node.Position, Vector3.up, 180 * Time.deltaTime);
            textObject.AddComponent<TextMesh>();
            //textObject.AddComponent("MeshRenderer");

            TextMesh textMeshComponent = textObject.GetComponent(typeof(TextMesh)) as TextMesh;
            textMeshComponent.font = font;
            textMeshComponent.fontSize = 300;
            textMeshComponent.characterSize = .009f;
            textMeshComponent.alignment = TextAlignment.Center;

            MeshRenderer meshRendererComponent = textObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;

            textMeshComponent.text = node.Name;

            meshRendererComponent.materials = fontMaterials;
            textMeshes.Add(textObject);
            count++;
        }
    }
    /**
     * Reverses String.
     */
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        Debug.Log("Rervere string: " + new string(charArray));
        return new string(charArray);
    }


    //Getter & Setter
    public List<GameObject> TextMeshes
    {
        get { return textMeshes; }
        set { textMeshes = value; }
    }

    public Vector3 Offset
    {
        get { return offset; }
        set { offset = value; }
    }
}
