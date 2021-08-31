using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform Head;
    public GameObject tailPart;
    public static Vector3 oldpos, newpos;
    public static float delta;
    public Vector3 scale;
    private List<GameObject> Tail_parts = new List<GameObject>();
    private List<Vector3> positions_v2 = new List<Vector3>();
    void Start()
    {
        positions_v2.Add(transform.position);
        Addtail();
        Addtail();
        newpos = Head.transform.position;
    }
    void FixedUpdate()
    {
        oldpos = newpos;
        newpos = Head.transform.position;
        float delta =Vector3.Distance(oldpos ,newpos);
        /*float dist = (Head.position - positions_v2[0]).magnitude;
        if (dist > scale.z)
        {
            Vector3 direct = (Head.transform.position - positions_v2[0]).normalized;
            positions_v2.Insert(0, Head.position+ direct*scale.z);
            positions_v2.RemoveAt(positions_v2.Count - 1);
            dist -= scale.z;
        }

        for (int i = 0; i < Tail_parts.Count; i++)
        {
            Tail_parts[i].transform.position =Vector3.Slerp(positions_v2[i + 1],positions_v2[i],dist/scale.z);
        }*/

    }

    void Addtail()
    {
        GameObject tail = Instantiate(tailPart, positions_v2[positions_v2.Count - 1], Quaternion.identity);
        Tail_parts.Add(tail);
        positions_v2.Add(tail.transform.position);
    }
}
