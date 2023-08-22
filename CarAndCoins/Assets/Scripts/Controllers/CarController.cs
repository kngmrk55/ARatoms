namespace Scripts.Controllers
{
    using Scripts.Game;
    using UnityEngine;


    public class CarController : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        Rigidbody _carRigidbody;

        [SerializeField]
        public WheelCollider[] _wheelColliders;

        [SerializeField]
        public Transform[] _wheelsTransform;

        [SerializeField]
        public GameObject _brakeLights = null;

        [SerializeField]
        float _motorTorque = 100;

        [SerializeField]
        float _streeringAngle = 45;

        #endregion

        #region Properties

        Vector3 _originalPosition = Vector3.zero;

        #endregion

        #region Monobehaviour

        void Start ()
        {
            _originalPosition = transform.position;
        }

        void Update()
        {
            if (GameManager.Instance.isPlaying)
            {
                _carRigidbody.isKinematic = false;
                for (int i = 0; i < _wheelColliders.Length; i++) //For every wheel, apply torque
                {
                    _wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * _motorTorque;
                    if (i == 0 || i == 2)
                    {
                        _wheelColliders[i].steerAngle = Input.GetAxis("Horizontal") * _streeringAngle;
                    }
                    var pos = transform.position;
                    var rot = transform.rotation;
                    _wheelColliders[i].GetWorldPose(out pos, out rot); //Set wheels position as wheel colliders
                    _wheelsTransform[i].position = pos;
                    _wheelsTransform[i].rotation = rot;

                }

                if (Input.GetAxis("Vertical") != 0) //Axis button pressed
                {
                    bool reverse = isReverse();
                    bool foward = isForward();
                    if(Input.GetAxis("Vertical") < 0 && foward || Input.GetAxis("Vertical") > 0 && reverse) //Brake car with opposite key
                    {
                        foreach (var i in _wheelColliders)
                            i.brakeTorque = Mathf.Infinity;

                        _brakeLights.SetActive(true);
                        GameManager.Instance.increaseEngineSoundPitch(-0.01f);
                    }

                    else
                    {
                        foreach (var i in _wheelColliders)
                            i.brakeTorque = 0;
                        _brakeLights.SetActive(false);
                        GameManager.Instance.increaseEngineSoundPitch(0.001f);
                    }
                }

                if (Input.GetAxis("Vertical") == 0) //Axis button released
                {
                    foreach (var i in _wheelColliders) //Brake car on key released
                        i.brakeTorque = Mathf.Infinity;

                    _brakeLights.SetActive(true);
                    GameManager.Instance.increaseEngineSoundPitch(-0.01f);
                }

            }
            else //Finish game
            {
                _carRigidbody.isKinematic = true;
                GameManager.Instance.increaseEngineSoundPitch(-1f);
            }
        
        }

        #endregion

        #region Utils

        public void resetCar()
        {
            transform.position = _originalPosition;
            transform.rotation = Quaternion.identity;
        }

        bool isReverse() //Check if car is moving on reverse
        {
            foreach (var i in _wheelColliders)
            {
                if (i.rpm >= 0)
                    return false;
            }
            return true;
        }

        bool isForward() //Check if car is moving on forward
        {
            foreach (var i in _wheelColliders)
            {
                if (i.rpm <= 0)
                    return false;
            }
            return true;
        }

        #endregion

    }
}

