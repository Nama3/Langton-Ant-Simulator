using UnityEngine;
using UnityEngine.UI;

public class SquarePrefab : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitColor()
    {
        if (((int)Random.Range(0, 2)) == 1 && Factory.GenerateRandomMatrix)
        {
            _image.color = Color.black;
        }
        else
        {
            _image.color = Color.white;
        }
    }

    public Color GetColor()
    {
        return _image.color;
    }

    public void ChangeColor()
    {
        if (_image.color == Color.black)
        {
            _image.color = Color.white;
        }
        else if (_image.color == Color.white)
        {
            _image.color = Color.black;
        }
    }
}
