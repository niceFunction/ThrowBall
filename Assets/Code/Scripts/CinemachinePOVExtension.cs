
using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField]
    private float _horizontalSpeed = 10f;
    [SerializeField]
    private float _verticalSpeed = 10f;

    [SerializeField]
    private float _clampAngle = 80f;

    private InputManager _inputManager;
    private Vector3 _startingRotation;

    protected override void Awake()
    {
        _inputManager = InputManager.Instance;
        base.Awake();
        if (_startingRotation == null)
        {
            _startingRotation = transform.localRotation.eulerAngles;
        }
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
       if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = _inputManager.GetMouseDelta();
                _startingRotation.x += deltaInput.x * _verticalSpeed * Time.deltaTime;
                _startingRotation.y += deltaInput.y * _horizontalSpeed * Time.deltaTime;
                _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
            }
        }
    }
}
