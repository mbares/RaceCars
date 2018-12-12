using UnityEngine;
using UnityEngine.UI;

public class ResultScreenNavigation : MonoBehaviour
{
    [SerializeField]
    private RaceStarter winner;
    [SerializeField]
    private Image winnerImage;
    [SerializeField]
    private GameObject resultScreen;
    [SerializeField]
    private GameObject startScreen;

    public void ShowResultScreen()
    {
        winnerImage.sprite = winner.vehicleBody.sprite;
        winnerImage.color = winner.vehicleColor.color;
        resultScreen.SetActive(true);
    }

    public void HideResultScreen()
    {
        resultScreen.SetActive(false);
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
    }
}
