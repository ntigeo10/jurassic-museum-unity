using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShopSystem : MonoBehaviour
{
    class Item
    {
        public string name;
        public float price;

        public Item(string name, float price)
        {
            this.name = name;
            this.price = price;
        }
    }

    public GameObject Cell;
    public GameObject BasketScreen;
    public GameObject CardScreen;
    
    public Text totalCost;
    public float total = 0;

    List<Item> items = new List<Item>();

    //private void Start()
    //{

    //}

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            addItem(new Item("Test Object", 5.0f));
        }
        totalCost.GetComponent<Text>().text = CountTotal().ToString() + " Ευρω";
    }

    void addItem(Item item)
    {
        GameObject obj;
        items.Add(item);
        obj = Instantiate(Cell);
        obj.gameObject.transform.SetParent(gameObject.transform, false);
        obj.gameObject.transform.GetChild(0).GetComponent<Text>().text = item.name;
        obj.gameObject.transform.GetChild(1).GetComponent<Text>().text = item.price.ToString();
        Debug.Log("Added Item ");
        CountTotal();
    }


    public void buyAll()
    {
        BasketScreen.SetActive(false);
        CardScreen.SetActive(true);
    }

    public void ClearList()
    {
        items.Clear();
        foreach(Transform child in transform)
        {            
            //i = child.GetSiblingIndex();
            //gameObject.transform.GetChild(i).GetComponent<Shop>().removeItem();
            GameObject.Destroy(child.gameObject);
        }
    }
    public float CountTotal()
    {
        total = 0;
        foreach (Transform child in transform)
        {
            total += float.Parse(child.transform.GetChild(1).GetComponent<Text>().text);
        }
        return total;
    }

    public void ReturnToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
