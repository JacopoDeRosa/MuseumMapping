using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _orbitalCam, _linearCam;

    public UnityEvent onOrbitalCam;
    public UnityEvent onLinearCam;

    public void SwitchCamera()
    {
        if(_orbitalCam.activeInHierarchy)
        {
            _linearCam.SetActive(true);
            _orbitalCam.SetActive(false);
            onLinearCam.Invoke();
        }
        else if(_linearCam.activeInHierarchy)
        {
            _linearCam.SetActive(false);
            _orbitalCam.SetActive(true);
            onOrbitalCam.Invoke();
        }
    }
}
