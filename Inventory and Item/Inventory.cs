using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    private static bool inventoryExists;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private PlayerController thePlayer;

    private int currentHighlight;

    public Tooltip tooltip;

    private DialogueManager theDM;
    private KeyboardManager theKM;
	// Use this for initialization
	void Start () {
        database = GetComponent<ItemDatabase>();
        thePlayer = FindObjectOfType<PlayerController>();
        tooltip = FindObjectOfType<Tooltip>();
        theDM = FindObjectOfType<DialogueManager>();
        theKM = FindObjectOfType<KeyboardManager>();
        inventoryPanel = GameObject.Find("Inventory Panel");

        if (!inventoryExists)
        {
            inventoryExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        slotAmount = 9;
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0;i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform, false);
        }

        inventoryPanel.SetActive(false);
          //  AddItem(0);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            if (inventoryPanel.activeSelf)
            {
                slots[currentHighlight].GetComponent<Outline>().enabled = false;
                thePlayer.canMove = false;
                currentHighlight = 0;
                slots[currentHighlight].GetComponent<Outline>().enabled = true;
            }
        }

        if (inventoryPanel.activeSelf)
        {
            if (slots[currentHighlight].transform.childCount != 0)
                tooltip.Activate(currentHighlight);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                slots[currentHighlight].GetComponent<Outline>().enabled = false;
                tooltip.Deactivate();
                currentHighlight = CalculateHighlight(1);
                slots[currentHighlight].GetComponent<Outline>().enabled = true;// Debug.Log(currentHighlight);
                if (slots[currentHighlight].transform.childCount != 0)
                    tooltip.Activate(currentHighlight);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                slots[currentHighlight].GetComponent<Outline>().enabled = false;
                tooltip.Deactivate();
                currentHighlight = CalculateHighlight(-1);
                slots[currentHighlight].GetComponent<Outline>().enabled = true;// Debug.Log(currentHighlight);
                if (slots[currentHighlight].transform.childCount != 0)
                    tooltip.Activate(currentHighlight);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                slots[currentHighlight].GetComponent<Outline>().enabled = false;
                tooltip.Deactivate();
                currentHighlight = CalculateHighlight(-3);
                slots[currentHighlight].GetComponent<Outline>().enabled = true;// Debug.Log(currentHighlight);
                if (slots[currentHighlight].transform.childCount != 0)
                    tooltip.Activate(currentHighlight);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                slots[currentHighlight].GetComponent<Outline>().enabled = false;
                tooltip.Deactivate();
                currentHighlight = CalculateHighlight(3);
                slots[currentHighlight].GetComponent<Outline>().enabled = true;// Debug.Log(currentHighlight);
                if (slots[currentHighlight].transform.childCount != 0)
                    tooltip.Activate(currentHighlight);
            }

        }
        else if (!theDM.dialogActive && !theKM.keyboardActive)
        {
            thePlayer.canMove = true;
        }
    }
    
    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform,false);
                //itemObj.transform.position = Vector2.zero;
                itemObj.transform.position = slots[i].transform.position;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = items[i].Title;
                slots[i].name = items[i].Title;
                break;
            }
        }
    }

    bool CheckItem(Item item)
    {
        for (int i = 0;i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
            {
                return true;
            }
        }
        return false;
    }

    int CalculateHighlight(int amount)
    {
        if (currentHighlight + amount > 8 || currentHighlight + amount < 0)
        {
            return currentHighlight;
        }
        return currentHighlight + amount;
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = database.FetchItemByID(id);
        if (CheckItem(itemToRemove))
        {
            for (int j = 0; j < items.Count; j++)
            {
                if (items[j].ID == id)
                {
                    Destroy(slots[j].transform.GetChild(0).gameObject);
                    items[j] = new Item();
                }
            }
        }
        else for (int i = 0; i < items.Count; i++) if (items[i].ID != -1 && items[i].ID == id) { Destroy(slots[i].transform.GetChild(0).gameObject); items[i] = new Item(); break; }
    }

    public bool CheckItemByID(int id)
    {
        Item itemToCheck = database.FetchItemByID(id);
        if (CheckItem(itemToCheck))
        {
            return true;
        }
        return false;
    }

    public void ResetInventory()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (slots[i].transform.childCount > 0)
                Destroy(slots[i].transform.GetChild(0).gameObject);
            items[i] = new Item();
        } 
    }
}
