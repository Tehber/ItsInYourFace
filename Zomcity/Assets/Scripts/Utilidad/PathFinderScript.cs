using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderScript : MonoBehaviour
{
    public Vector4 wayPoint;
    public Vector2 goal;
    public Transform goalTransform;
    public List<Vector4> neighbors = new List<Vector4>();
    public int v;
    private void Start()
    {
        wayPoint = new Vector2((float)System.Math.Round(transform.position.x), (float)System.Math.Round(transform.position.y));
    }
    void Update()
    {
        goal = new Vector3((float)System.Math.Round(goalTransform.position.x), (float)System.Math.Round(goalTransform.position.y), 0);
        if (new Vector2((float)System.Math.Round(transform.position.x), (float)System.Math.Round(transform.position.y)) != goal)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, 0.03f);
            if (transform.position == new Vector3(wayPoint.x, wayPoint.y,0))
            {
                FindNeighbors();
            }
        }
    }
    public void FindNeighbors()
    {
        v = 0;
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(0, 0.5f)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(0, 0.5f)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0, 0.5f));
        }
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(0, -0.5f)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(0, -0.5f)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0, -0.5f));
        }
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(0.5f, 0)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(0.5f, 0)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0.5f, 0));
        }
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(0.5f, 0.5f)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(0.5f, 0.5f)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0.5f, 0.5f));
        }
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(0.5f, -0.5f)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(0.5f, -0.5f)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(0.5f, -0.5f));
        }
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(-0.5f, 0)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(-0.5f, 0)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(-0.5f, 0));
        }
        if (Physics2D.OverlapPoint(this.transform.position + new Vector3(-0.5f, 0.5f)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(-0.5f, 0.5f)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(-0.5f, 0.5f));
        }
        if(Physics2D.OverlapPoint(this.transform.position + new Vector3(-0.5f, -0.5f)) == null || Physics2D.OverlapPoint(this.transform.position + new Vector3(-0.5f, -0.5f)).isTrigger)
        {
            neighbors.Add(wayPoint + new Vector4(-0.5f, -0.5f));
        }
        for (int i = 0; i < neighbors.Count; i++)
        {
            neighbors[i] = new Vector4(neighbors[i].x, neighbors[i].y, ((float)System.Math.Round(Vector2.Distance(neighbors[i], goal) + Vector2.Distance(wayPoint, neighbors[i])))*10, ((float)System.Math.Round(Vector2.Distance(neighbors[i], goal)))*10);
        }
        neighbors.Sort((a,b) => a.z.CompareTo(b.z));
        if (neighbors[0].z == neighbors[1].z)
        {
            neighbors.Sort((a, b) => a.w.CompareTo(b.w));
        }
        if (neighbors[0].w == neighbors[1].w)
        {
            v = neighbors.FindIndex(v => v.x == wayPoint.x +0.5 && v.y == wayPoint.y+0);
            if (v == -1)
            {
                v = neighbors.FindIndex(v => v.x == wayPoint.x + 0 && v.y == wayPoint.y + 0.5);
                if (v == -1)
                {
                    v = neighbors.FindIndex(v => v.x == wayPoint.x + (-0.5) && v.y == wayPoint.y + 0);
                    if (v == -1)
                    {
                        v = neighbors.FindIndex(v => v.x == wayPoint.x + 0 && v.y == wayPoint.y + (-0.5));
                        if (v == -1)
                        {
                            return;
                        }
                    }
                }
            }
        }
        wayPoint = neighbors[v];
        v = 0;
        neighbors.Clear();
    }
}
