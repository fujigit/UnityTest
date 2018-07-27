using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

	Rigidbody rb;
	//移動スピード
	public float moveSpeed = 2f;

	public float speed = 8f;
	//ジャンプ力
	public float thrust = 100;
	//Animatorを入れる変数
	private Animator animator;
	//Planeに触れているか判定するため
	bool ground;

	public Joystick joystick;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		//UnityちゃんのAnimatorにアクセスする
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		Vector3 cameraForward = Vector3.Scale (Camera.main.transform.forward, new Vector3 (1, 0, 1)).normalized;
		Vector3 moveVector = (Camera.main.transform.right * joystick.Horizontal + cameraForward * joystick.Vertical);
		//地面に触れている場合発動
		if (ground)
		{
			

			if (moveVector != Vector3.zero)
			{ 
				transform.rotation = Quaternion.LookRotation(moveVector);
				transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
				if (moveVector.magnitude >= 0.3) {
					animator.SetBool ("Running", true);
					animator.SetBool ("Walk", false);
				} else if (moveVector.magnitude >= 0.05 && moveVector.magnitude <= 2.9) {
					animator.SetBool ("Walk", true);
					animator.SetBool ("Running", false);
				}
				Debug.Log(moveVector.magnitude);
			}

			else
			{
				animator.SetBool("Running", false);
				animator.SetBool ("Walk", false);
			}

			//スペースキーでジャンプする
			if (Input.GetKey(KeyCode.Space))
			{
				animator.SetBool("Jumping", true);
				//上方向に向けて力を加える
				rb.AddForce(new Vector3(0, thrust, 0));
				ground = false;
			}
			else
			{
				animator.SetBool("Jumping", false);
			}
		}
	}

	//別のCollider、今回はPlaneに触れているかどうかを判断する
	void OnCollisionStay(Collision col)
	{
		ground = true;
	}
}