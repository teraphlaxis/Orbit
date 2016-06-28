using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale < 100)
        {
            Time.timeScale += 1;
        }

        if (Input.GetKeyDown(KeyCode.Q) && Time.timeScale > 1)
        {
            Time.timeScale -= 1;
        }
    }
}
