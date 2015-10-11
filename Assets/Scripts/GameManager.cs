using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[SerializeField]
	Car car;
	
		

	public static int cnt=0;
	public static int MAX_CNT = 0;
	public const int MAX_CNT_EACH = 5;
	public static int dmg=0;
	public static int maxDmgLv;
	
	private APItest api;
	
	public static int localVal = 0;
	
	private void Awake(){
		api = GetComponent<APItest>();
	}
	
	private void Start(){
		maxDmgLv = car.models.Count;
		MAX_CNT = maxDmgLv * MAX_CNT_EACH;
	}
	
	private void Update(){
		int diff = api.val - localVal;
		localVal = api.val % MAX_CNT;
		
		int prevDmg = dmg;
		
		dmg = (int)(localVal / MAX_CNT_EACH);
		cnt = localVal % MAX_CNT_EACH;
		
		if(dmg != prevDmg){
			car.UpdateEffect();
		}
		
		Debug.Log("localVal:" + localVal.ToString() );
		
		if(diff > 0){
			car.Explode(dmg != prevDmg);
		}
	}

	
	public void AddCnt(){
	
		cnt++ ;
		car.Hit();
		
		//	Debug.Log("AddCnt(" + cnt.ToString() + ")");
		
		if(cnt >= MAX_CNT){
			car.AddDamage();
			cnt = 0;
			dmg++;
			
			if(dmg >= maxDmgLv){
				dmg = 0;
				car.RemoveEffects();
			}
		}else{
			car.Explode();
		}
	}
	
}
