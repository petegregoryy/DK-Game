using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public GameObject[] menus;
    GameObject currentMenu;

    public void Start()
    {
        // The Main Menu will always be the starting menu
        currentMenu = menus[0];
    }

    public void MenuButtonClicked(string menuName)
    {
        if (menuName == "Play")
        {
            // Load game scene
            SceneManager.LoadScene("Map2");
            return;
        }

        foreach (GameObject menu in menus)
        {
            if (menu.name == menuName)
            {
                // Close current menu and update
                currentMenu.SetActive(false);
                currentMenu = menu;

                // Open selected menu
                GameObject selectedMenu = Array.Find(menus, element => element.name == menuName);
                selectedMenu.SetActive(true);
            }
        }
    }
}