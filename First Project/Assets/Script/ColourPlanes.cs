using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPlanes : MonoBehaviour
{
    public Material[] randomMaterials;
    public GameObject[] coloredWalls;
    void Start()
    {
        foreach (GameObject gameObject in coloredWalls)
        { 
            gameObject.GetComponent<Renderer>().material = randomMaterials[Random.Range(0, randomMaterials.Length)];
        }
    }
}
