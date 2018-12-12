using UnityEngine;

public class FinishingLine : MonoBehaviour
{
    [SerializeField]
    private GameEvent raceOverEvent;
    [SerializeField]
    private RaceStarter winner;

    private bool winnerSet = false;

    public void Reset()
    {
        winnerSet = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RaceCar raceCar = other.GetComponent<RaceCar>();
        if (!winnerSet) {
            winnerSet = true;
            winner.vehicleBody = raceCar.raceStarter.vehicleBody;
            winner.vehicleColor = raceCar.raceStarter.vehicleColor;
        }
        raceCar.EndRace();
        raceOverEvent.Raise();
    }
}
