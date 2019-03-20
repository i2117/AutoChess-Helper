using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSpecDescription : MonoBehaviour {

    public Text classOrSpecText;
    public Image icon;
    public Text _name;
    public Text description;

    public static Transform tr;
    public static Vector3 initPos;

    private void OnEnable()
    {
        ItemInGrid.onItemClicked += ChangeDescription;
    }

    private void OnDisable()
    {
        ItemInGrid.onItemClicked -= ChangeDescription;
    }

    private void Awake()
    {
        tr = transform;
        initPos = transform.position;
    }

    void ChangeDescription(ItemInGrid.DescriptionStruct desc)
    {
        HeroDescription.tr.position = new Vector3(10000, HeroDescription.initPos.y, HeroDescription.initPos.z);
        tr.position = initPos;
        //classOrSpecText.text = desc.classOrSpec;
        icon.sprite = desc.icon;
        _name.text = desc.classOrSpec + ": " + "\n" + desc._name;
        description.text = desc.description;
    }
}
