using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] ingredientUI;
    public GameObject InventoryWindow;
    public Text ButtonText;
    public GameObject button;
    bool InventoryActive;

    public static bool NYVisited;
    public static bool CAVisited;

    // Start is called before the first frame update
    void Start()
    {
        // ResetList();
        print("Loading inventory");
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldButtonBeActive = true;
        if (InventoryActive)
        {
            ButtonText.text = "Close";
            for (int i = 0; i < ingredientUI.Length; i++)
            {
                ingredientUI[i].SetActive(GameState.get().ingredients[i]);
            }
        }
        else
        {
            ButtonText.text = "Inventory";
            if (PlayerProximityActivated.IsIntrusiveGuiOverlayVisible())
            {
                shouldButtonBeActive = false;
            }
        }

        button.SetActive(shouldButtonBeActive);
        InventoryWindow.SetActive(InventoryActive);
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetItem("CoolJazz");
            GetItem("Bebop");
        }
    }

    private void ResetList()
    {
        GameState.get().trackEvent(new GameEvent("Discard Inventory"));
    }

    [YarnCommand("Get")]
    public void GetItem(string item)
    {
        print("Item Received:" + item);
        GameState.get().trackEvent(new GameEvent("Item Received", item));
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