using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private AntController _ant;

    [SerializeField]
    private Text _counter;
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private Button _retryButton;
    [SerializeField]
    private Image _loadingImage;
    [SerializeField]
    private Toggle _matrixToggle;
    [SerializeField]
    private Toggle _fullScreenToggle;
    [SerializeField]
    private GameObject _pauseInfo;

    private bool _isPause = true;

    private void Start()
    {
        _matrixToggle.isOn = Factory.GenerateRandomMatrix;
        _fullScreenToggle.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        _counter.text = _ant.Counter.ToString();
        _playButton.interactable = _isPause && !_gameController.IsLoading;
        _pauseButton.interactable = !_isPause;


        if (_gameController.IsLoading)
        {
            _loadingImage.gameObject.SetActive(true);
            _loadingImage.transform.Rotate(Vector3.forward*5);
        }
        else
        {
            _loadingImage.gameObject.SetActive(false);
        }
    }

    public void Play()
    {
        _ant.CanMove = true;
        _isPause = false;

        _pauseInfo.SetActive(false);
    }

    public void Pause()
    {
        _ant.CanMove = false;
        _isPause = true;

        _pauseInfo.SetActive(true);
    }

    public void Retry()
    {
        _pauseInfo.SetActive(false);
        _isPause = true;
        _ant.CanMove = false;
        _gameController.IsLoading = true;

        StartCoroutine(_gameController.InitMatrix());
        _isPause = true;
    }

    public void OnChangeToggleMatrix(bool value)
    {
        Factory.GenerateRandomMatrix = value;
    }

    public void OnChangeToggleFullScreen(bool value)
    {
        Screen.fullScreen = value;
    }
}
