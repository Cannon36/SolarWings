using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject rock;//Get the rock object
    public int spawnNumber = 10;//how many to spawn?
    public int spwanXRange = 1000;//How far to spawn them?
    public int spwanYRange = 1000;//How far to spawn them?
    public int spwanZRange = 1000;//How far to spawn them?
    public int spwanXDeadZone = 1000;//How far to spawn them?
    public int spwanYDeadZone = 1000;//How far to spawn them?
    public int spwanZDeadZone = 1000;//How far to spawn them?
    public float scaleMax = 1;
    public float scaleMin = 1;

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < spawnNumber; y++)
        {//loop though "spawnnumber of times..
         //Instantiate(rock, new Vector3(Random.Range(-spwanRange, spwanRange), Random.Range(-spwanRange, spwanRange), Random.Range(-spwanRange, spwanRange)), Random.rotation);//and create rocks at randome "spawnRange" distance
            GameObject r;
            int posX = 0;
            int posY = 0;
            int posZ = 0;
            
            while ((posX > -spwanXDeadZone && posX < spwanXDeadZone)&&(posY > -spwanYDeadZone && posY < spwanYDeadZone)&&(posZ > -spwanZDeadZone && posZ < spwanZDeadZone))
            {
                posX = Random.Range(-spwanXRange, spwanXRange);
                posY = Random.Range(-spwanYRange, spwanYRange);
                posZ = Random.Range(-spwanZRange, spwanZRange);
            }
            /*
            while (posY > -spwanYDeadZone && posY < spwanYDeadZone)
            {
                posY = Random.Range(-spwanYRange, spwanYRange);
            }
            while (posZ > -spwanZDeadZone && posZ < spwanZDeadZone)
            {
                posZ = Random.Range(-spwanZRange, spwanZRange);
            }*/
           r= (GameObject)Instantiate(rock, new Vector3(posX, posY, posZ),Random.rotation);
            r.GetComponent<Transform>().localScale *= Random.Range(scaleMin, scaleMax);
        }
    }
}