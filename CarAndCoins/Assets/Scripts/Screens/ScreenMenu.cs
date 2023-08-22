namespace Scripts.Screens
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Scripts.Game;

    public class ScreenMenu : AbstractScreen
    {
        #region Constructors

        public ScreenMenu() : base(ScreenType.SCREEN_MENU) { }

        #endregion

        #region Fields

        [SerializeField]
        TMP_Text _textName = null;

        [SerializeField]
        TMP_InputField _inputName = null;

        [SerializeField]
        Button _buttonSubmit = null;

        [SerializeField]
        Button _buttonStartGame = null;

        [SerializeField]
        Button _buttonChangeName = null;

        [SerializeField]
        Button _buttonExit = null;

        #endregion

        #region MonoBehaviour

        void Start()
        {
            _buttonStartGame.onClick.AddListener(GameManager.Instance.startGame);
            _buttonChangeName.onClick.AddListener(showNameInputField);
            _buttonSubmit.onClick.AddListener(submitName);
            _buttonExit.onClick.AddListener(Application.Quit);
        }

        #endregion


        #region Utils

        public void showNameInputField() //Show inputfield and hide play and change name button
        {
            _inputName.text = string.Empty;
            _textName.gameObject.SetActive(false);
            _buttonStartGame.gameObject.SetActive(false);
            _buttonChangeName.gameObject.SetActive(false);

            _buttonSubmit.gameObject.SetActive(true);
            _inputName.gameObject.SetActive(true);
        }

        public void submitName() //Click on submit and save
        {
            GameManager.Instance.name = _inputName.text;

            _textName.gameObject.SetActive(true);
            _buttonStartGame.gameObject.SetActive(true);
            _buttonChangeName.gameObject.SetActive(true);

            _buttonSubmit.gameObject.SetActive(false);
            _inputName.gameObject.SetActive(false);
            _textName.text = "Bienvenido: " + GameManager.Instance.name;
        }

        #endregion
    }
}
