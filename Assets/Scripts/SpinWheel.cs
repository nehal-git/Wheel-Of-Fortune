using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System.Runtime.InteropServices.ComTypes;

public class SpinWheel : MonoBehaviour
{
	public float spawnSeconds;
	public List< GameObject> Prefab;
	public GameObject spawnpoint;
	public Text SpinNumber;
	public List<int> prize;
	public List<AnimationCurve> animationCurves;
	
	private bool spinning;	
	private float anglePerItem;	
	private int randomTime;
	private int itemNumber;

	public int min, max;



	void Start(){
		spinning = false;
		anglePerItem = 360/prize.Count;

		InvokeRepeating("numbers",0f,0.05f);
	}
	
	void  Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && !spinning) {
			SpinNumber.text = "-";
				randomTime = Random.Range (2, 3);
			itemNumber = Random.Range (0, prize.Count);
			float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);
			
			StartCoroutine (SpinTheWheel (5 * randomTime, maxAngle));
		}

	
	}

   void numbers()
    {
		if (spinning)
		{

			SpinNumber.text = Random.Range(min, max).ToString();
		}
	}

    IEnumerator SpinTheWheel (float time, float maxAngle)
	{
		spinning = true;
		
		float timer = 0.0f;		
		float startAngle = transform.eulerAngles.z;		
		maxAngle = maxAngle - startAngle;
		
		int animationCurveNumber = Random.Range (0, animationCurves.Count);
		Debug.Log ("Animation Curve No. : " + animationCurveNumber);
		
		while (timer < time) {
		//to calculate rotation
			float angle = maxAngle * animationCurves [animationCurveNumber].Evaluate (timer / time) ;
			transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + startAngle);
			timer += Time.deltaTime;
			yield return 0;
		}
		
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, maxAngle + startAngle);
		spinning = false;
		SpinNumber.text = prize[itemNumber].ToString();
		Debug.Log ("Prize: " + prize [itemNumber]);//use prize[itemNumnber] as per requirement
		yield return new WaitForSeconds(spawnSeconds);
		Instantiate(Prefab[itemNumber], spawnpoint.transform.position, Quaternion.identity);

	}	
}
