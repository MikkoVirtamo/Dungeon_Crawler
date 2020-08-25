using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlStats : MonoBehaviour
{
    public string weakness;
    public static GameControlStats Instance;

    public int currency;
    public float HP;
    public float attack;

    public List<GameObject> treasures = new List<GameObject>();
    public List<GameObject> upgrades = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetTreasure()
    {
        Debug.Log("GetTreasure called");
        if (treasures.Count > 0)
        {
            Debug.Log(treasures.Count);
            Debug.Log("treasures count is more than 0");
            int i = Random.Range(0, treasures.Count);
            Debug.Log(i);
            GameObject treasure = treasures[i];
            Debug.Log(treasure.name);
            treasures.RemoveAt(i);
            return treasure;
        }
        Debug.Log("treasures count 0 for some reason");
        return null;
    }
}
