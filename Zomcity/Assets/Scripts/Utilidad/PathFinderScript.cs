using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderScript : MonoBehaviour
{
    public Vector4 wayPoint;
    public Vector2 goal;
    public Transform goalTransform;
    public List<Vector4> neighbors = new List<Vector4>();
    private void Start()
    {
        wayPoint = new Vector2((float)System.Math.Round(transform.position.x), (float)System.Math.Round(transform.position.y));
    }
    void Update()
    {
        goal = new Vector3((float)System.Math.Round(goalTransform.position.x), (float)System.Math.Round(goalTransform.position.y), 0);
        if (new Vector2((float)System.Math.Round(transform.position.x), (float)System.Math.Round(transform.position.y)) != goal)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, 0.01f);
            if (transform.position == new Vector3(wayPoint.x, wayPoint.y,0))
            {
                FindNeighbors();
            }
        }
    }
    public void FindNeighbors()
    {
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(0, 1)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(0, 1)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0, 1));
        }
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(0, -1)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(0, -1)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0, -1));
        }
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(1, 0)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(1, 0)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(1, 0));
        }
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(1, 1)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(1, 1)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(1, 1));
        }
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(1, -1)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(1, -1)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(1, -1));
        }
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(-1, 0)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(-1, 0)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(-1, 0));
        }
        if (Physics2D.OverlapPoint(wayPoint + new Vector4(-1, 1)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(-1, 1)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(-1, 1));
        }
        if(Physics2D.OverlapPoint(wayPoint + new Vector4(-1, -1)) == null || Physics2D.OverlapPoint(wayPoint + new Vector4(-1, -1)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(-1, -1));
        }
        for (int i = 0; i < neighbors.Count; i++)
        {
            neighbors[i] = new Vector4(neighbors[i].x, neighbors[i].y, (float)System.Math.Round(Vector2.Distance(neighbors[i], goal) + Vector2.Distance(wayPoint, neighbors[i])), (float)System.Math.Round(Vector2.Distance(neighbors[i], goal)));
        }
        neighbors.Sort((a,b) => a.z.CompareTo(b.z));
        if (neighbors[0].z == neighbors[0].z)
        {
            neighbors.Sort((a, b) => a.w.CompareTo(b.w));
        }
        wayPoint = neighbors[0];
        neighbors.Clear();
    }
}
