using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selectionprovider : MonoBehaviour {

    public List<GameObject> selectedheros;
    Color herocolor;

	// Use this for initialization
	void Start () {
        //herocolor = GameObject.FindGameObjectWithTag("hero").GetComponent<Renderer>().material.GetColor("_Color");
        selectedheros = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(selectedheros.Count);
        //if (selectedheros.Count > 0)
        //{
        //    foreach (GameObject hero in selectedheros)
        //    {
        //        if (hero.GetComponent<herobehav>().isselected == true)
        //            hero.GetComponent<Renderer>().material.color = new Color(1F, 1F, 1F);
        //        else
        //            hero.GetComponent<Renderer>().material.color = herocolor;
        //    }
        //}
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hero")
        {
            selectedheros.Add(coll.gameObject);
            coll.gameObject.GetComponent<herobehav>().isselected = true;
        }
    }
}
