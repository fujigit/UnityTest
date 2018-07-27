using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public GameObject siten;
	public GameObject syuuten;
	int i;
	// Use this for initialization
	void Start () {
		i = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		LineRenderer line = GameObject.Find("LineRendererObject").GetComponent<LineRenderer> ();

		line.SetPosition (0, siten.transform.position);
		line.SetPosition (1, syuuten.transform.position);
		line.SetVertexCount(i++);
		//line.SetPosition関数の第一引数は配列の要素数(配列は0スタートです！,第二引数は座標です)

		line.startWidth = 0.5f;
		line.endWidth = 0.5f;
		
	}
}
