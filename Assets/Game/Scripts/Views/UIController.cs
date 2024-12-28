using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text roundCounter;
    public GameObject correctText;
    public GameObject mistakeText;
    public GameObject nextPresentButton;
    public TMP_Text description;
    public List<TMP_Text> selectionTexts;
    public List<Button> selectionButtons;


    private void Awake()
    {
        correctText.SetActive(false);
        mistakeText.SetActive(false);
        description.gameObject.SetActive(false);
        nextPresentButton.SetActive(false);
    }

    public void NextRoundUI()
    {
        correctText.SetActive(false);
        mistakeText.SetActive(false);
        description.gameObject.SetActive(false);
        nextPresentButton.SetActive(false);

        foreach (var button in selectionButtons)
        {
            button.interactable = true;
        }
    }
}
