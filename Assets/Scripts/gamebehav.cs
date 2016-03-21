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
            Instantiate(hero, new Vector3(Random.Range(10, 40), 1, Random.Range(10, 40)), new Quaternion());
        }
        for (int i = 0; i < no_enemies; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(-10, -40), 1, Random.Range(-10, -40)), new Quaternion());
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
