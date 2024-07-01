using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGrowth : MonoBehaviour
{
    public Dropdown seasonDropdown;
    public Dropdown seedTypeDropdown;
    public Dropdown soilTypeDropdown;
    public Dropdown irrigationSystemDropdown;
    public Dropdown distanceDropdown;
    public Button evaluateButton;

    public GameObject badTomatoPrefab;
    public GameObject okTomatoPrefab;
    public GameObject goodTomatoPrefab;
    public GameObject badEggplantPrefab;
    public GameObject okEggplantPrefab;
    public GameObject goodEggplantPrefab;

    private void Start()
    {
        evaluateButton.onClick.AddListener(EvaluatePlantGrowth);
    }

    public void EvaluatePlantGrowth()
    {
        int score = 0;
        string seedType = seedTypeDropdown.options[seedTypeDropdown.value].text;

        // Season evaluation
        if (seedType == "Tomato")
        {
            if (seasonDropdown.options[seasonDropdown.value].text == "Spring")
            {
                score++;
            }
        }
        else if (seedType == "Eggplant")
        {
            if (seasonDropdown.options[seasonDropdown.value].text == "Autumn")
            {
                score++;
            }
        }

        // Soil type evaluation
        if (seedType == "Tomato")
        {
            if (soilTypeDropdown.options[soilTypeDropdown.value].text == "Loamy soil")
            {
                score++;
            }
        }
        else if (seedType == "Eggplant")
        {
            if (soilTypeDropdown.options[soilTypeDropdown.value].text == "Clay soil")
            {
                score++;
            }
        }

        // Irrigation system evaluation
        if (seedType == "Tomato")
        {
            if (irrigationSystemDropdown.options[irrigationSystemDropdown.value].text == "Drip")
            {
                score++;
            }
        }
        else if (seedType == "Eggplant")
        {
            if (irrigationSystemDropdown.options[irrigationSystemDropdown.value].text == "Furrow")
            {
                score++;
            }
        }

        // Distance evaluation
        if (seedType == "Tomato")
        {
            if (distanceDropdown.options[distanceDropdown.value].text == "30cm")
            {
                score++;
            }
        }
        else if (seedType == "Eggplant")
        {
            if (distanceDropdown.options[distanceDropdown.value].text == "60cm")
            {
                score++;
            }
        }

        // Determine the growth stage
        GameObject plantPrefab = null;
        if (seedType == "Tomato")
        {
            if (score >= 0 && score <= 1)
            {
                // Bad growth
                plantPrefab = badTomatoPrefab;
            }
            else if (score == 2)
            {
                // Ok growth
                plantPrefab = okTomatoPrefab;
            }
            else if (score >= 3 && score <= 4)
            {
                // Good growth
                plantPrefab = goodTomatoPrefab;
            }
        }
        else if (seedType == "Eggplant")
        {
            if (score >= 0 && score <= 1)
            {
                // Bad growth
                plantPrefab = badEggplantPrefab;
            }
            else if (score == 2)
            {
                // Ok growth
                plantPrefab = okEggplantPrefab;
            }
            else if (score >= 3 && score <= 4)
            {
                // Good growth
                plantPrefab = goodEggplantPrefab;
            }
        }

        if (plantPrefab != null)
        {
            Instantiate(plantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}