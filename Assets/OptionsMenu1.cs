using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenu1 : MonoBehaviour
{

    bool weather;
    bool seed;
    bool soil;
    bool irrigation;

    public GameObject buttons;

    private Light directionalLight;
    private Dropdown drowpdown;
    private TMP_Dropdown myDropdown;
    private GameObject DROPDOWN;    





    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("pressed");

        DROPDOWN = GameObject.Find("Canvas");
        GameObject child = DROPDOWN.transform.Find("Buttons").gameObject.transform.Find("Weather").gameObject;
        myDropdown = child.GetComponent<TMP_Dropdown>();
        Debug.Log("found" +  myDropdown);




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
    public void OnDropdownValueChanged(int index)
    {
        //int selectedIndex = myDropdown.value;
        TMP_Dropdown.OptionData selectedOption = myDropdown.options[index];
        
        Debug.Log("Dropdown value changed! Index: " + index);


        switch (myDropdown.value)
        {
            case 1: // Summer
                ChangeToSummer();
                Debug.Log("changed to summer");
                break;
            case 2: // Winter
                ChangeToWinter();
                Debug.Log("changed to winter");
                break;
            case 3: // Fall
                ChangeToFall();
                Debug.Log("changed to fall");
                break;
            case 4: // Spring
                ChangeToSpring();
                break;

        }



    }

    private void ChangeToSummer()
    {
        SceneManager.LoadScene(4);
    }
    private void ChangeToWinter()
    {
        SceneManager.LoadScene(5);
    }
    private void ChangeToFall()
    {
        SceneManager.LoadScene(3);
    }
    private void ChangeToSpring()
    {
        SceneManager.LoadScene(6);
    }
}
