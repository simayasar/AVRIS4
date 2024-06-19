using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu1 : MonoBehaviour
{

    bool weather;
    bool seed;
    bool soil;
    bool irrigation;

    public GameObject buttons;

    private Light directionalLight;
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("pressed");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartApp()
    {
        Debug.Log("pressed");
        directionalLight = FindObjectOfType<Light>();
        Debug.Log("Found directional light:" + directionalLight.name);
        //directionalLight.enabled = false;
        directionalLight.color = Color.red;
    }
}
