public class ReactionTimeBar : StatisticsBar
{
    protected override void UpdateValue()
    {
        trackedValue = raceStarter.vehicleColor.reactionTimeCoefficient;
    }
}
