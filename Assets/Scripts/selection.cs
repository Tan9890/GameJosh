using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selection : MonoBehaviour
{

    public GameObject selectioncube;
    GameObject terrain;
    GameObject select;
    Vector3 startpoint;
    List<GameObject> selectedheros;
    float selectiontime = 0.5f;
    RaycastHit hit;
    public Vector3 travel_target;
    int previousselection = 0;

    // Use this for initialization
    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Terrain");
        if (terrain == null)
            Debug.Log("noterr");
        travel_target = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Destroy(GameObject.FindGameObjectWithTag("selectioncube"));
            travel_target = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            if(terrain.GetComponent<Collider>().Raycast(ray,out hit,Mathf.Infinity))
            {
                startpoint = hit.point;
                //Debug.Log("hit");
                select = Instantiate(selectioncube, hit.point, new Quaternion()) as GameObject;
            }
            //else
                //Debug.Log("nothit");
        }

        if (Input.GetMouseButton(0))
        {
            select.transform.localScale += new Vector3(1F,0,1F);
        }

        if (Input.GetMouseButtonUp(0))
        {
 
            selectedheros = GameObject.FindGameObjectWithTag("selectioncube").GetComponent<selectionprovider>().selectedheros;
            if (selectedheros.Count == 0 && previousselection == 0)
            {
                GameObject[] heros = GameObject.FindGameObjectsWithTag("hero");
                for (int i = 0; i < heros.Length; i++)
                {
                    //if (heros[i].GetComponent<herobehav>().ismoving == false)
                        heros[i].GetComponent<herobehav2>().isselected = false;
                }
                //Debug.Log("traveltarget: " + hit.point);
            }
            else
            {
                travel_target = hit.point;
                //Debug.Log(selectedheros.Count);
            }
            previousselection = selectedheros.Count;
            GameObject[] selectionboxes = GameObject.FindGameObjectsWithTag("selectioncube");
            foreach (GameObject sel in selectionboxes)
            {
                GameObject.Destroy(sel);
            }

        }
    }
}