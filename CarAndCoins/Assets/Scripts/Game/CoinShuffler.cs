namespace Scripts.Game
{
    using UnityEngine;

    public class CoinShuffler : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        Material _goodCoin = null;

        [SerializeField]
        Material _badCoin = null;

        [SerializeField]
        MeshRenderer _coinMesh = null;

        [Range(0, 100)]
        [SerializeField]
        int spawnGoodCoinProbability = 75;

        #endregion

        #region Properties

        int _coinValue = 0;

        #endregion

        #region MonoBehaviour
        void Start()
        {
            transform.position = Vector3.zero;
            GameManager.Instance._onGameStart += setApple;
            GameManager.Instance._onGameStop += ()=> transform.position = Vector3.zero;
        }

        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }

        private void OnTriggerEnter(Collider other)
        {
            GameManager.Instance.addScore(_coinValue);
            GameManager.Instance.playSoundAppleGrab();
            setApple();
        }

        #endregion

        #region Apple Ramdom Position

        void setApple()
        {
            int ramdomizer = Random.Range(0, 100);

            _coinMesh.material = ramdomizer >= spawnGoodCoinProbability ? _badCoin : _goodCoin; //Probability to spawn red apple vs dark apple
            _coinValue = ramdomizer >= spawnGoodCoinProbability ? -2 : 5;

            randomizeOutSpawn(40, 101); //Spawn apple out car spawn
        }

        void randomizeOutSpawn(int minimum, int maximum)
        {
            float X1 = 72;
            float Z1 = 72;
            float X2 = 75;
            float Z2 = 67;

            float randomX;
            float randomZ;
            do
            {
                randomX = Random.Range(minimum, maximum);
                randomZ = Random.Range(minimum, maximum);
            } while ((randomX >= X1 && randomX <= X2) && (randomZ >= Z2 && randomZ <= Z1));

            transform.position = new Vector3(randomX, 0.3f, randomZ);
        }

        #endregion
    }
}
