using UnityEngine;

public class NavigationButton : MonoBehaviour
{
    [SerializeField]
    private GameObject startScreen;
    [SerializeField]
    private GameObject carSelectionScreen;

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
    }

    public void HideStartScreenPanel()
    {
        startScreen.SetActive(false);
    }

    public void ShowCarSelectionScreen()
    {
        carSelectionScreen.SetActive(true);
    }

    public void HideCarSelectionScreen()
    {
        carSelectionScreen.SetActive(false);
    }
}
