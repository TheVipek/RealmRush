using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static Path instance;
    [SerializeField] List<Tile> path = new List<Tile>();
    public List<Tile> pathElements{ get {return path; } }
    void Awake() {
        instance=this;
        getPath();
    }
    void getPath()
    {
        foreach (Transform child in gameObject.transform)
        {
            Tile waypoint =child.GetComponent<Tile>();
            if(waypoint!=null)
            {
                path.Add(waypoint);
            }
        }
    }
}
