namespace Scripts.Game
{
    using UnityEngine;
    using Scripts.Screens;
    using Scripts.Controllers;
    using System.Diagnostics;

    public class GameManager : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        int _initialScore = 10;

        [Header("Controllers")]
        [SerializeField]
        CarController _carController = null;

        [Header("Cameras")]
        [SerializeField]
        Camera _mainCamera = null;

        [SerializeField]
        Camera _UICamera = null;

        [Header("AudioSources")]
        [SerializeField]
        AudioSource _audioAppleGrab = null;

        [SerializeField]
        AudioSource _engineSound = null;

        #endregion

        #region Properties

        string _playerName = string.Empty;

        bool _isPlaying = false;

        public static GameManager Instance { get; private set; }

        //Screens
        ScreenGame _screenGame = null;

        ScreenMenu _screenMenu = null;

        ScreenEndgame _screenEndgame = null;

        Stopwatch _stopwatch = new Stopwatch();

        public string playerName { set => _playerName = value;  get => _playerName; }
        public bool isPlaying { get => _isPlaying;  }

        //Actions
        public System.Action _onGameStart = null;

        public System.Action _onGameStop = null;

        #endregion

        private void Awake()
        {
            if (Instance != null && Instance != this) //Create singleton
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            ScreenFactory screenFactory = new ScreenFactory();
            _screenGame = (ScreenGame)screenFactory.getScreen(ScreenType.SCREEN_GAME);
            _screenMenu = (ScreenMenu)screenFactory.getScreen(ScreenType.SCREEN_MENU);
            _screenEndgame = (ScreenEndgame)screenFactory.getScreen(ScreenType.SCREEN_ENDGAME);

            _screenMenu.showNameInputField();
            _screenMenu.enableScreen(true);
            _screenGame.enableScreen(false);
            _screenEndgame.enableScreen(false);
        }

        private void Update()
        {
            if(_isPlaying)
            {
                System.TimeSpan timeSpan = _stopwatch.Elapsed;
                _screenGame.setTime(timeSpan.ToString(@"mm\:ss"));
            }

            if(_isPlaying && _initialScore>=25)
            {
                stopGame(true);
            }

            if(_isPlaying && _initialScore <= 0) 
            {
                stopGame(false);
            }
            
        }

        public void addScore(int offset)
        {
            _initialScore += offset;
            _screenGame.setScore(_initialScore);
        }

        public void goMainMenu() //Show main menu and reset car
        {
            _carController.resetCar();
            _UICamera.gameObject.SetActive(true);
            _mainCamera.gameObject.SetActive(false);
            _screenEndgame.enableScreen(false);
            _screenMenu.enableScreen(true);
        }

        public void startGame()
        {
            _engineSound.Play();
            _carController.resetCar();
            _stopwatch.Start();
            _isPlaying = true;

            _screenGame.enableScreen(true);
            _screenMenu.enableScreen(false);
            _screenEndgame.enableScreen(false);

            _screenGame.setScore(_initialScore);

            _UICamera.gameObject.SetActive(false);
            _mainCamera.gameObject.SetActive(true);
            _onGameStart?.Invoke();
        }

        public void stopGame(bool win)
        {
            _engineSound.Stop();
            _stopwatch.Stop();
            _isPlaying = false;
            System.TimeSpan timeSpan = _stopwatch.Elapsed;
            _initialScore = 10;
            _screenGame.enableScreen(false);
            _screenEndgame.enableScreen(true);
            _screenEndgame.showResults(win, timeSpan.ToString(@"mm\:ss"));
            _stopwatch.Reset(); 
            _onGameStop?.Invoke();
        }

        public void playSoundAppleGrab() //Play sound on apple grab
        {
            _audioAppleGrab.Play();
        }

        public void increaseEngineSoundPitch(float pitchSpeed)
        {
            float maxPitch = 2f;
            float minPitch = 1f;

            if((_engineSound.pitch + pitchSpeed) < minPitch)
            {
                _engineSound.pitch = minPitch;
                return;
            }

            if((_engineSound.pitch + pitchSpeed) > maxPitch)
            {
                _engineSound.pitch = maxPitch;
                return;
            }

            _engineSound.pitch += pitchSpeed;
        }
    }
}
