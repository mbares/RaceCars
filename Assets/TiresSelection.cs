using System;
using UnityEngine;
using UnityEngine.UI;

public class TiresSelection : MonoBehaviour
{
    [SerializeField]
    private RaceStarter raceStarter;
    [SerializeField]
    private Tires[] tires;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameEvent tiresChanged;

    private Tires selectedTires;
    private int selectedTiresIndex;

    private void Start()
    {
        selectedTires = raceStarter.tires;
        selectedTiresIndex = Array.IndexOf(tires, selectedTires);
        nameText.text = selectedTires.name;
    }

    public void NextTires()
    {
        selectedTiresIndex++;
        if (selectedTiresIndex == tires.Length) {
            selectedTiresIndex = 0;
        }

        ChangeSelectedTires();
    }

    public void PreviousTires()
    {
        selectedTiresIndex--;
        if (selectedTiresIndex < 0) {
            selectedTiresIndex = tires.Length - 1;
        }

        ChangeSelectedTires();
    }

    private void ChangeSelectedTires()
    {
        selectedTires = tires[selectedTiresIndex];
        raceStarter.tires = selectedTires;
        nameText.text = selectedTires.name;
        tiresChanged.Raise();
    }
}
