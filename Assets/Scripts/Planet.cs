using UnityEngine;
using System.Collections.Generic;

public class Planet : MonoBehaviour
{
    public static List<Planet> m_Planets;
    internal Rigidbody m_Body;
    private Collider m_Collider;
    private ParticleSystem m_Particles;

    void Start()
    {
        m_Body = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        m_Body.useGravity = false;

        m_Particles = GetComponentInChildren<ParticleSystem>();
        if (m_Particles != null? (m_Particles.GetComponent<FollowObject>() == null) : true)
            return;

        m_Particles.GetComponent<FollowObject>().m_FollowObject = transform;
        m_Particles.transform.parent = null;
        m_Particles.Play();
    }

    void Update() { }

    void FixedUpdate()
    {
        if (m_Planets == null)
        {
            m_Planets = new List<Planet>(FindObjectsOfType<Planet>());
        }

        float G = 6.67408f * Mathf.Pow(10, 1) * (1.33333f * Mathf.PI * Mathf.Pow(m_Collider.bounds.extents.x, 3)) * Mathf.Pow(m_Body.mass, -1);
        foreach (Planet planet in m_Planets)
        {
            if (planet == null)
                continue;

            float r = (planet.transform.position - transform.position).magnitude;
            float f = G * (planet.m_Body.mass * m_Body.mass / Mathf.Pow(r, 2));

            Vector3 vec = (transform.position - planet.transform.position).normalized * f;

            if (!float.IsNaN(vec.x) && !float.IsNaN(vec.y) && !float.IsNaN(vec.z))
                planet.m_Body.AddForce(vec);
        }
    }

    void OnCollisionEnter(Collision a_col)
    {
        Planet other = a_col.gameObject.GetComponent<Planet>();

        if (other == null)
            return;

        if (other.m_Body.mass >= m_Body.mass)
        {
            if (!other.m_Body.isKinematic)
                other.m_Body.mass += m_Body.mass;

            Kill();
            Destroy(gameObject);
        }
    }

    void Kill()
    {
        if (m_Particles == null) return;

        m_Particles.Stop();
        Destroy(m_Particles.gameObject, 50f);
    }
}