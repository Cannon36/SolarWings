using UnityEngine;
using System.Collections;

public class NodeSpawnerMoon : MonoBehaviour {

    public GameObject node;//Get the ship object
    public int spawnNumber = 10;//how many to spawn?
    public int spwanRange = 1000;//How far to spawn them?

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < spawnNumber; y++)
        {//loop though "spawnnumber of times..
            Instantiate(node, new Vector3(Random.Range(-spwanRange, spwanRange), Random.Range(100, spwanRange), Random.Range(-spwanRange, spwanRange)), Random.rotation);//and create ships at randome "spawnRange" distance

        }
    }
}
