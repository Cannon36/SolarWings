using UnityEngine;
using System.Collections;

public class AsteroidSpawnerV2 : MonoBehaviour {

    public GameObject rock;//Get the rock object
    public int spawnNumberMax = 10;//how many to spawn?
    public int spawnNumberMin = 10;
    public int spwanXRange = 1000;//How far to spawn them?
    public int spwanYRange = 1000;//How far to spawn them?
    public int spwanZRange = 1000;//How far to spawn them?

    public float XscaleMax = 1;
    public float XscaleMin = 1;
    public float YscaleMax = 1;
    public float YscaleMin = 1;
    public float ZscaleMax = 1;
    public float ZscaleMin = 1;


    // Use this for initialization
    void Start()
    {

        int spawnNumber = Random.Range(spawnNumberMin, spawnNumberMax);

        for (int y = 0; y < spawnNumber; y++)
        {//loop though "spawnnumber of times..
         //Instantiate(rock, new Vector3(Random.Range(-spwanRange, spwanRange), Random.Range(-spwanRange, spwanRange), Random.Range(-spwanRange, spwanRange)), Random.rotation);//and create rocks at randome "spawnRange" distance
            GameObject r;
            int posX = 0;
            int posY = 0;
            int posZ = 0;
            
                posX = Random.Range(-spwanXRange, spwanXRange);
                posY = Random.Range(-spwanYRange, spwanYRange);
                posZ = Random.Range(-spwanZRange, spwanZRange);
           r= (GameObject)Instantiate(rock, new Vector3(posX, posY, posZ)+transform.position,Random.rotation);
           r.GetComponent<Transform>().localScale += new Vector3(Random.Range(XscaleMin, XscaleMax), Random.Range(YscaleMin, YscaleMax), Random.Range(ZscaleMin, ZscaleMax));
        }
    }
}