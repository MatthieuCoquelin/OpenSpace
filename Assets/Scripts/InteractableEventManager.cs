using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using System;
using UnityEngine.Events;

public class InteractableEventManager : MonoBehaviour
{
    [SerializeField, Interface(typeof(IInteractableView))]
    private UnityEngine.Object _interactableView;

    [SerializeField] private UnityEvent m_interactableNormalEvent;
    [SerializeField] private UnityEvent m_interactableHoverEvent;
    [SerializeField] private UnityEvent m_interactableSelectEvent;
    [SerializeField] private UnityEvent m_interactableDisabledEvent;
    

    private IInteractableView m_interactableView;

    protected virtual void Awake()
    {
        m_interactableView = _interactableView as IInteractableView;
    }

    private void OnEnable()
    {
        m_interactableView.WhenStateChanged += StateUpdater;
    }


    private void OnDisable()
    {
        m_interactableView.WhenStateChanged -= StateUpdater;
    }

    private void StateUpdater(InteractableStateChangeArgs obj)
    {
        switch (m_interactableView.State)
        {
            case InteractableState.Normal:
                m_interactableNormalEvent.Invoke();
                break;
            case InteractableState.Hover:
                m_interactableHoverEvent.Invoke();
                break;
            case InteractableState.Select:
                m_interactableSelectEvent.Invoke();
                break;
            case InteractableState.Disabled:
                m_interactableDisabledEvent.Invoke();
                break;
        }
    }

}
