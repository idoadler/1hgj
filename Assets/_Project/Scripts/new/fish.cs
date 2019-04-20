using UnityEngine;

public class fish : MonoBehaviour
{
    public float[] sizes;
    public GameObject[] patrolPoints;
    public float speed;
    public float delay;
    public GameObject rotator;

    private int size = 3;
    private int current = 0;

    private void Start()
    {
        UpdateSize();
        Invoke("Starve", delay);
    }

    // Update is called once per frame
    void Update()
    {
        rotator.transform.LookAt(patrolPoints[current].transform.position);
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[current].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolPoints[current].transform.position) < 0.5f)
        {
            current++;
            current %= patrolPoints.Length;
        }
    }

    public void Starve()
    {
        size--;
        UpdateSize();
        Invoke("Starve", delay);
    }

    public void Feed()
    {
        size++;
        UpdateSize();
    }

    public void UpdateSize()
    {
        if (size < 0)
        {
            LevelManager.Instance.LostLevel();
        }
        else if (size >= sizes.Length)
        {
            LevelManager.Instance.WinLevel();
        }
        else
        {
            transform.localScale = Vector3.one * sizes[size];
        }
    }
}
