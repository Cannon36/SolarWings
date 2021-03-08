using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

	public GameObject rock;//Get the rock object
	public int spawnNumber = 10;//how many to spawn?
	public int spwanRange = 1000;//How far to spawn them?

	// Use this for initialization
	void Start () {
		for (int y = 0; y < spawnNumber; y++) {//loop though "spawnnumber of times..
			Instantiate(rock,new Vector3(Random.Range(-spwanRange,spwanRange),Random.Range(-spwanRange,spwanRange),Random.Range(-spwanRange,spwanRange)),Random.rotation);//and create rocks at randome "spawnRange" distance

		}
	}
}