using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail_part : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x + 5f * Tail.delta * Time.deltaTime,
            transform.position.y,transform.position.z+ 5f*Time.deltaTime);
    }
}
