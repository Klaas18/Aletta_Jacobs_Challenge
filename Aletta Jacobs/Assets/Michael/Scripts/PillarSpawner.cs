using UnityEngine;
using System.Linq;

public class PillarSpawner : MonoBehaviour
{

    public GameObject prefab;
    public GameObject[] cubesToSpawn;

    public Vector3 spawnLoc;
    public int size;

    public float[] heightF;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(JSONReader.myValueList.Value.Length);
        size = JSONReader.myValueList.Value.Length;
        cubesToSpawn = new GameObject[size];
        heightF = new float[size];

        for (int i = 0; i < size; i++)
        {
            GameObject cube = Instantiate(prefab, spawnLoc, new Quaternion());
            cube.transform.localScale.Set(5, 5, 5);
            cube.transform.localScale = new Vector3(5, 5, 5);
            cubesToSpawn.SetValue(cube, i);
            spawnLoc.x += 10;
        }

        foreach (var a in JSONReader.myValueList.Value)
        {
            heightF.SetValue(a.Height, index);
            index++;
        }

        for (int i = 0; i < cubesToSpawn.Length; i++)
        {
            cubesToSpawn[i].transform.localScale = new Vector3(cubesToSpawn[i].transform.localScale.x, heightF[i]/10, cubesToSpawn[1].transform.localScale.z);
        }



}

    // Update is called once per frame
    void Update()
    {

    }
}
