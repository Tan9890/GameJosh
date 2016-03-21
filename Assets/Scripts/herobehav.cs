using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class herobehav : MonoBehaviour
{
    GameObject enemy_target;
    public float movetotargetspeed = 10f;
    public float speed = 2f;
    public int health = 100;
    float step;
    public int dmg = -10;
    public int attack_dist = 5;
    float traveldistthresh = 5f;
    public int maskint = 8;
    public float attackinterval = 1.0f;
    float attacktime = 0;


    bool isattacking = false;
    public bool isselected = false;
    public bool ismoving = false;

    List<GameObject> enemies;

    public float searchRadius = 10f;
    Vector3 travel_target;
    GameObject mainCam;

    LayerMask mask;


    //Use this for initialization

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        mask = LayerMask.NameToLayer("EnemyLayer");
        enemies = new List<GameObject>();
    }

    //Update is called once per frame
    void Update()
    {
        //GetComponent<Renderer>().material.color = new Color((health / 100) * 255, 0, 0);
        if (health >= 0)
        {
            if (enemy_target == null)
            {
                //enemy_target = GameObject.FindGameObjectWithTag("enemy");
                //enemy_target = GetEnemiesinRange();
                enemy_target = GetEnemyinRange();
                //Debug.Log("Searching");
            }
            //else
            //{
            if (enemy_target != null)
            {
                if (Vector3.Distance(transform.position, enemy_target.transform.position) > attack_dist)
                {
                    step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, enemy_target.transform.position, step);
                    isattacking = false;
                }
                else
                {
                    isattacking = true;
                    if (Time.time > attacktime)
                    {
                        enemy_target.GetComponent<enemybehav>().health += dmg;
                        attacktime = Time.time + attackinterval;
                    }
                }
            }
            //}

            travel_target = mainCam.GetComponent<selection>().travel_target;
            //Debug.Log(travel_target);
            if (travel_target != new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity) && isselected == true)
            {
                if (Vector3.Distance(transform.position, travel_target) > traveldistthresh)
                {
                    step = movetotargetspeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, travel_target, step);
                    isattacking = false;
                    ismoving = true;
                }
                else
                {
                    ismoving = false;
                }
            }
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }


        if (isselected == true)
            GetComponent<Renderer>().material.color = new Color(1F, 1F, 1F);
        else
            GetComponent<Renderer>().material.color = new Color(1F, 0, 0);


    }

    //GameObject GetEnemiesinRange()
    //{
    //    Collider[] enemyColliders = Physics.OverlapSphere(transform.position, searchRadius, maskint);
    //    Debug.Log(enemyColliders.Length);
    //    if (enemyColliders.Length > 0)
    //    {
    //        List<GameObject> enemiesfound = new List<GameObject>();
    //        foreach (Collider coll in enemyColliders)
    //        {
    //            if (coll.gameObject.tag == "enemy")
    //                enemiesfound.Add(coll.gameObject);
    //        }
    //        //Debug.Log(enemiesfound.Count);
    //        int Randomenemy = Random.Range(0, enemiesfound.Count);
    //        return enemiesfound[Randomenemy].gameObject;
    //    }
    //    else
    //        return null;

    //}

    GameObject GetEnemyinRange()
    {
        List<GameObject> targetsfound = GetComponentInChildren<targetfinder>().targets;
        List<GameObject> enemiess = new List<GameObject>();
        if (targetsfound.Count > 0)
        {
            foreach (GameObject target in targetsfound)
            {
                if (target.tag == "enemy" && target != null)
                {
                    enemiess.Add(target);
                }
            }
        }
        if (enemiess.Count > 0)
        {
            int Randomenemy = Random.Range(0, enemiess.Count);
            return enemiess[Randomenemy].gameObject;
        }
        else
            return null;
    }
}
