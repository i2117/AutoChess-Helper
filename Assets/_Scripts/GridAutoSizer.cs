using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridAutoSizer : MonoBehaviour {

    public int cols = 11;
    public HorizontalOrVerticalLayoutGroup[] otherLayouts;

	void Start () {
        var newSize = GetComponent<RectTransform>().rect.width / cols;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(newSize, newSize);
        foreach (HorizontalOrVerticalLayoutGroup log in otherLayouts)
        {
            //log.
        }
	}
}
