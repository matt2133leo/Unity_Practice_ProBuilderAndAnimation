using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [Header("預置物")]
    public GameObject Goldencircle;

    [Header("音源")]
    public AudioSource GoldAud;

    [Header("音效")]
    public AudioClip GodAC;

    [Header("計數器")]

    public Text GoldNum;

    private void Start()
    {
        GoldNum = GameObject.Find("金幣數量").GetComponent<Text>();
    }

    private void Update()
    {
        GoldNum.text = Coin.GoldnumInt.ToString();
    }

    /// <summary>
    /// 生成金幣
    /// </summary>
    public void bornGold()
    {
        Instantiate(Goldencircle);
        GoldSound();
        
    }

    /// <summary>
    /// 播放聲音
    /// </summary>
    private void GoldSound()
    {
        GoldAud.PlayOneShot(GodAC);
    }

    /// <summary>
    /// GoldCount增加/減少
    /// </summary>

}
