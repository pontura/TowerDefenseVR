using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour {
    
    public GameObject containers1;
    public GameObject containers2;
    public GameObject containers3;

    void Start() {
        foreach (PathFinderNode pfn in containers1.GetComponentsInChildren<PathFinderNode>())
                 pfn.GetComponent<MeshRenderer>().enabled = false;
    }
}
