using UnityEngine.UI;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("計數管理")]
    public static int GoldnumInt = 0;
    [Header("金環判定")]
    public bool goldCheck = false;

    [Header("金幣X/Z位置")]
    [SerializeField] private float goldPositionX, goldPositionZ; // 金幣的X/Z位置

    [Header("獲取地板的放大縮小值")]
    public GameObject floor; // 地板的大小
    [SerializeField] private float floorscaleX, floorscaleZ;

    private void Start()
    {
        floor = GameObject.Find("地板");
    }

    private void Update()
    {
        GetTransform();
       // print("地板X值:" + floorscaleX + "地板Z值:" + floorscaleZ);
        goldPositionX = goldPositionX * floorscaleX;
        goldPositionZ = goldPositionZ * floorscaleZ;
       //print(goldPositionX + "分隔" + goldPositionZ);
       // print("金幣X位置" + goldPositionX + "金幣位置" + goldPositionZ);
    }


    /// <summary>
    /// 獲取金幣位置值與地板縮放值
    /// </summary>
    private void GetTransform()
    {
        goldPositionX = gameObject.GetComponent<Transform>().position.x;  //金幣X位置值 
        goldPositionZ = gameObject.GetComponent<Transform>().position.z;  //金幣Z位置值 
        floorscaleX = floor.transform.localScale.x;  //地板X大小值
        floorscaleZ = floor.transform.localScale.z;  //地板Z大小值
    }


    /// <summary>
    /// 觸碰到金環時會增加技數器
    /// </summary>
    private void OnTriggerStay(Collider onboard)
    {
        if (onboard.name == "區域判定" & goldCheck == false & goldPositionX < floorscaleX & goldPositionZ < floorscaleZ)
        {
            GoldnumInt = GoldnumInt + 1;
            print(GoldnumInt);
            goldCheck = true;
        }
    }

    private void OnTriggerExit(Collider exitboard)
    {
        if (exitboard.name == "區域判定" & goldCheck == true )
        {
            goldCheck = false;
            GoldnumInt = GoldnumInt - 1;
            print(GoldnumInt);
            Destroy(gameObject, 3f);
        }


    }

}
