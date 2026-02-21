using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image portraitImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Transform choiceButtonSpawner;
    [SerializeField] private Button choiceButtonPrefab;
    private readonly List<Button> buttonList;

    public void Show(bool IsVariable) => panel.SetActive(IsVariable);
    public void SetLine(string name, Sprite portrait, string text)
    {
        nameText.text = name;
        portraitImage.sprite = portrait;
        bodyText.text = text;
    }
    public void SetContinue(Action action)
    {
        continueButton.gameObject.SetActive(true);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(()=>action?.Invoke());
    }
    public void HideContinue()
    {
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
    }
    public void ClearChoices()
    {
        foreach(var b in buttonList)
        {
            Destroy(b.gameObject);
        }

        buttonList.Clear();
    }

    public void ShowChoices(List<(string text, Action onClick)> choices)
    {
        ClearChoices();
        HideContinue();

        for (int i = 0; i < choices.Count ; i++)
        {
            var bt = Instantiate(choiceButtonPrefab, choiceButtonSpawner);
            bt.GetComponentInChildren<TMP_Text>().text = choices[i].text;

            bt.onClick.AddListener(() => choices[i].onClick?.Invoke());
            buttonList.Add(bt);  
        }
    }

}
