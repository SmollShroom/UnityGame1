using UnityEngine;

public class LiveCounterScript : MonoBehaviour
{

    [SerializeField]
    private float _liveImageWidth = 32f;

    [SerializeField]
    private GameObject player;


    [SerializeField]
    //private int _maxNumOfLives = 5;
    private int _maxNumOfLives ;


    [SerializeField]
    private int _numOfLives = 5;

    private RectTransform _rect;

    //public UnityEvent OutOfLives;



    //public int NumOfLived
    //{
    //    get => _numOfLives;
    //    private set
    //    {
    //        if (value <=0) {
    //           //OutOfLives?.Invoke();
    //        }
    //        _numOfLives = Mathf.Clamp(value, 0, _maxNumOfLives);
    //        AdjustImageWidth();
    //    }
    //}



    private void Awake()
    {
        _rect = transform as RectTransform;

            // Option A: read a component on the same GameObject
            //var stats = player.GetComponent<PlayerController>()._maxPlayerLifePoints;
            //if (stats != null)
            //{
        //float stats = player.GetComponent<PlayerController>()._maxPlayerLifePoints;
        //_maxNumOfLives = Mathf.RoundToInt(stats); // convert float -> int
            //}

        AdjustImageWidth();

    }

    public void _AdjustImageWidth(float stats)
     {
          _rect.sizeDelta = new Vector2(_liveImageWidth * Mathf.RoundToInt(stats), _rect.sizeDelta.y);
     }

    public void AdjustImageWidth()
    {
        _rect.sizeDelta = new Vector2(_liveImageWidth * _numOfLives, _rect.sizeDelta.y);
    }

    //public void AddLife(int num =1)
    //{
    //    NumOfLived += num;
    //}

    //public void RemoveLife(int num =1)
    //{
    //    NumOfLived -= num;
    //}





    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
