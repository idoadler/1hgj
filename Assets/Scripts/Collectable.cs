
using UnityEngine;

public class Collectable : MonoBehaviour {

    public int value = 10;

	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter2D(Collider2D col)
    {
//        Debug.Log(col.name);
        GameManager.Instance.UpdateScore(value);
        Destroy(gameObject);
    }
}
