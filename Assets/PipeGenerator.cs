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
    private OptionsMenu1 options;

    // Start is called before the first frame update
    void Start()
    {

        options = GameObject.Find("Canvas").gameObject.transform.GetComponent<OptionsMenu1>();
        Debug.Log("options script ready");
        //GeneratePipes();

    }

    public void GeneratePipes()
    {
        for (int i = startColumn; i < columns; i++)
        {
            //if (options.furrow == true || options.sprinkler == true || options.terraced == true)
            //{

            //}
            
            Vector3 position = new Vector3(i* spacing, 0.16f, 0.2f);
            pipe.transform.localScale = new Vector3(0.02f, 0.02f, 1.15f);
            GameObject newPipe = Instantiate(pipe, position, Quaternion.identity);
            newPipe.tag = "Pipe";
        }
    }
   
    public void DeactivatePipes()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
        Debug.Log("pipes deactivated");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
