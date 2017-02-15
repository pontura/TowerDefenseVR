using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    public GameObject ground;
	public GameObject world;
	public Transform heroTransform;

    static World mInstance = null;
    [HideInInspector]  public Settings settings;
    [HideInInspector]
    public Pathfinder pathfinder;

    public static World Instance
    {
        get  {  return mInstance;  }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;

        settings = GetComponent<Settings>();
        pathfinder = GetComponent<Pathfinder>();
    }

}
