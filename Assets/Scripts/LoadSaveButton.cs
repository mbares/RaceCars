using UnityEngine;

public class LoadSaveButton : MonoBehaviour
{
    [SerializeField]
    private GameEvent saveRequest;
    [SerializeField]
    private GameEvent loadRequest;

    public void SaveRaceStarterData()
    {
        saveRequest.Raise();
    }

    public void LoadRaceStarterData()
    {
        loadRequest.Raise();
    }
}
