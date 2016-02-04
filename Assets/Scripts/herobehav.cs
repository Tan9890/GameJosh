using UnityEngine;
using System.Collections;

public class herobehav : MonoBehaviour {
    GameObject enemy_target;
    public float speed = 2f;
    public int health = 100;
    float step;
    public int dmg = 10;
    public int attack_dist = 5;
    bool isattacking = false;
    public bool isselected = false;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        //GetComponent<Renderer>().material.color = new Color((health / 100) * 255,0,0);
        if (health >= 0)
        {
            if (enemy_target == null)
            {
                enemy_target = GameObject.FindGameObjectWithTag("enemy");
            }
            else
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
                    enemy_target.GetComponent<enemybehav>().health -= dmg;
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
            GetComponent<Renderer>().material.color = new Color(1F, 0, 0) ;
        

    }
}
