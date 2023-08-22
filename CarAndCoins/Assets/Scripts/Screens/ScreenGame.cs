namespace Scripts.Screens
{
    using TMPro;
    using UnityEngine;

    public class ScreenGame : AbstractScreen
    {
        #region Constructor

        public ScreenGame() : base(ScreenType.SCREEN_GAME) { }

        #endregion

        #region Fields

        [SerializeField]
        TMP_Text _textScore = null;

        [SerializeField]
        TMP_Text _textTime = null;

        #endregion

        #region UI Update

        public void setScore(int score)
        {
            _textScore.text = "Puntuación: " + score;
        }

        public void setTime(string time)
        {
            _textTime.text = "Tiempo: " + time;
        }

        #endregion
    }
}

