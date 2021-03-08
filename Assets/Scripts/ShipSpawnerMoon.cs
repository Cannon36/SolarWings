using UnityEngine;
using System.Collections;

public class ShipSpawnerMoon : MonoBehaviour {

    public GameObject ship;//Get the ship object
    public int spawnNumber = 10;//how many to spawn?
    public int spwanRange = 1000;//How far to spawn them?

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < spawnNumber; y++)
        {//loop though "spawnnumber of times..
            Instantiate(ship, new Vector3(Random.Range(-spwanRange, spwanRange), Random.Range(100, spwanRange), Random.Range(-spwanRange, spwanRange)), Random.rotation);//and create ships at randome "spawnRange" distance

        }
    }
}