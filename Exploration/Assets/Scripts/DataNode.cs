using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataNode
{

    private int id = 0;


    private string name = "name";
    private float weight = 1.0f;
    private DataNode parent = null;

    private Vector3 position = new Vector3(0,0,0);
    private List<DataNode> children = new List<DataNode>();

    public DataNode(GameObject obj)
    {
        name = obj.name;
        position = obj.transform.position;
    }


    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }

    public DataNode Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    public void addChild(DataNode child)
    {
        children.Add(child);
    }
}
