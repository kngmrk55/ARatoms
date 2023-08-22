namespace Scripts.Screens
{
    using Scripts.Game;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ScreenEndgame : AbstractScreen
    {
        #region Constructor

        public ScreenEndgame():base(ScreenType.SCREEN_ENDGAME) { }

        #endregion

        #region Fields

        [SerializeField]
        TMP_Text _textEndgame = null;

        [SerializeField]
        TMP_Text _textTime = null;

        [SerializeField]
        Button _buttonReset = null;

        [SerializeField]
        Button _buttonMenu = null;

        #endregion

        #region Monobehaviour

        void Start ()
        {
            _buttonReset.onClick.AddListener(GameManager.Instance.startGame);
            _buttonMenu.onClick.AddListener(GameManager.Instance.goMainMenu);
        }

        #endregion

        #region Feedback

        public void showResults(bool win, string time)
        {
            if(win)
            {
                _textEndgame.color = Color.white;
                _textEndgame.text = "Ganaste :D";
            }
            else
            {
                _textEndgame.color = Color.red;
                _textEndgame.text = "Perdiste :/";
            }

            _textTime.text = "Tiempo: " + time;
            
        }

        #endregion
    }
}
