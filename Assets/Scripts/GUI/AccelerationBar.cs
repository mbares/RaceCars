public class AccelerationBar : StatisticsBar
{
    protected override void UpdateValue()
    {
        trackedValue = raceStarter.tires.accelerationCoefficient;
    }
}
