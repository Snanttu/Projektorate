using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Speed of camera delay when following player
    public float CameraDelay = 5f;
    // Camera offset from player
    public Vector3 CameraOffset = new Vector3(0, 0, 0);
    public MonoBehaviour AnimationComponent;
    public Vector3 MouseOffset = Vector3.zero;
    public bool Initialized = false;
    public float OffsetResetTime;

    // Players gameobject
    public GameObject _player;
    // Cameras current position
    private Vector3 _vCurPos;

    private float _tapTimer;
    private Quaternion _originalRotation;
    private bool shake = false;
    private float shakeAmount = 0;
    private float shakeDuration = 0;
    private float originalShakeDuration;

    public bool StopNormalCameraMovement { get; set; }


    public void ResetCamera(bool toPlayerPos = true)
    {
        StopNormalCameraMovement = false;
        transform.rotation = _originalRotation;

        if (toPlayerPos)
            transform.position = _player.transform.position + CameraOffset;
    }    

    void Update()
    {    
        
    }

    void FixedUpdate()
    {
        if (!StopNormalCameraMovement)
        {
            
         	_vCurPos = _player.transform.position + CameraOffset;
          	var time = Time.smoothDeltaTime * CameraDelay * 2;
          	_vCurPos = Vector3.Lerp(transform.position, _vCurPos + MouseOffset, time);
           	transform.position = _vCurPos;
            
        }
        
        
        /*if(MouseOffset == Vector3.zero)
        {
            _vCurPos = _player.transform.position + CameraOffset;
            var time = Time.smoothDeltaTime * CameraDelay;
            transform.position = Vector3.Lerp(transform.position, _vCurPos, time);
        } else
        {
            _vCurPos = _player.transform.position + CameraOffset + MouseOffset;
            transform.position = Vector3.Lerp(transform.position, _vCurPos, Time.smoothDeltaTime);
        }*/
    }

    public void Harlem(float amount, float duration)
    {
        shakeAmount = amount;
        shakeDuration = duration;
        originalShakeDuration = duration;
        shake = true;
    }

    public void AddMouseOffset(Vector3 offset)
    {
        Vector3 direction = (offset - _player.transform.position).normalized;        
        direction.y = 0;
        MouseOffset = direction * 2;
    }
}
