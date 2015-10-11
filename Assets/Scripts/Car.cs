using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour {

	public List<GameObject> models = new List<GameObject>();
	private List<GameObject> effects = new List<GameObject>();
	Vector3 firePos = new Vector3 (1.26f, 0.93f);
	Vector3 smokePos = new Vector3 (1.26f, 0.93f);
	Vector3 smokeRot = new Vector3(-90f, 0f);
	Vector3 screwRot = new Vector3(270f, 0f);
	[SerializeField]
	private GameObject exp_sP;
	private GameObject exp_s;
	[SerializeField]
	private GameObject exp_lP;
	private GameObject exp_l;
	[SerializeField]
	private GameObject fire_sP;
	private GameObject fire_s;
	[SerializeField]
	private GameObject fire_lP;
	private GameObject fire_l;
	[SerializeField]
	private GameObject smoke_sP;
	private GameObject smoke_s;
	[SerializeField]
	private GameObject smoke_lP;	
	private GameObject smoke_l;	
	[SerializeField]
	private GameObject screwsP;
	private GameObject screws;
	
	
	private void Awake(){
		
		for(int i = 0 ; i < transform.childCount ; i++){
			models.Add( transform.GetChild(i).gameObject );
		}
		
	}
	
	private void Update(){
		foreach(GameObject o in models){
			o.SetActive( GameManager.dmg == models.IndexOf(o) );
		}
	}
	
	public void Hit(){
	
	}
	
	public void AddDamage(){
		Explode(true);
		AddEffect();

	//	Debug.Log("AddDamage(" + GameManager.dmg.ToString() + ")");

	}	
	
	public void UpdateEffect(){
		AddEffect();
	}
	
	private void AddEffect(){
		
		int val = GameManager.dmg;
		
		if(val > 1){
			if(smoke_s == null){
				smoke_s = Instantiate(smoke_sP) as GameObject;
				smoke_s.transform.SetParent(transform.parent);
				smoke_s.transform.localPosition = smokePos;
				smoke_s.transform.localRotation = Quaternion.Euler(smokeRot);
				effects.Add(smoke_s);
			}
			
			if(val > 2){
				if(smoke_l == null){
					smoke_l = Instantiate(smoke_lP) as GameObject;
					smoke_l.transform.SetParent(transform.parent);
					smoke_l.transform.localPosition = smokePos;
					smoke_l.transform.localRotation = Quaternion.Euler(smokeRot);
					effects.Add(smoke_l);
				}
				
				if(fire_s == null){
					fire_s = Instantiate(fire_sP) as GameObject;
					fire_s.transform.SetParent(transform.parent);
					fire_s.transform.localPosition = firePos;	
					effects.Add(fire_s);
				}
				
				if(val > 4){
					if(fire_l == null){
						fire_l = Instantiate(fire_lP) as GameObject;
						fire_l.transform.SetParent(transform.parent);
						fire_l.transform.localPosition = firePos;	
						effects.Add(fire_l);
					}
				}else{ // less than 4
					if(fire_l != null){
						Destroy(fire_l);
					}
				}
			}else{ // less than 2
				if(smoke_l != null){
					Destroy(smoke_l);
				}
				
				if(fire_s != null){
					Destroy(fire_s);
				}
				
				if(fire_l != null){
					Destroy(fire_l);
				}
			}
		}else{ // less than 1
			
		
			if(smoke_s != null){
				Destroy(smoke_s);
			}
			
			if(smoke_l != null){
				Destroy(smoke_l);
			}
			
			if(fire_s != null){
				Destroy(fire_s);
			}
			
			if(fire_l != null){
				Destroy(fire_l);
			}
		}
	
	}

	public void Explode(bool big=false){
		
		GameObject o = null;
		Vector3 offset = Vector3.zero;
		if(big){
			o = Instantiate(exp_lP, transform.position, Quaternion.identity) as GameObject;
			offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.5f, 1.5f), Random.Range(-0.5f, 0.5f));
			o.transform.position += offset;
			
			// screw
			o = Instantiate(screwsP, transform.position, Quaternion.Euler(screwRot)) as GameObject;
			effects.Add(o);	
				}else{
			
			o = Instantiate(exp_sP, transform.position, Quaternion.identity) as GameObject;
			offset = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0.5f, 1.5f), Random.Range(-1.5f, 1.5f));
			o.transform.position += offset;
		}
		

	}

	public void RemoveEffects(){
		foreach(GameObject o in effects){
			Destroy(o);
		}
	}
}
