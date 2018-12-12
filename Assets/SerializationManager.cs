using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializationManager : MonoBehaviour
{
    [SerializeField]
    private RaceStarter raceStarter1;
    [SerializeField]
    private RaceStarter raceStarter2;
    [SerializeField]
    private RaceStarter raceStarter3;
    [SerializeField]
    private VehicleBody[] bodies;
    [SerializeField]
    private VehicleColor[] colors;
    [SerializeField]
    private Engine[] engines;
    [SerializeField]
    private Tires[] tires;

    private void Start()
    {
        try {
            LoadRaceStarterData();
        } catch (System.IO.FileNotFoundException) {
            Debug.Log("RaceStarter files not found");
        }
    }

    public void SaveRaceStarterData()
    {
        RaceStarterSerializer.SaveRaceStarterData(RaceStarterToString(raceStarter1), raceStarter1.name);
        RaceStarterSerializer.SaveRaceStarterData(RaceStarterToString(raceStarter2), raceStarter2.name);
        RaceStarterSerializer.SaveRaceStarterData(RaceStarterToString(raceStarter3), raceStarter3.name);
    }

    private static string RaceStarterToString(RaceStarter raceStarter)
    {
        string data = raceStarter.vehicleBody.name + "|" + raceStarter.vehicleColor.name + "|" + raceStarter.engine.name + "|" + raceStarter.tires.name;
        return data;
    }

    public void LoadRaceStarterData()
    {
        string raceStarter1Data = RaceStarterSerializer.GetRaceStarterData(raceStarter1.name);
        string raceStarter2Data = RaceStarterSerializer.GetRaceStarterData(raceStarter2.name);
        string raceStarter3Data = RaceStarterSerializer.GetRaceStarterData(raceStarter3.name);

        StringDataToRaceStarter(raceStarter1, raceStarter1Data);
        StringDataToRaceStarter(raceStarter2, raceStarter2Data);
        StringDataToRaceStarter(raceStarter3, raceStarter3Data);
    }

    private void StringDataToRaceStarter(RaceStarter raceStarter, string data)
    {
        string[] parts = data.Split('|');
        raceStarter.vehicleBody = FindVehicleBodyByName(parts[0]);
        Debug.Log(raceStarter.name + " " + raceStarter.vehicleBody);
        raceStarter.vehicleColor = FindVehicleColorByName(parts[1]);
        raceStarter.engine = FindEngineByName(parts[2]);
        raceStarter.tires = FindTiresByName(parts[3]);
    }

    private VehicleBody FindVehicleBodyByName(string name)
    {
        for (int i = 0; i < bodies.Length; ++i) {
            if (bodies[i].name == name) {
                return bodies[i];
            }
        }

        return bodies[0];
    }

    private VehicleColor FindVehicleColorByName(string name)
    {
        for (int i = 0; i < colors.Length; ++i) {
            if (colors[i].name == name) {
                return colors[i];
            }
        }

        return colors[0];
    }

    private Engine FindEngineByName(string name)
    {
        for (int i = 0; i < engines.Length; ++i) {
            if (engines[i].name == name) {
                return engines[i];
            }
        }

        return engines[0];
    }

    private Tires FindTiresByName(string name)
    {
        for (int i = 0; i < tires.Length; ++i) {
            if (tires[i].name == name) {
                return tires[i];
            }
        }

        return tires[0];
    }
}
