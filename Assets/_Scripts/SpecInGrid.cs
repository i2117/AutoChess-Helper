using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecInGrid : ItemInGrid {

    public Data.Specs spec;

    public static List<SpecInGrid> selectedSpecs = new List<SpecInGrid>();

    // Use this for initialization
    void Start () {
        nameText.text = spec.ToString();
	}

    protected override void AddToList()
    {
        selectedSpecs.Add(this);
        base.AddToList();
    }

    protected override void RemoveFromList()
    {
        selectedSpecs.Remove(this);
        base.RemoveFromList();
    }
}
