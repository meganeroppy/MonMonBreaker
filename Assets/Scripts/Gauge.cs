using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Gauge : MonoBehaviour {

//	private Image image;
	private float dur = 0.5f;
	
	private void Awake(){
//		image = GetComponent<Image>();
	}
	
	private void Update(){
		float percent = (float)GameManager.cnt / (float)GameManager.MAX_CNT_EACH;
		
	//	Debug.Log(percent);
	//	Vector3 scl = transform.localScale;	
		
		transform.DOScaleX(percent, dur);
	
	}
}
