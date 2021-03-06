using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object= System.Object;
using System;

//TODO
//remake stats
//remake modifier
//make action handler and controller for Basic AI human.

[RequireComponent(typeof(Rigidbody2D))]
public class Humanoid : MonoBehaviour, Targetable, Visible, ISavable, Interactable {
	//serializable stats
	public Stats stats;
	public ItemContainer inventory;
	//private Weapon equipedWeapon;
	//Actioncontroller
	//AcrionHandler

	[SerializeField]
	private string prefab;

	//non-serializable stats
	[NonSerialized]
	public HitBox vision;
	[NonSerialized]
	public HitBox range;
	[NonSerialized]
	public HitBox reach;
	Rigidbody2D rb;
	Transform t;

	private Vector3 dir;

	void Awake(){
		t = this.transform;
		rb = GetComponent<Rigidbody2D>();

		vision = transform.Find("Vision").GetComponent<HitBox>();
		vision.setType(typeof(Visible));
		range = transform.Find("Range").GetComponent<HitBox>();
		range.setType(typeof(Targetable));
		reach = transform.Find("Reach").GetComponent<HitBox>();
		reach.setType(typeof(Interactable));

	}


	public void Move(float dx, float dy, int speed){

		if (Math.Abs(dx) >= .5){
			dx = 1 * Math.Sign(dx);
		}
		else{
			dx = 0;
		}

		if (Math.Abs(dy) >= .5){
			dy = 1 * Math.Sign(dy);
		}
		else{
			dy = 0;
		}
		//print("DX: " + dx + " DY:" + dy);
        if(Math.Abs(dx) >= 1 || Math.Abs(dy) >= 1){
			if(Math.Abs(dx) >= 1 && Math.Abs(dy) >= 1){
				float pos_x = (float)(Math.Sign(dx)*Math.Sqrt(1f/2f));
				float pos_y = (float)(Math.Sign(dy)*Math.Sqrt(1f/2f));
				dir = new Vector3(pos_x, pos_y,0) * Time.deltaTime * speed;
			} else{
				dir = new Vector3(dx,dy,0) * Time.deltaTime * speed;
			}

			//RB moveposition produced lag
			//t.position += dir;
			rb.MovePosition(this.transform.position + dir);

			//face towards
			dir.Normalize();
		 	this.transform.right = dir;
		}

	}

	public void MoveTo(Transform o){
		MoveTo(o.position);
	}

	public void MoveTo(Vector3 coord){
		Vector3 dir = coord - this.transform.position;
		Move(dir.x, dir.y, stats.getStatVal("Speed"));
	}

	public void lookAt(Vector3 pos){
		Vector3 dir = pos - this.transform.position;

		dir.Normalize();
		this.transform.right = dir;
	}


	void Update(){
		if(stats.getStatVal("Health") <= 0){
			//teardown();
			Destroy(this.gameObject);
		}

	}

	public void RecieveAttack(){
		this.stats.deltaStatVal("Health", -20);
	}

	public string getPrefab(){
		return this.prefab;
	}

	public void Interact(Humanoid h){

	}



}
