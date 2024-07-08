using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Experimental.Rendering;

public class OptionsMenu1 : MonoBehaviour
{

    bool weather;
    bool seed;
    bool soil;
    public bool pipes;
    public bool furrow;
    public bool sprinkler;
    public bool terraced;

    public GameObject buttons;
    public PipeGenerator pipeGenerator;
    public WaterGenerator waterGenerator;
    public Grid_Generator gridGenerator;
    public Grid_GeneratorSp grid_GeneratorSp;
    public Grid_GeneratorW grid_GeneratorW;
    public Grid_GeneratorF grid_GeneratorF;
    public Grid_GeneratorSum grid_GeneratorSum;
    public TextureChanger textureChanger;
    private Light directionalLight;
    private Dropdown drowpdown;
    private TMP_Dropdown myDropdownWeather;
    private TMP_Dropdown myDropdownSeed;
    private TMP_Dropdown myDropdownSoil;
    private TMP_Dropdown myDropdownIrrigation;
    private GameObject BUTTONS;
    private TMP_Dropdown myDropdownDistance;
    private GameObject canvas;
    


    //try
    public GameObject badTomatoPrefab;
    public GameObject okTomatoPrefab;
    public GameObject goodTomatoPrefab;
    public GameObject badAubPrefab; 
    public GameObject okAubPrefab;  
    public GameObject goodAubPrefab; 



    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("pressed");

        BUTTONS = GameObject.Find("Canvas");
        // Get dropdown for weather
        GameObject weather = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Weather").gameObject;
        myDropdownWeather = weather.GetComponent<TMP_Dropdown>();
        Debug.Log("found" + myDropdownWeather);

        //Get dropdown for seed
        GameObject seed = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Seed Type").gameObject;
        myDropdownSeed = seed.GetComponent<TMP_Dropdown>();
        Debug.Log("found" + myDropdownSeed);

        //Get drowpdown for soil
        GameObject soil = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Soil Type").gameObject;
        myDropdownSoil = soil.GetComponent<TMP_Dropdown>();
        Debug.Log("found" + myDropdownSoil);

        //Get dropdown for irrigation
        GameObject irrigation = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Irrigation System").gameObject;
        myDropdownIrrigation = irrigation.GetComponent<TMP_Dropdown>();
        Debug.Log("found" +  myDropdownIrrigation);

        //distance
        GameObject distance = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Distance").gameObject;
        myDropdownDistance = distance.GetComponent<TMP_Dropdown>();

        pipeGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent<PipeGenerator>();
        Debug.Log("pipeGenerator ready");


        waterGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent <WaterGenerator>();
        Debug.Log("waterGenerator ready");

        gridGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_Generator>();
        Debug.Log("waterGenerator ready");

        textureChanger = GameObject.Find("XR Origin (XR Rig)").GetComponent<TextureChanger>(); 

        grid_GeneratorSp = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorSp>();

        grid_GeneratorW = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorW>();

        grid_GeneratorF = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorF>();

        grid_GeneratorSum = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorSum>();

        //try
        //GameObject distance = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Distance").gameObject;
        //myDropdownDistance = distance.GetComponent<TMP_Dropdown>();
        //Debug.Log("found" + myDropdownDistance);



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



    //try 
    public void OnDropdownValueChanged(int index)
    {
        // Sadece görsel deðiþiklikleri burada yapýn
        UpdateVisuals();
    }


    //public void OnDropdownValueChanged(int index)
    public void UpdateVisuals()
    {

        
        DeactivateAllIrrigationSystems();
        //int selectedIndex = myDropdown.value;
        //TMP_Dropdown.OptionData selectedOption = myDropdownWeather.options[index];
        //Debug.Log("Dropdown value changed! Index: " + index);


        

        switch (myDropdownWeather.value)
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
                Debug.Log("changed to spring");
                break;

        }

        switch (myDropdownIrrigation.value)
        {
            case 1: // Drip
                ActivateDrip();
                Debug.Log("pipes activated");
                break;
            case 2: // Sprinkler
                Debug.Log("changed to sprinkler");
                break;
            case 3: // Furrow
                ActivateFurrow();
                Debug.Log("changed to furrow");
                break;
            case 4: // Terraced
                Debug.Log("changed to terraced");
                break;

        }

        switch (myDropdownSeed.value) 
        {
            
            case 1: //Tomato
                changeToTomato();
                break;
      
            case 2: // Aub
                changeToAub();
                break;

        }

       
        switch (myDropdownSoil.value)
        {
            case 1: // Sandy Soil
                textureChanger.ChangeToLoamySoil();
                break;
            case 2: // Loamy Soil
                textureChanger.ChangeToSandySoil();
                break;
            case 3: // Clay Soil
               textureChanger.ChangeToClaySoil();
                break;
        }


