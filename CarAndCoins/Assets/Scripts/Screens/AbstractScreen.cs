namespace Scripts.Screens
{
    using UnityEngine;

    public abstract class AbstractScreen : MonoBehaviour
    {
        #region Fields

        protected readonly ScreenType _screenType;

        protected AbstractScreen(ScreenType _screenType)
        {
            this._screenType = _screenType;
        }

        [SerializeField]
        GameObject _screen;

        ScreenFactory _screenFactory = new ScreenFactory();

        #endregion

        #region MonoBehaviour

        void Awake()
        {
            _screenFactory.register(this, _screenType);
        }

        void OnDestroy()
        {
            _screenFactory.unregister(_screenType);
        }

        #endregion

        public void enableScreen(bool enable)
        {
            _screen.SetActive(enable);
        }

    }
}
