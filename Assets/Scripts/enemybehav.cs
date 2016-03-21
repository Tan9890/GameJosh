using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemybehav : MonoBehaviour {
    GameObject hero_target;
    public float speed = 2f;
    float step;
    public float attack_dist = 10.0F;
    public int dmg = -10;
    public int health = 100;
    bool isattacking = false;
    public float attackinterval = 1.0f;
    float attacktime = 0;

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
                hero_target = GetNearest();
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
                    if (Time.time > attacktime && hero_target != null)
                    {
                        hero_target.GetComponent<enemybehav>().health += dmg;
                        attacktime = Time.time + attackinterval;
                    }
                }
            }
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    GameObject GetNearest()
    {
        GameObject[] herosinscene = GameObject.FindGameObjectsWithTag("hero");
        //Debug.Log(herosinscene.Length);
        float nearest = Mathf.Infinity;
        GameObject nearest_hero = null;
        for(int i=0;i<herosinscene.Length;i++)
        {
            if (Vector3.Distance(transform.position, herosinscene[i].transform.position) <= nearest)
            {
                Debug.Log(Vector3.Distance(transform.position, herosinscene[i].transform.position));
                nearest_hero = herosinscene[i];
            }
        }
        return nearest_hero;
    }
}