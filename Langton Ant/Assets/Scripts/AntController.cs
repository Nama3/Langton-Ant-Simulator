using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AntController : MonoBehaviour
{
    public bool CanMove { get; set; }

    private GameObject _currentSquare;

    public int Counter { get; private set; }

    public bool IsInit { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if ((CanMove || Input.GetKey(KeyCode.Space)) && IsInit)
        {
            Move();
        }
    }

    public void InitAnt(GameObject firstSquare)
    {
        Counter = 0;
        _currentSquare = firstSquare;
        transform.position = firstSquare.transform.position;
        transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<Image>().enabled = true;
        IsInit = true;
    }

    public void Move()
    {
        if (_currentSquare.GetComponent<SquarePrefab>().GetColor() == Color.black)
        {
            transform.Rotate(Vector3.forward * 90);
        }
        else if (_currentSquare.GetComponent<SquarePrefab>().GetColor() == Color.white)
        {
            transform.Rotate(Vector3.back * 90);
        }
        transform.Translate(Vector3.up * 10);
        _currentSquare.GetComponent<SquarePrefab>().ChangeColor();
        try
        {
            _currentSquare = Factory.GetSquareList().First(x => x.transform.position == transform.position);
        }
        catch
        {
            CanMove = false;
        }
        Counter++;
    }
}
