using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPlanes : MonoBehaviour
{
    public Material[] randomMaterials;
    public GameObject[] colorPlanes;
    public List<Material> matList = new List<Material>();



    void Start()
    {
        DeployMaterials();
    }

    private void CheckList()
    {
        if (matList.Count == 0)
        {
            matList.AddRange(randomMaterials);
        }
    }

    private void DeployMaterials()
    {
        for (int i = 0; i < colorPlanes.Length; i++)
        {
            CheckList();
            colorPlanes[i].GetComponent<MeshRenderer>().material = matList[0];
            matList.RemoveAt(0);
        }
    }
}
