using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassInGrid : ItemInGrid {

    public Data.Classes _class;

    public static List<ClassInGrid> selectedClasses = new List<ClassInGrid>();

    void Start () {
        string _name = _class == Data.Classes.DemonHunter ? "Demon Hunter" : _class.ToString();
        nameText.text = _name;
	}

    protected override void AddToList()
    {
        selectedClasses.Add(this);
        base.AddToList();
    }

    protected override void RemoveFromList()
    {
        selectedClasses.Remove(this);
        base.RemoveFromList();
    }
}
