using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIer : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        _text = GameObject.FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"{Movment2.fewcount}";
    }
}
