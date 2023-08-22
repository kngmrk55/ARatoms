namespace Scripts.Game
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        GameObject _player;

        #endregion

        #region MonoBehaviour

        void FixedUpdate()
        {
            transform.position = _player.transform.position;

            //Rotate camera pivot
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, _player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        #endregion

    }
}