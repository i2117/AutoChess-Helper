using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

    public NavigationComponent[] navigationComponents;
    public NavigationComponent startComponent;


    private void Start()
    {
        foreach (var item in navigationComponents)
        {
            if (item != startComponent)
            {
                item.Deactivate();
            }
            else
            {
                item.SwitchTo();
            }
        }
    }
}



