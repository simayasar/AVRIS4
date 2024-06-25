using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;

    private string[][] dialogues = new string[][]
    {
        new string[] { "Hello! I am up here but I'll answer any questions you may have.", "Seeds", "Soil","Irrigation" },
        new string[] { "Seeds are essential for plant growth.", "Back to main menu." },
        new string[] { "Soil provides nutrients and support.", "Back to main menu." },
        new string[] { "Furrow systems work best for plants that need a lot of water.", "Back to main menu." }
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
        if (currentDialogueIndex == 0)
        {
            // Main menu options
            if (optionIndex == 1)
            {
                ShowDialogue(1);
            }
            else if (optionIndex == 2)
            {
                ShowDialogue(2);
            }
        }
        else
        {
            // Sub-menu options (only one option to go back to the main menu)
            ShowDialogue(0);
        }
    }
}
