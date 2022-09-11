using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearCamera : MonoBehaviour
{
    [SerializeField] private float _horizontalOffset;

    private Vector3 _leftMax, _rightMax;

    private void Awake()
    {
        _leftMax = new Vector3(-_horizontalOffset, 0, 0);
        _rightMax = new Vector3(_horizontalOffset, 0, 0);
    }

    public void ChangeEvaluation(float evaluation)
    {
        evaluation = Mathf.Clamp01(evaluation);
        transform.position = Vector3.Lerp(_leftMax, _rightMax, evaluation);
    }
}

