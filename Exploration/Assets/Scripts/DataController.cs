using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataController : MonoBehaviour {

    public GameObject CAD;
    //public Transform textMeshPrefab;
    public Font font;
    public Material[] fontMaterials;
    public Vector3 offset = Vector3.zero;
   
    private DataModel data;
    private DataView view;
    private Vector3 offsetTemp;
    private List<GameObject> textMeshesTemp;

	// Use this for initialization
	void Start () {

        data = new DataModel(CAD);
        view = new DataView(data);
        view.createTextmesh(font, fontMaterials);

        //view.Offset = offset;
        textMeshesTemp = view.TextMeshes;
	}
	
	// Update is called once per frame
    
	void Update () {
        //TOTO: FIX status tracking
        if (Camera.main.transform.hasChanged)
        {
            Debug.Log("Transform changed to: " + Camera.main.transform.position);
            foreach (GameObject go in view.TextMeshes)
            {
                //TODO: FIX center pivot depending on text.lenght
                //TODO: FIX reverse heading to cam
                //Vector3 heading = Camera.main.transform.position - go.transform.position;
                go.transform.LookAt(Camera.main.transform.position);//- heading
            }
        }

        //Adjust postion of all TextMeshes in Scene according to & on change of offset.
        if (offsetTemp != offset)
        {
            globalDataOffset();
        }
	}

    private void globalDataOffset() 
    {
        //TOTO: FIX transform relative to labeled model-part
        for (int i =0; i < view.TextMeshes.Count; i++)
        {
            //Vector3 pos = go.transform.position
            view.TextMeshes[i].transform.position = textMeshesTemp[i].transform.position;
            view.TextMeshes[i].transform.position = textMeshesTemp[i].transform.position + offset;//pos + offset;
            //pos = Vector3.zero;
        }
        offsetTemp = offset;
    }

}
