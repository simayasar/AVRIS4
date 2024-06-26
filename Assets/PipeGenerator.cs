using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipe;
    public int startColumn;
    
    public int columns;
    public int spacing;
    private TMP_Dropdown dropdown;
    private GameObject BUTTONS;

    // Start is called before the first frame update
    void Start()
    {
        //GeneratePipes();
        
    }

    public void GeneratePipes()
    {
        for (int i = startColumn; i < columns; i++)
        {
            Vector3 position = new Vector3(i* spacing, 0.16f, 0.2f);
            pipe.transform.localScale = new Vector3(0.02f, 0.02f, 1.15f);

            //modify scale
            Instantiate(pipe, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
