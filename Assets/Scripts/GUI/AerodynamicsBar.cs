public class AerodynamicsBar : StatisticsBar
{
    protected override void UpdateValue()
    {
        trackedValue = raceStarter.vehicleBody.aerodynamicsCoefficient;
    }
}
