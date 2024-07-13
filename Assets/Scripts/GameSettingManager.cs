using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : MonoBehaviour
{
    [Header("Collisions Setting")]
    [SerializeField] private bool m_modifyCollisions = true;
    [SerializeField] private string m_firstLayer = "OpenedWall";
    [SerializeField] private string m_secondLayer = "BetweenWorlds";

    [Header("Skybox Setting")]
    [SerializeField] private bool m_modifySkybox = true;
    [SerializeField] private Material m_skyboxMaterial = null;

    private void Awake()
    {
        if (!m_modifyCollisions)
            return;
        
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer(m_firstLayer), LayerMask.NameToLayer(m_secondLayer));
    }
    
    public void SetupSybox()
    {
        if (!m_modifySkybox)
            return;
        if (!m_skyboxMaterial)
            return;
        
        RenderSettings.skybox = m_skyboxMaterial;
    }

}