        switch (myDropdownDistance.value)
        {
            case 1: //60cm
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    grid_GeneratorF.vertSpacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    grid_GeneratorSum.vertSpacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    grid_GeneratorW.vertSpacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 6)
                {
                    grid_GeneratorSp.vertSpacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    gridGenerator.vertSpacing = 1;
                }
                else { break; }



                Debug.Log("Changed Distance to 60cm");
                break;
            case 2: //30cm

                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    grid_GeneratorF.vertSpacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    grid_GeneratorSum.vertSpacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    grid_GeneratorW.vertSpacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 6)
                {
                    grid_GeneratorSp.vertSpacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    gridGenerator.vertSpacing = 2;
                }
                else { break; }
                Debug.Log("Changed to 30cm");
                break;
        }


    }
    //try 
    public void OnNextButtonClicked()
    {
        // Tüm seçeneklerin ayarlandýðýndan emin olun
        SetOptions();

        // Bitki büyümesini deðerlendir ve sonucu hesapla
        EvaluatePlantGrowth();
        //canvas = GameObject.Find("Canvas");
        //canvas.SetActive(false);

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

    private void DeactivateAllIrrigationSystems()
    {
        if (waterGenerator != null)
        {
            waterGenerator.DeactivateWater();
        }
        else
        {
            Debug.LogError("waterGenerator is null");
        }

        if (pipeGenerator != null)
        {
            pipeGenerator.DeactivatePipes();
        }
        else
        {
            Debug.LogError("pipeGenerator is null");
        }
    }
    private void ActivateDrip()
    {
        pipeGenerator.GeneratePipes();
    }

    private void ActivateFurrow()
    {
        waterGenerator.GenerateWater();
    }

    private void changeToTomato() 
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3: //Fall
                grid_GeneratorF.GenerateTomato();
                break;
            case 4: // Summer
                grid_GeneratorSum.GenerateTomato();
                break;
            case 5: // Winter
                grid_GeneratorW.GenerateTomato();
                break;
            case 6: // Spring
                grid_GeneratorSp.GenerateTomato();
                break;
            case 1:
                gridGenerator.GenerateTomato();
            
                break;



        }
    }
    private void changeToAub()
    {
      
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3: //Fall
                grid_GeneratorF.GenerateAub();
                break;
            case 4: // Summer
                grid_GeneratorSum.GenerateAub();
                break;
            case 5: // Winter
                grid_GeneratorW.GenerateAub();
                break;
            case 6: // Spring
                grid_GeneratorSp.GenerateAub();
                break;
            case 1:
                gridGenerator.GenerateAub();
                break;

        }
    }
    

    //try
    private void SetOptions()
    {
        // Seçeneklerinizi ayarlayýn
        DeactivateAllIrrigationSystems();

        //switch (myDropdownWeather.value)
        //{
        //    case 1: // Summer
        //        ChangeToSummer();
        //        Debug.Log("changed to summer");
        //        break;
        //    case 2: // Winter
        //        ChangeToWinter();
        //        Debug.Log("changed to winter");
        //        break;
        //    case 3: // Fall
        //        ChangeToFall();
        //        Debug.Log("changed to fall");
        //        break;
        //    case 4: // Spring
        //        ChangeToSpring();
        //        Debug.Log("changed to spring");
        //        break;
        //}

        //switch (myDropdownIrrigation.value)
        //{
        //    case 0: // Drip
        //        ActivateDrip();
        //        Debug.Log("pipes activated");
        //        break;
        //    case 1: // Sprinkler
        //        Debug.Log("changed to sprinkler");
        //        break;
        //    case 2: // Furrow
        //        ActivateFurrow();
        //        Debug.Log("changed to furrow");
        //        break;
        //    case 3: // Terraced
        //        Debug.Log("changed to terraced");
        //        break;
        //}

        //switch (myDropdownSeed.value)
        //{
        //    case 0: //Tomato
        //        changeToTomato();
        //        break;
        //    case 1: // Aub
        //        changeToAub();
        //        break;
        //}

        //switch (myDropdownSoil.value)
        //{
        //    case 0: // Sandy Soil
        //        textureChanger.ChangeToLoamySoil();
        //        break;
        //    case 1: // Loamy Soil
        //        textureChanger.ChangeToSandySoil();
        //        break;
        //    case 2: // Clay Soil
        //        textureChanger.ChangeToClaySoil();
        //        break;
        //}


    }


    public void EvaluatePlantGrowth()
    {
        Debug.Log("EvaluatePlantGrowth çalýþtý"); // Fonksiyonun çaðrýldýðýný kontrol edin

        int score = 0;
        string seedType = myDropdownSeed.options[myDropdownSeed.value].text;



        int selWeather = SceneManager.GetActiveScene().buildIndex;
        string selectedWeather = myDropdownWeather.options[myDropdownWeather.value].text;
        // Season evaluation
        if (seedType == "Tomato") //spring
        {
            if (selWeather == 6)
            {
                score++;
                Debug.Log("Weather match for Tomato: Spring");
            }
        }
        else if (seedType == "Aub")//fall
        {
            if (selWeather == 3)
            {
                score++;
                Debug.Log("Weather match for Aub: Fall");
            }
        }



        string selectedSoil = myDropdownSoil.options[myDropdownSoil.value].text;
        // Soil type evaluation
        if (seedType == "Tomato") //sandy soil
        {
            if (selectedSoil == "Sandy soil")
            {
                score++;
                Debug.Log("Soil match for Tomato: Loamy soil");
            }
        }
        else if (seedType == "Aub")//loamy soil
        {
            if (selectedSoil == "Loamy soil")
            {
                score++;
                Debug.Log("Soil match for Aub: Clay soil");
            }
        }


        string selectedIrrigation = myDropdownIrrigation.options[myDropdownIrrigation.value].text;
        // Irrigation system evaluation
        if (seedType == "Tomato") //furrow
        {
            if (selectedIrrigation == "Furrow")
            {
                score++;
                Debug.Log("Irrigation match for Tomato: Drip");
            }
        }
        else if (seedType == "Aub")//drip
        {
            if (selectedIrrigation == "Drip")
            {
                score++;
                Debug.Log("Irrigation match for Aub: Furrow");
            }
        }

        string selectedDistance = myDropdownDistance.options[myDropdownDistance.value].text;

        if (seedType == "Tomato") //3ocm
        {
            if (selectedDistance == "30cm")
            {
                score++;
            }
            
        }
        else if (seedType == "Aub")//60cm
        {
            if (selectedDistance == "60cm")
            {
                score++;
            }

        }
       


        Debug.Log("Final Score: " + score);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3:
                grid_GeneratorF.GeneratePlants(seedType, score);
                break;
            case 4:
                grid_GeneratorSum.GeneratePlants(seedType, score);
                break;
            case 5:
                grid_GeneratorW.GeneratePlants(seedType, score);
                break;
            case 6:
                grid_GeneratorSp.GeneratePlants(seedType, score);
                break;
            case 1:
                gridGenerator.GeneratePlants(seedType, score);
                break;
        }
    }
}

        /*
        // Determine the growth stage
        GameObject plantPrefab = null;
        if (seedType == "Tomato")
        {
            if (score >= 0 && score <= 1)
            {
                
                gridGenerator.tomato = badTomatoPrefab;
                Debug.Log("Selected okTomatoPrefab");
            }
            else if (score == 2)
            {
                gridGenerator.tomato = okTomatoPrefab;
                Debug.Log("Selected okTomatoPrefab");

            }
            else if (score >= 3 && score <= 4)
            {
                gridGenerator.tomato = goodTomatoPrefab;
                Debug.Log("Selected goodTomatoPrefab");
            }
        }
        else if (seedType == "Aub")
        {
            if (score >= 0 && score <= 1)
            {
               gridGenerator.aub = badAubPrefab;
            }
            else if (score == 2)
            {
                gridGenerator.aub = okAubPrefab;
            }
            else if (score >= 3 && score <= 4)
            {
                gridGenerator.aub = goodAubPrefab;
            }
        }
        */

      


        /*
        if (plantPrefab != null)
        {

            InstantiatePlantPrefab(plantPrefab);
        }
        else
        {
            Debug.Log("Plant prefab is null");
        }
        */
    

  /*
    private void InstantiatePlantPrefab(GameObject plantPrefab)
    {
        Debug.Log("Instantiating plant prefab: " + plantPrefab.name);

        // Prefab'ý sahnedeki bir grid veya baþka bir container içine yerleþtirin
        GameObject parent = GameObject.Find("GridContainer"); // GridContainer nesnesinin adýný kontrol edin
        if (parent != null)
        {
            Instantiate(plantPrefab, new Vector3(0, 0, 0), Quaternion.identity, parent.transform);
        }
        else
        {
            Instantiate(plantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
  */



