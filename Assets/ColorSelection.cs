using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    [SerializeField]
    private RaceStarter raceStarter;
    [SerializeField]
    private VehicleColor[] vehicleColors;
    [SerializeField]
    private Image bodyImage;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameEvent colorChanged;

    private VehicleColor selectedColor;
    private int selectedColorIndex;

    private void Start()
    {
        selectedColor = raceStarter.vehicleColor;
        selectedColorIndex = Array.IndexOf(vehicleColors, selectedColor);
        bodyImage.color = vehicleColors[selectedColorIndex].color;
        nameText.text = selectedColor.name;
    }

    public void NextColor()
    {
        selectedColorIndex++;
        if (selectedColorIndex == vehicleColors.Length) {
            selectedColorIndex = 0;
        }

        ChangeSelectedColor();
    }

    public void PreviousColor()
    {
        selectedColorIndex--;
        if (selectedColorIndex < 0) {
            selectedColorIndex = vehicleColors.Length - 1;
        }

        ChangeSelectedColor();
    }

    private void ChangeSelectedColor()
    {
        selectedColor = vehicleColors[selectedColorIndex];
        bodyImage.color = vehicleColors[selectedColorIndex].color;
        raceStarter.vehicleColor = selectedColor;
        nameText.text = selectedColor.name;
        colorChanged.Raise();
    }
}
