using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationComponent : MonoBehaviour
{
    public static NavigationComponent chosenComponent;

    public Button button;
    public GameObject panel;

    Vector3 activePos;
    Vector3 inactivePos;

    public void Deactivate()
    {
        button.interactable = true;
        panel.transform.position = inactivePos;
    }

    public void SwitchTo()
    {
        if (chosenComponent != null)
            chosenComponent.Deactivate();

        button.interactable = false;
        panel.transform.position = activePos;

        chosenComponent = this;
        //Handheld.Vibrate();
    }

    private void Awake()
    {
        activePos = panel.transform.position;
        inactivePos = new Vector3(10000, panel.transform.position.y, panel.transform.position.z);

        button.onClick.AddListener(SwitchTo);
    }
}
