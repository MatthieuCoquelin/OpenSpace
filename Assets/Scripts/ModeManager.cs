using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Meta.XR.MRUtilityKit;


public class ModeManager : MonoBehaviour
{
    [SerializeField] private RayInteractable[] m_rayInteractables;
    [SerializeField] private BallSpawner m_ballSpawner;

    public void FindInteractables()
    {
        m_rayInteractables = FindObjectsOfType<RayInteractable>();
    }

    private enum Mode
    {
        Wall,
        Ball,
    };

    private Mode m_mode;

    // Start is called before the first frame update
    void Start()
    {
        m_ballSpawner.enabled = false;
        m_mode = Mode.Wall;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.A) || OVRInput.GetUp(OVRInput.RawButton.X))
            SwitchMode();
    }

    private void SwitchMode()
    {
        switch (m_mode)
        {
            case Mode.Wall:
                m_mode = Mode.Ball;
                foreach (var rayInteractable in m_rayInteractables)
                    rayInteractable.enabled = false;
                m_ballSpawner.enabled = true;
                print("Ball mode");
                return;
            case Mode.Ball:
                m_mode = Mode.Wall;
                foreach (var rayInteractable in m_rayInteractables)
                    rayInteractable.enabled = true;
                m_ballSpawner.enabled = false;
                print("Wall mode");
                return;
            default:
                return;
        }
    }
}
