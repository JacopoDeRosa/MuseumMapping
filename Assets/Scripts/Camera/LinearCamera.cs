using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LinearCamera : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _horizontalOffset;

    private Vector3 _leftMax, _rightMax;

    private float _evaluation;
    private PlayerInput _input;
    private Vector2 _mouseDelta;
    private bool _focused;
    private bool _started;

    private void Awake()
    {
        _leftMax = new Vector3(-_horizontalOffset, 0, 0);
        _rightMax = new Vector3(_horizontalOffset, 0, 0);
        _evaluation = 0.5f;
    }

    private void Start()
    {
        _input = PlayerInputSingleton.Instance;
        if (_input)
        {
            _input.actions["Look"].performed += OnMouseLook;
            _input.actions["Focus"].started += OnFocusStart;
            _input.actions["Focus"].canceled += OnFocusEnd;

        }

        _started = true;
    }

    private void OnEnable()
    {
        if (_started == false) return;
        _input = PlayerInputSingleton.Instance;
        if (_input)
        {
            _input.actions["Look"].performed += OnMouseLook;
            _input.actions["Focus"].started += OnFocusStart;
            _input.actions["Focus"].canceled += OnFocusEnd;

        }
    }

    private void OnDisable()
    {
        if (_input)
        {
            _input.actions["Look"].performed -= OnMouseLook;
            _input.actions["Focus"].started -= OnFocusStart;
            _input.actions["Focus"].canceled -= OnFocusEnd;
        }
    }

    private void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }

    private void OnFocusStart(InputAction.CallbackContext context)
    {
        _focused = true;
    }
    private void OnFocusEnd(InputAction.CallbackContext context)
    {
        _focused = false;
    }
   
    public void ChangeEvaluation(float change)
    {
        _evaluation += change;
        _evaluation = Mathf.Clamp01(_evaluation);
        transform.position = Vector3.Lerp(_leftMax, _rightMax, _evaluation);
    }

    private void Update()
    {
        if(_focused)
        {
            ChangeEvaluation(-(_mouseDelta.x * _moveSpeed * Time.deltaTime));
        }
    }
}

