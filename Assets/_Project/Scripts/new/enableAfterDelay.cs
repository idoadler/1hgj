using UnityEngine;

public class enableAfterDelay : MonoBehaviour
{
    public GameObject target;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        target.SetActive(false);
        Invoke("EnableTarget", delay * 10);
    }

    private void EnableTarget()
    {
        target.SetActive(true);
    }
}
