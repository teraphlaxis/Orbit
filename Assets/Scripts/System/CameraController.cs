using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float m_RotationSpeed = 1f;
    public float m_MoveForce = 10f;
    public float m_ScrollSpeed = 0.5f;

    public Transform m_MinY;
    public Transform m_MaxY;

    private float m_ScrollTarg;

    void Start()
    {
        m_ScrollTarg = 0.5f;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.unscaledDeltaTime * m_RotationSpeed * Mathf.Clamp(m_ScrollTarg, 0.05f, 1), 0, Space.World);
            m_MinY.parent.Rotate(0, Input.GetAxis("Mouse X") * Time.unscaledDeltaTime * m_RotationSpeed * Mathf.Clamp(m_ScrollTarg, 0.05f, 1), 0, Space.World);
        }

        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            move += transform.GetChild(0).forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move -= transform.GetChild(0).forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right;
        }

        //m_Body.AddForce(move * m_MoveForce * Mathf.Clamp(m_ScrollTarg, 0.2f, 1));
        transform.parent.parent.position += (move * m_MoveForce * Mathf.Clamp(m_ScrollTarg, 0.05f, 1)) * Time.unscaledDeltaTime;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            m_ScrollTarg -= Input.GetAxis("Mouse ScrollWheel") * m_ScrollSpeed * m_ScrollTarg;
            m_ScrollTarg = Mathf.Clamp(m_ScrollTarg, 0, 1);
        }

        transform.localPosition = Vector3.Lerp(m_MinY.localPosition, m_MaxY.localPosition, m_ScrollTarg);
    }
}
