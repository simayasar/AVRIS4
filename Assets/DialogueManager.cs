using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;

    private string[][] dialogues = new string[][]
    {
        new string[] { "Welcome! I am Fanny, your friendly neighbourhood farmer. How can I help you?", "Seeds", "Soil", "Irrigation" },
        new string[] { "The plant you choose needs to be grown in the appropriate environment.", "Back", "Tomato", "Eggplant" },
        new string[] { "Tomato grows well in sandy soil and placed close. Furrow irrigation is common, and the best season is summer.", "Back" },
       
        new string[] { "Eggplant grows great in loamy soil and placed far. Drip irrigation is preferred, and the good season is autumn.", "Back" },
        new string[] { "Soil is the foundation for plant growth.", "Back", "Types" },
        new string[] { "Loamy's porous nature makes it drain well. Sandy is best paired with drip irrigation to minimize water loss and Clay soil with furrow ensures good water hold. ", "Back" },
        new string[] { "Drip irrigation is good for consistent water moisture and Furrow irrigation is good for maintaining water in soil that drains too quickly.", "Back" }
    };

    private int currentDialogueIndex = 0;

    void Start()
    {
        ShowDialogue(0); // Show the initial menu
    }

    public void ShowDialogue(int index)
    {
        currentDialogueIndex = index;
        dialogueText.text = dialogues[index][0];

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i + 1 < dialogues[index].Length)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogues[index][i + 1];
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnOptionSelected(int optionIndex)
    {
        switch (currentDialogueIndex)
        {
            case 0:
                if (optionIndex == 1) ShowDialogue(1);
                else if (optionIndex == 2) ShowDialogue(5);
                else if (optionIndex == 3) ShowDialogue(6);
                break;
            case 1:
                if (optionIndex == 1) ShowDialogue(0);
                else if (optionIndex == 2) ShowDialogue(2);
                
                else if (optionIndex == 3) ShowDialogue(3);
                
                break;
            case 2:
                if (optionIndex == 1) ShowDialogue(1);
                else if (optionIndex == 2) ShowDialogue(4);
                break;
            case 3:
                if (optionIndex == 1) ShowDialogue(1);
                
                break;
            case 4:
                if (optionIndex == 1) ShowDialogue(1);
               
                break;
            case 5:
                if (optionIndex == 1) ShowDialogue(0);
                else if (optionIndex == 2) ShowDialogue(6);
                break;
            case 6:
                if (optionIndex == 1) ShowDialogue(0);

                break;
        }
    }
}
