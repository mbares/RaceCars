using System;
using UnityEngine;
using UnityEngine.UI;

public class BodySelection : MonoBehaviour
{
    [SerializeField]
    private RaceStarter raceStarter;
    [SerializeField]
    private VehicleBody[] vehicleBodies;
    [SerializeField]
    private Image bodyImage;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameEvent bodyChanged;

    private VehicleBody selectedBody;
    private int selectedBodyIndex;

    private void Start()
    {
        selectedBody = raceStarter.vehicleBody;
        selectedBodyIndex = Array.IndexOf(vehicleBodies, selectedBody);
        bodyImage.sprite = vehicleBodies[selectedBodyIndex].sprite;
        nameText.text = selectedBody.name;
    }

    public void NextBody()
    {
        selectedBodyIndex++;
        if (selectedBodyIndex == vehicleBodies.Length) {
            selectedBodyIndex = 0;
        }

        ChangeSelectedBody();
    }

    public void PreviousBody()
    {
        selectedBodyIndex--;
        if (selectedBodyIndex < 0) {
            selectedBodyIndex = vehicleBodies.Length - 1;
        }

        ChangeSelectedBody();
    }

    private void ChangeSelectedBody()
    {
        selectedBody = vehicleBodies[selectedBodyIndex];
        bodyImage.sprite = vehicleBodies[selectedBodyIndex].sprite;
        raceStarter.vehicleBody = selectedBody;
        nameText.text = selectedBody.name;
        bodyChanged.Raise();
    }
}
