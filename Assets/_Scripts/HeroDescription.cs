using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDescription : MonoBehaviour {

    public Image icon;
    public Text priceText, specText, classText, nameText;

    public static Transform tr;
    public static Vector3 initPos;

    private void OnEnable()
    {
        HeroInGrid.onClicked += ChangeDescription;
    }

    private void OnDisable()
    {
        HeroInGrid.onClicked -= ChangeDescription;
    }

    private void Awake()
    {
        tr = transform;
        initPos = transform.position;
    }

    void ChangeDescription(Data.Hero hero)
    {
        ClassSpecDescription.tr.position = new Vector3(10000, ClassSpecDescription.initPos.y, ClassSpecDescription.initPos.z);
        tr.position = initPos;

        icon.sprite = hero.miniIcon;
        priceText.text = hero.price.ToString();
        specText.text = "";
        for (int i = 0; i < hero._specs.Count; i++)
        {
            if (i > 0)
                specText.text += ", ";
            specText.text += hero._specs[i].ToString();

        }
        classText.text = hero._class.ToString();
        nameText.text = hero.name;
    }
}
