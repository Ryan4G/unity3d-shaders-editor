using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeColorChanger : MonoBehaviour
{
    public Color color = Color.white;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
