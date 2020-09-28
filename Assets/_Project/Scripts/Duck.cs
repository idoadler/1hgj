using UnityEngine;

public class Duck : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    public int children = 2;
    public int score = 1;

    void Update()
    {
        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            LevelManager.Instance.Hit(gameObject);
        }
    }

    public void killed()
    {
        LevelManager.Instance.AddScore(score);
        if (children > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, -1);
            score++;
            children--;
            var brother = Instantiate(gameObject);
            brother.transform.position += 0.2f * Vector3.left * Random.value;
            brother.transform.position += 0.2f * Vector3.up * (Random.value - 0.5f);
            brother.GetComponent<Duck>().children = children;
            brother.GetComponent<Duck>().score = score;
            transform.position += 0.2f * Vector3.right * Random.value;
            transform.position += 0.2f * Vector3.up * (Random.value - 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}