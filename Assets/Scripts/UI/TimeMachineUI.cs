using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeMachine : MonoBehaviour
{
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private TMP_Text yearText; 
    [SerializeField] private int[] yearList; 
    private int currentIndex = 0; 

    private void Start()
    {
        if (yearList.Length > 0)
        {
            currentIndex = 0; // Inicia en el primer año de la lista
            UpdateYearText();
        }

        upButton.onClick.AddListener(YearUp);
        downButton.onClick.AddListener(YearDown);
    }

    private void YearUp()
    {
        if (currentIndex < yearList.Length - 1)
        {
            currentIndex++;
            UpdateYearText();
        }
    }

    private void YearDown()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateYearText();
        }
    }

    private void UpdateYearText()
    {
        yearText.text = yearList[currentIndex].ToString();
    }
}
