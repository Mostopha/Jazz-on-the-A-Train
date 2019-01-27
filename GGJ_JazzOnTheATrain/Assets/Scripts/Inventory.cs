using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    bool[] ingrediants;
    public GameObject[] ingrediantUI;
    public GameObject InventoryWindow;
    public Text ButtonText;
    bool InventoryActive;

    // Start is called before the first frame update
    void Start()
    {
        ingrediants = new bool[ingrediantUI.Length];
        ResetList();
    }

    // Update is called once per frame
    void Update()
    {

        InventoryWindow.SetActive(InventoryActive);
        if (InventoryActive)
        {
            ButtonText.text = "Close";
            for (int i = 0; i < ingrediantUI.Length; i++)
            {
                ingrediantUI[i].SetActive(ingrediants[i]);
            }
        }
        else
        {
            ButtonText.text = "Inventory";
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetItem("CoolJazz");
        }

    }

    private void ResetList()
    {
        for (int i = 0; i < ingrediants.Length; i++)
        {
            ingrediants[i] = false;
        }
    }

    [YarnCommand("Get")]
    public void GetItem(string item)
    {
        int index = 0;
        switch (item)
        {
            case "CoolJazz":
                index = 0;
                break;
            case "Bebop":
                index = 1;
                break;
            case "Swing":
                index = 2;
                break;
            case "NewOrleans":
                index = 3;
                break;
        }

        ingrediants[index] = true;
    }

    public void ToggleInventory()
    {
        if (InventoryActive)
        {
            InventoryActive = false;
        }
        else
        {
            InventoryActive = true;
        }
    }
}
