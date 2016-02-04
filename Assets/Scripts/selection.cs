using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selection : MonoBehaviour
{

    public GameObject selectioncube;
    GameObject terrain;
    GameObject select;
    Vector3 startpoint;

    // Use this for initialization
    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Terrain");
        if (terrain == null)
            Debug.Log("noterr");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Destroy(GameObject.FindGameObjectWithTag("selectioncube"));
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            if(terrain.GetComponent<Collider>().Raycast(ray,out hit,Mathf.Infinity))
            {
                startpoint = hit.point;
                Debug.Log("hit");
                select = Instantiate(selectioncube, hit.point, new Quaternion()) as GameObject;
            }
            else
                Debug.Log("nothit");
        }

        if (Input.GetMouseButton(0))
        {
            select.transform.localScale += new Vector3(1F,0,1F);
        }

        if (Input.GetMouseButtonUp(0))
        {
 
            List<GameObject> selectedheros = GameObject.FindGameObjectWithTag("selectioncube").GetComponent<selectionprovider>().selectedheros;
            if (selectedheros.Count == 0)
            {
                GameObject[] heros = GameObject.FindGameObjectsWithTag("hero");
                foreach (GameObject hero in heros)
                {
                    hero.GetComponent<herobehav>().isselected = false;
                }
            }

            GameObject[] selectionboxes = GameObject.FindGameObjectsWithTag("selectioncube");
            foreach (GameObject sel in selectionboxes)
            {
                GameObject.Destroy(sel);
            }

        }
    }
}