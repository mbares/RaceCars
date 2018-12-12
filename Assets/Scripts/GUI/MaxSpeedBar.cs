public class MaxSpeedBar : StatisticsBar
{
    protected override void UpdateValue()
    {
        trackedValue = raceStarter.engine.maxSpeedCoefficient;
    }
}
