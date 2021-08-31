using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public List<Transform> tails;
    [Range(0,3)]
    public float tailsdist;
    public GameObject tail;
    private Transform _transform;
    private Camera _camera;
    void Start()
    {
        _camera = GameObject.FindObjectOfType<Camera>();
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        Movment();
        tail_move();
    }

    void Movment()
    {
        transform.position = new Vector3(transform.position.x + 5f * Input.GetAxis("Horizontal") * Time.deltaTime,
                transform.position.y,transform.position.z+ 5f*Time.deltaTime);
        _camera.transform.position = new Vector3(_camera.transform.position.x,
           _camera.transform.position.y,_camera.transform.position.z+ 5f*Time.deltaTime);
    }

    private void tail_move()
    {
        float dist = tailsdist * tailsdist;
        Vector3 prevtail = _transform.position;
        foreach (var tail in tails)
        {
            if ((tail.position - prevtail).sqrMagnitude > dist)
            {
                var temp = tail.position;
                tail.position = prevtail;
                prevtail = temp;
            }
            else
            {
                break;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            Debug.Log("lox");
            Destroy(other.gameObject);
            var tals = Instantiate(tail);
            tails.Add(tals.transform);
        }
    }
}
