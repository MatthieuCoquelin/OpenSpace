using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public void ChildStateChanger()
    {
        GameObject child = transform.GetChild(0).gameObject;
        child.SetActive(!child.activeSelf);

        SwitchLayer(child);
    }

    private void SwitchLayer(GameObject target)
    {
        if (target.activeSelf)
            gameObject.layer = LayerMask.NameToLayer("ClosedWall");
        else
            gameObject.layer = LayerMask.NameToLayer("OpenedWall");
    }
}
