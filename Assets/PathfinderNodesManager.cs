using UnityEngine;
using System.Collections;

public class PathfinderNodesManager : MonoBehaviour {

    public PathFinderNode GetNewPath(PathFinderNode oldNode)
    {
        if (oldNode.childs.Length == 0)
            return null;
		return oldNode.childs[Random.Range(0,oldNode.childs.Length)];
    }
}
