using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public GameObject syujin;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		syujin=GameObject.Find("unitychan_dynamic");
		enemy = GameObject.Find ("enemy");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = syujin.transform.position;
		this.transform.rotation = Quaternion.LookRotation(enemy.transform.position-syujin.transform.position);
		
	}
}