using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Head
{
    public float spped = 3f;
    
    public GameObject head;
    public Renderer renderer;
    private Vector2 _startPos;
    private Ray _ray;
    private RaycastHit _hit;
    
    public Head(GameObject head)
    {
        this.head = head;
        renderer = this.head.GetComponent<Renderer>();
    }

    public void Move()
    {
        /*if (-2.2 < head.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * spped &&
            head.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * spped < 2.2)
            head.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * spped, 0, 0);*/
        head.transform.position += new Vector3(0, 0, spped * Time.deltaTime);

        if (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Moved) return;
        _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (!Physics.Raycast(_ray, out _hit)) return;
        if (!_hit.collider.CompareTag("Finish")) return;
        var position = head.transform.position;
        Vector3 pos = new Vector3(_hit.point.x,position.y,position.z);
        position = Vector3.Lerp(position,pos,Time.deltaTime*spped*10);
        head.transform.position = position;
    }

    public void ChangeColor(Color clr)
    {
        head.GetComponent<Renderer>().material.color = clr;
    }

    public void Feaver()
    {
        var position = head.transform.position;
        position += new Vector3(0, 0, spped * Time.deltaTime*3);
        position = Vector3.Lerp(position,new Vector3(0,position.y,position.z),spped*3f*Time.deltaTime );
        head.transform.position = position;
        Movment2.feawer = false;

    }
/*
    IEnumerator feawer()
    {
        yield return new WaitForSeconds(5f);
    }
    */
    
}
