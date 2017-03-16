using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tooltip : MonoBehaviour {
    public Inventory inv;

    private Item item;
    private string data;
    private GameObject tooltip;

	// Use this for initialization
	void Start () {
        tooltip = GameObject.Find("Tooltip");
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Activate(int position)
    {
        this.item = inv.items[position];
        ConstructDataString();
        tooltip.SetActive(true); //Debug.Log(tooltip.transform.position);
        tooltip.transform.position = inv.slots[position].transform.position;
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<color=#98FFAAFF><b>" + item.Title + "</b></color>\n" + item.Descr +"";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
