using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float power = 10;
    public float speed = 3;
    public GameObject sign;
    public float distance = 1;
    private float t = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sign.transform.localPosition = distance * CalculatedPower() + Vector3.forward * 0.7f;
		if (Input.GetMouseButtonUp(0))
        {
            ThrowMe();
        } else if (Input.GetMouseButton(0))
        {
            t += Time.deltaTime;
        }
	}

    private Vector3 CalculatedPower()
    {
        return Vector3.forward * (1 + Mathf.Sin(t * speed));
    }

    private void ThrowMe()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(CalculatedPower() * power, ForceMode.Impulse);
        Debug.Log(t);
        t = 0;
    }
}
