using UnityEngine;
using UnityEngine.UI;

public abstract class StatisticsBar : MonoBehaviour
{
    [SerializeField]
    protected RaceStarter raceStarter;
    [SerializeField]
    protected float maxValue;
    [SerializeField]
    protected Image fill;

    protected int trackedValue;

    protected abstract void UpdateValue();

    private void Start()
    {
        UpdateValue();
        UpdateBar();
    }

    public void UpdateBar()
    {
        UpdateValue();
        fill.fillAmount = trackedValue / maxValue;
    }
}
