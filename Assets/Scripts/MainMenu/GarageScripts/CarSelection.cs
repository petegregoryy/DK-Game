using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarSelection : MonoBehaviour
{
    public TextMeshProUGUI carNameText;
    public Button previousButton, nextButton;
    public List<GameObject> cars = new List<GameObject>();
    int currentCarNum = 0;

    public void ArrowClicked(string direction)
    {
        // When the next or previous car buttons are clicked
        if (direction == "Previous" && cars[0].activeSelf == false)
        {
            nextButton.enabled = true;
            cars[currentCarNum].SetActive(false);
            cars[currentCarNum - 1].SetActive(true);
            currentCarNum--;
        }
        else if (direction == "Next" && cars[cars.Count - 1].activeSelf == false)
        {
            previousButton.enabled = true;
            cars[currentCarNum].SetActive(false);
            cars[currentCarNum + 1].SetActive(true);
            currentCarNum++;
        }

        // Update car name text
        carNameText.text = cars[currentCarNum].name;

        // Disable buttons when at start/end of cars
        if (currentCarNum == 0)
        {
            previousButton.enabled = false;
        }
        if (currentCarNum == cars.Count - 1)
        {
            nextButton.enabled = false;
        }
    }
}
