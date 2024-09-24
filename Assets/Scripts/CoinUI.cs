using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TMPro.TMP_Text coinText;
    private int coinsCollected = 0;

    public void CoinCollected()
    {
        coinsCollected++;
        coinText.text = coinsCollected.ToString();
    }
}
