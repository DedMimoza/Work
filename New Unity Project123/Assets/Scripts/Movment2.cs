using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movment2 : MonoBehaviour
{
    public  Head _head;
    private  List<Taill> _taills = new List<Taill>();
    private  Vector3 _oldpos;
    private  GameObject _camera;
    private  float swapz;
    public static bool feawer = true;
    public static int fewcount=0;
    void Start()
    {
        
        _camera = GameObject.Find("Main Camera");
        
        _head = new Head(gameObject);
        _oldpos = transform.position;
        var localScale = _head.head.transform.localScale;

        var part = new Taill(_head.head,GameObject.CreatePrimitive(PrimitiveType.Cube));
        part.tailComp.transform.localScale = localScale;
        part.tailComp.GetComponent<BoxCollider>().enabled = false;
        part.tailComp.transform.position = _head.head.transform.position;
        part.renderer.material.color = _head.renderer.material.color;
        _taills.Add(part);
        
        Addpart();
    }

    private void FixedUpdate()
    {
        _oldpos = _head.head.transform.position;
        var moveTail1 = _taills[0].MoveTail(_oldpos);
        StartCoroutine(moveTail1);
        Taill.ccheck(0,_taills,_head,swapz);
        for (var i =1;i< _taills.Count;i++)
        {
            var moveTail = _taills[i].MoveTail(_taills[i-1].oldpost);
            StartCoroutine(moveTail);
            Taill.ccheck(0,_taills,_head,swapz);
        }
        
        if (fewcount == 3)
        {
            _head.Feaver();
            _camera.transform.position += new Vector3(0,0,_head.spped*Time.deltaTime*3);
            StartCoroutine(feaw());
        }
        else
        {
            _head.Move();
            _camera.transform.position += new Vector3(0,0,_head.spped*Time.deltaTime);
        }
 
    }
    
    void Addpart()
    {
        var part = new Taill(_taills[0].tailComp.gameObject, GameObject.CreatePrimitive(PrimitiveType.Cube));
        part.boxCollider.enabled = false;
        part.tailComp.transform.localScale = _head.head.transform.localScale;
        part.renderer.material.color = _head.renderer.material.color;
        _taills.Add(part);
    }

    

    IEnumerator feaw()
    {
        yield return new WaitForSeconds(5f);
        feawer = true;
        fewcount = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("colchng"))
        {
            _head.ChangeColor(other.collider.gameObject.GetComponent<Renderer>().material.color);
            swapz = _head.head.transform.position.z;
        }
        if (other.collider.CompareTag("food")&& other.collider.gameObject.GetComponent<Renderer>().material.color == _head.renderer.material.color && feawer)
        {
            Addpart();
            Destroy(other.collider.gameObject); 
        }
        else if (other.collider.CompareTag("food") && feawer)
        {
            SceneManager.LoadScene(0);
        }

        if (other.collider.CompareTag("feawer")&& feawer)
        {
            fewcount++;
            Destroy(other.collider.gameObject);
        }
        else if(other.collider.CompareTag("food") && !feawer)
        {
            Addpart();
            Destroy(other.collider.gameObject); 
        }
    }
}


