using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;

    private string[][] dialogues = new string[][]
    {
        new string[] { "Welcome! How can I help you?", "Seeds", "Soil", "Irrigation" },
        new string[] { "The plant you choose needs to be grown in the appropriate environment.", "Back", "Tomato", "Potato", "Aubergine" },
        new string[] { "Tomato grows best in medium water and loamy soil. Drip irrigation is preferred.", "Back" },
        new string[] { "Soil is the foundation for plant growth.", "Back", "Types." },
        new string[] { "There are various types of seeds, including heirloom, organic, and hybrid seeds.", "Back" },
        new string[] { "Different soil types include sandy, clay, and loamy soil.", "Back" }
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
                else if (optionIndex == 2) ShowDialogue(2);
                else if (optionIndex == 3) ShowDialogue(3);
                break;
            case 1:
                if (optionIndex == 1) ShowDialogue(0);
                else if (optionIndex == 2) ShowDialogue(3);
                else if (optionIndex == 3) ShowDialogue(4);
                else if (optionIndex == 4) ShowDialogue(5);
                else if (optionIndex == 5) ShowDialogue(6);
                break;
            case 2:
                if (optionIndex == 1) ShowDialogue(0);
                else if (optionIndex == 2) ShowDialogue(4);
                break;
            case 3:
                if (optionIndex == 1) ShowDialogue(1);
                break;
            case 4:
                if (optionIndex == 1) ShowDialogue(2);
                break;
        }
    }
}
