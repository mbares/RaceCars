using UnityEngine;

public class StartRaceButton : MonoBehaviour
{
    [SerializeField]
    private GameEvent raceStartRequestedEvent;

    public void StartRace()
    {
        raceStartRequestedEvent.Raise();
    }
}
