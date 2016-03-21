using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selectionprovider : MonoBehaviour {

    public List<GameObject> selectedheros;
    Color herocolor;

	// Use this for initialization
	void Start () {
        selectedheros = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(selectedheros.Count);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hero" && coll.gameObject.GetComponent<herobehav2>().isselected == false)
        {
            //Debug.Log(coll.gameObject.tag);
            selectedheros.Add(coll.gameObject);
            coll.gameObject.GetComponent<herobehav2>().isselected = true;
            //Debug.Log(selectedheros.Count);
        }   
    }
}
