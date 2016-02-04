using UnityEngine;
using System.Collections;

public class gamebehav : MonoBehaviour {

    public GameObject hero;
    public GameObject enemy;
    public int no_heros = 10;
    public int no_enemies = 10;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < no_heros; i++)
        {
            GameObject heros = Instantiate(hero, new Vector3(Random.Range(10, 40), 5, Random.Range(10, 40)), new Quaternion()) as GameObject;
        }
        for (int i = 0; i < no_enemies; i++)
        {
            GameObject enemies = Instantiate(enemy, new Vector3(Random.Range(-10, -40), 5, Random.Range(-10, -40)), new Quaternion()) as GameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
