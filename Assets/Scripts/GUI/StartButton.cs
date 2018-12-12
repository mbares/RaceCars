using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject startScreenPanel;

    public void HideStartScreenPanel()
    {
        startScreenPanel.SetActive(false);
    }
}
