using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class shop : MonoBehaviour, IShopCustomer 
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItem_Template");
    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Armor_1, Item.GetSprite(Item.ItemType.Armor_1), "Granada", Item.GetCost(Item.ItemType.Armor_1), 0);

    }
    private void CreateItemButton(Item.ItemType itemType,Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 30f;

        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {

            TryBuyItem(itemType);
        };

    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
    }
}
