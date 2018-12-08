using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearWaste : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool found = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, Player.Instance.Top.position);

        if (hit.transform != null)
        {
            if (hit.transform.tag == "Player")
            {
                found = true;
                Player.Instance.Hit(Time.deltaTime);
            }
        }

        if (!found)
        {
            hit = Physics2D.Linecast(transform.position, Player.Instance.Bottom.position);
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    Player.Instance.Hit(Time.deltaTime);
                }
            }
        }
    }
}
