using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public LayerMask m_PlanetLayer;

    private Planet m_SelectedPlanet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale < 99)
        {
            if (Time.timeScale >= 1)
            {
                Time.timeScale += 1;
            }
            else
            {
                Time.timeScale += 0.1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && Time.timeScale > 0.1f)
        {
            if (Time.timeScale > 1)
            {
                Time.timeScale -= 1;
            }
            else
            {
                Time.timeScale -= 0.1f;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(0, 0, 10));
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 1000, m_PlanetLayer))
            {
                if (hitinfo.collider.GetComponent<Planet>() != null)
                {
                    m_SelectedPlanet = hitinfo.collider.GetComponent<Planet>();
                }
            }
        }
    }
}
