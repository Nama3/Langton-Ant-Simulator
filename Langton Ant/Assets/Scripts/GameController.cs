using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _squarePrefab;

    [SerializeField]
    private AntController _ant;

    private GameObject _square;

    public bool IsLoading { get; set; }

    private void Start()
    {
        StartCoroutine(InitMatrix());
    }

    public IEnumerator InitMatrix()
    {
        IsLoading = true;
        Factory.GetSquareList().Clear();
        for (int y = 0; y < 90; y++)
        {
            yield return null;
            for (int x = 0; x < 160; x++)
            {
                _square = Instantiate(_squarePrefab, new Vector3(_squarePrefab.transform.position.x + (x * 10), _squarePrefab.transform.position.y - (y * 10)), Quaternion.identity);
                _square.transform.SetParent(transform);
                _square.gameObject.SetActive(true);
                _square.GetComponent<SquarePrefab>().InitColor();
                if ((y == 45) && (x == 80))
                {
                    _ant.InitAnt(_square);
                }
                Factory.GetSquareList().Add(_square);
            }
        }
        IsLoading = false;
    }
}
