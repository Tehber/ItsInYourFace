using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderScript : MonoBehaviour
{
    public List<Vector4> closedList = new List<Vector4>();
    public List<Vector4> openList = new List<Vector4>();
    public Vector2 goal;
    public Transform goalTransform;
    public List<Vector4> neighbors = new List<Vector4>();
    public bool lol = false;
    private void Start()
    {
        closedList.Add(new Vector3((float)System.Math.Round(transform.position.x), (float)System.Math.Round(transform.position.y), 0));
    }
    void Update()
    {
        goal = new Vector3((float)System.Math.Round(goalTransform.position.x), (float)System.Math.Round(goalTransform.position.y), 0);
        if (new Vector2(closedList[closedList.Count-1].x, closedList[closedList.Count-1].y) != goal)
        {
            FindNeighbors();   
        }
        if (lol == false && new Vector2(closedList[closedList.Count - 1].x, closedList[closedList.Count - 1].y) == goal)
        {
            foreach(var v in closedList)
            {
                transform.position = new Vector2(v.x,v.y);
            }
            lol = true;
        }
    }
    public void FindNeighbors()
    {
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(0, 1));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(0, -1));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(1, 0));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(1, 1));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(1, -1));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(-1, 0));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(-1, 1));
        neighbors.Add(closedList[closedList.Count - 1] + new Vector4(-1, -1));
        for (int i = 0; i < neighbors.Count; i++)
        {
            neighbors[i] = new Vector4(neighbors[i].x, neighbors[i].y, (float)System.Math.Round(Vector2.Distance(neighbors[i], goal) + Vector2.Distance(closedList[closedList.Count - 1], neighbors[i])), (float)System.Math.Round(Vector2.Distance(neighbors[i], goal)));
        }
        neighbors.Sort((a,b) => a.z.CompareTo(b.z));
        if (neighbors[0].z == neighbors[0].z)
        {
            neighbors.Sort((a, b) => a.w.CompareTo(b.w));
        }
        closedList.Add(neighbors[0]);
        neighbors.Clear();
    }
}
