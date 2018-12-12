using System;
using UnityEngine;
using UnityEngine.UI;

public class EngineSelection : MonoBehaviour
{
    [SerializeField]
    private RaceStarter raceStarter;
    [SerializeField]
    private Engine[] engines;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameEvent engineChanged;

    private Engine selectedEngine;
    private int selectedEngineIndex;

    private void Start()
    {
        selectedEngine = raceStarter.engine;
        selectedEngineIndex = Array.IndexOf(engines, selectedEngine);
        nameText.text = selectedEngine.name;
    }

    public void NextEngine()
    {
        selectedEngineIndex++;
        if (selectedEngineIndex == engines.Length) {
            selectedEngineIndex = 0;
        }

        ChangeSelectedEngine();
    }

    public void PreviousEngine()
    {
        selectedEngineIndex--;
        if (selectedEngineIndex < 0) {
            selectedEngineIndex = engines.Length - 1;
        }

        ChangeSelectedEngine();
    }

    private void ChangeSelectedEngine()
    {
        selectedEngine = engines[selectedEngineIndex];
        raceStarter.engine = selectedEngine;
        nameText.text = selectedEngine.name;
        engineChanged.Raise();
    }
}
