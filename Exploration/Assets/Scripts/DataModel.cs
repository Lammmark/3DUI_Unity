using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataModel
{
    private GameObject CAD = null;      //CAD-Model
    private List<DataNode> dataNodes = new List<DataNode>();        //List of MetaData-Nodes extracted from CAD-Model
    private List<GameObject> gameObjectNodes = new List<GameObject>();  //List containing all CAD-Model children.

    public DataModel(GameObject CAD)
    {
        this.CAD = CAD;
        Traverse(CAD);
    }

    public List<DataNode> DataNodes
    {
        get { return dataNodes; }

        set { dataNodes = value; }
    }
    /*
     * Traverse GameObject and set & connect MetaData-Nodes
     */
    void Traverse(GameObject obj)
    {
        Debug.Log(obj.name);
        //TODO: Create Nodes and connect.
        DataNode newNode = new DataNode(obj);
        //TODO: connect!
        if (obj.transform.childCount != 0)
        {

        }
        dataNodes.Add(newNode);
      

        foreach (Transform child in obj.transform)
        {
            Traverse(child.gameObject);
        }       
    }


}
