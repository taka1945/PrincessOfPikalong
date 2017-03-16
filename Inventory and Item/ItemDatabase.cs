using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();

    }

    void ConstructItemDatabase()
    {
        for (int i = 0;i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["descr"].ToString(), (int)itemData[i]["slug"]));
        }
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    
}



public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Descr { get; set; }
    public int Slug { get; set; }
    public Sprite Sprite { get; set; }
    object[] sprites;
    public Item(int id, string title, string descr, int slug)
    {
        this.ID = id;
        this.Title = title;
        this.Descr = descr;
        sprites = Resources.LoadAll("Items/fantasy-tileset");
        this.Sprite = (Sprite)sprites[slug+1]; 
    }

    public Item()
    {
        this.ID = -1;
    }

}