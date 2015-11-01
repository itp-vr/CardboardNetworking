using UnityEngine;
using System.Collections;


public class LerpDemo : MonoBehaviour {
	public Vector3 ValueA;
	public Vector3 ValueB;
	public float LerpMult;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float lerpTime = LerpMult;
		Vector3 newValue = Vector3.Lerp(ValueA, ValueB, lerpTime);
		print ("lerp time:"+lerpTime+", new value:"+newValue);
	}
}
