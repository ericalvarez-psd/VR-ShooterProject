using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    public static GameCanvasManager Instance;
    public TMP_Text ammoTextLeft, ammoTextRight;

    void Start()
    {
        Instance = this;
    }

    public void SetAmmo(int ammount, Counter side) 
    {
        switch (side)
        {
            case Counter.Left:
                ammoTextLeft.SetText(ammount.ToString());
                break;
            case Counter.Right:
                ammoTextRight.SetText(ammount.ToString());
                break;
        }
        
    }

    public enum Counter
    {
        Left, 
        Right
    }
}
