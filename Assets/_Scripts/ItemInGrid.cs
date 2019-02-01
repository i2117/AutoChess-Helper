using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInGrid : MonoBehaviour {

    public Button button;

    public Image textBackgroundImage;
    internal Text nameText;

    Color unselectedColor = new Color(0, 0, 0, 0.5F);
    Color selectedColor = new Color(0, 1, 0, 0.5F);

    [HideInInspector]
    public bool isSelected;


    public static List<ItemInGrid> selectedItems;

    List<ItemInGrid> currentList;

    public delegate void ItemMethod();
    public static event ItemMethod onListsChanged;

    // Use this for initialization
    void Awake()
    {
        nameText = GetComponentInChildren<Text>();

        button.onClick.AddListener(_OnClick);

    }

    protected virtual void _OnClick ()
    {
        if (!isSelected)
        {
            isSelected = true;
            textBackgroundImage.color = selectedColor;
            AddToList();
        }
        else
        {
            isSelected = false;
            textBackgroundImage.color = unselectedColor;
            RemoveFromList();
        }
    }

    protected virtual void AddToList()
    {
        Debug.Log(SpecInGrid.selectedSpecs.Count);
        onListsChanged();
    }

    protected virtual void RemoveFromList ()
    {
        Debug.Log(SpecInGrid.selectedSpecs.Count);
        onListsChanged();
    }
}
