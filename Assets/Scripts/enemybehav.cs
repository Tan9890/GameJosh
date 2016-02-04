using UnityEngine;
using System.Collections;

public class enemybehav : MonoBehaviour {
    GameObject hero_target;
    public float speed = 2f;
    float step;
    public int attack_dist = 5;
    public int dmg = 10;
    public int health = 100;
    bool isattacking = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, (health / 100) * 255);
        if (health >= 0)
        {
            if (hero_target == null)
            {
                hero_target = GameObject.FindGameObjectWithTag("hero");
            }
            else
            {
                if (Vector3.Distance(transform.position, hero_target.transform.position) > attack_dist)
                {
                    step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, hero_target.transform.position, step);
                    isattacking = false;
                }
                else
                {
                    isattacking = true;
                    hero_target.GetComponent<herobehav>().health -= dmg;
                }
            }
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}