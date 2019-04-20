using UnityEngine;

public class foodMachine : MonoBehaviour
{
    public Camera cam;
    public GameObject target;
    public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 15;
        pos = Camera.main.ScreenToWorldPoint(pos);
        target.transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, target.transform.position, Quaternion.identity, transform);
        }
    }
}
