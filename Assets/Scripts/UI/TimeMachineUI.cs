using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeMachine : MonoBehaviour
{
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button travelButton; // Botón para viajar en el tiempo
    [SerializeField] private TMP_Text yearText; 
    [SerializeField] private int[] yearList; 
    private int currentIndex = 0; 

    private void Start()
    {
        if (yearList.Length > 0)
        {
            currentIndex = 0; 
            UpdateYearText();
        }

        
        upButton.onClick.AddListener(YearUp);
        downButton.onClick.AddListener(YearDown);
        travelButton.onClick.AddListener(TravelToYear);
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

    private void TravelToYear()
    {
        int selectedYear = yearList[currentIndex];
        string sceneName = selectedYear.ToString(); // Asume que la escena tiene el mismo nombre que el año
        SceneManager.LoadScene(sceneName);
    }
}
