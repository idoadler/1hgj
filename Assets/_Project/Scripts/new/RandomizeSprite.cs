
using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{
    public bool Coming = true;
    public float Speed = 1;

    public Sprite MaleTop;
    public Sprite MaleBottom;
    public Sprite FemaleTop;
    public Sprite FemaleBottom;

    public SpriteRenderer Top;
    public SpriteRenderer Bottom;

    // Start is called before the first frame update
    void Start()
    {
        if(Random.value > 0.5f)
        {
            Top.sprite = MaleTop;
            Bottom.sprite = MaleBottom;
        } else
        {
            Top.sprite = FemaleTop;
            Bottom.sprite = FemaleBottom;
        }
        Bottom.color = Random.ColorHSV();

        Speed += Random.value - 0.7f;
    }

    void Update()
    {
        ///        transform. .LookAt(Shop.Instance.transform);
        if (Coming)
        {
            Vector3 dir = Shop.Instance.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Vector3.MoveTowards transform.position
        }
        else
        {
            Vector3 dir = transform.position - Shop.Instance.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        transform.localPosition += transform.right * Time.deltaTime * Speed;
    }

    public void Hit()
    {
        Coming = false;
        Top.color = Color.black;
        Bottom.color = Color.black;
    }
}
