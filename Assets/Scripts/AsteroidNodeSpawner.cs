using UnityEngine;
using System.Collections;

public class AsteroidNodeSpawner : MonoBehaviour
{
    public GameObject asteroidNode;
    public int spawnNumber = 10;//how many to spawn?
    public int spwanXRange = 10000;//How far to spawn them?
    public int spwanYRange = 10000;//How far to spawn them?
    public int spwanZRange = 10000;//How far to spawn them?
    public int spwanXDeadZone = 1500;//How far to spawn them?
    public int spwanYDeadZone = 1500;//How far to spawn them?
    public int spwanZDeadZone = 1500;//How far to spawn them?

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < spawnNumber; y++)
        {//loop though "spawnnumber of times..
         //Instantiate(rock, new Vector3(Random.Range(-spwanRange, spwanRange), Random.Range(-spwanRange, spwanRange), Random.Range(-spwanRange, spwanRange)), Random.rotation);//and create rocks at randome "spawnRange" distance
            GameObject aspawn;
            int posX = 0;
            int posY = 0;
            int posZ = 0;

            while ((posX > -spwanXDeadZone && posX < spwanXDeadZone) && (posY > -spwanYDeadZone && posY < spwanYDeadZone) && (posZ > -spwanZDeadZone && posZ < spwanZDeadZone))
            {
                posX = Random.Range(-spwanXRange, spwanXRange);
                posY = Random.Range(-spwanYRange, spwanYRange);
                posZ = Random.Range(-spwanZRange, spwanZRange);
            }
            aspawn = (GameObject)Instantiate(asteroidNode, new Vector3(posX, posY, posZ), Random.rotation);
        }
    }
}
	
