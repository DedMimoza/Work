using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Taill
{
    private float _offset;
    private GameObject _prev;
    public GameObject tailComp;
    public Vector3 oldpost;
    public Renderer renderer;
    public BoxCollider boxCollider;

    public Taill(GameObject prev, GameObject tailComp)
    {
        _prev = prev;
        this.tailComp = tailComp;
        renderer = tailComp.GetComponent<Renderer>();
        boxCollider = tailComp.GetComponent<BoxCollider>();
    }

    public IEnumerator MoveTail(Vector3 oldpos)
    {
        if (Movment2.feawer)
        {
            yield return new WaitForSeconds(.08f);

        }
        else
        {
            yield return new WaitForSeconds(.08f/8);

        }
        //yield return new WaitForSeconds(.08f);
        _offset = _prev.transform.localScale.x;
        tailComp.transform.position = new Vector3(oldpos.x, oldpos.y, oldpos.z - _offset);
        oldpost = tailComp.transform.position;
    }
    
     

}
