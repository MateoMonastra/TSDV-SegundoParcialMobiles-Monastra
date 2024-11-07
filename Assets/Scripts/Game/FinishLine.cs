using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private FinishLineColision finishLineColision;
    
    // Start is called before the first frame update
    void Start()
    {
        finishLineColision.OnPlayerColision += PlayerWin;
    }

    private void PlayerWin()
    {
        GameManager.GetInstance().WinGame();
    }
}
