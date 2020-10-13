using UnityEngine;
using System.Collections;
public class PointerCtrl : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float pulseSpeed = 1.5f;
    public float noiseSize = 1.0f;
    public float maxWidth = 0.5f;
    public float minWidth = 0.5f;
    //private float aniTime = 0.0f;
    //private float aniDir = 1.0f;
    private LineRenderer lRenderer;
    public GameObject pointer = null;  //小红点
    private PreFrameRaycast raycast;   //光线投射

    void Start()
    {
        lRenderer = gameObject.GetComponent(typeof(LineRenderer)) as LineRenderer;
        raycast = gameObject.GetComponent(typeof(PreFrameRaycast)) as PreFrameRaycast;// Update is called once per frame
    }
    void Update()
    {
        //光线看起来有动感
        //GetComponent<Renderer>().material.mainTextureOffset += new Vector2(Time.deltaTime * aniDir * scrollSpeed, 0);
        //设置纹理偏移量
        //GetComponent<Renderer>().material.SetTextureOffset("_NoiseTex", new Vector2(-Time.time * aniDir * scrollSpeed, 0.0f));

        float aniFactor = Mathf.PingPong(Time.time * pulseSpeed, 1.0f);
        aniFactor = Mathf.Max(minWidth, aniFactor) * maxWidth;
        //设置光线的宽
        //lRenderer.SetWidth(aniFactor, aniFactor);
        lRenderer.startWidth = aniFactor;
        lRenderer.endWidth = aniFactor;
        //光线的起点，枪口的地方
        lRenderer.SetPosition(0, this.gameObject.transform.position);
        if (raycast == null)
        {
            Debug.Log("raycast is null");
            return;
        }
        //获取光线的碰撞信息
        RaycastHit hitInfo = raycast.GetHitInfo();
        //光线碰撞到物体
        if (hitInfo.transform)
        {
            //光线的终点，即光线的碰撞点
            lRenderer.SetPosition(1, hitInfo.point);
            GetComponent<Renderer>().material.mainTextureScale = new Vector2(0.1f * (hitInfo.distance), GetComponent<Renderer>().material.mainTextureScale.y);
            //GetComponent<Renderer>().material.SetTextureScale("_NoiseTex", new Vector2(0.1f * hitInfo.distance * noiseSize, noiseSize));

            if (pointer)
            {
                pointer.GetComponent<Renderer>().enabled = true;
                //pointer.transform.position = hitInfo.point + (transform.position - hitInfo.point) * 0.01f;
                pointer.transform.position = hitInfo.point;
                pointer.transform.rotation = Quaternion.LookRotation(hitInfo.normal, transform.up);
                pointer.transform.eulerAngles = new Vector3(90, pointer.transform.eulerAngles.y, pointer.transform.eulerAngles.z);
            }
        }
        else
        {    //光线没有碰撞到物体
            if (pointer)
            {
                pointer.GetComponent<Renderer>().enabled = false;
            }
            //光线的最大长度
            float maxDist = 200.0f;
            //当光线没有碰撞到物体，终点就是枪口前方最大距离处
            lRenderer.SetPosition(1, (this.transform.forward * maxDist));
            //GetComponent<Renderer>().material.mainTextureScale = new Vector2(0.1f * maxDist, GetComponent<Renderer>().material.mainTextureScale.y);
            //GetComponent<Renderer>().material.SetTextureScale("_NoiseTex", new Vector2(0.1f * maxDist * noiseSize, noiseSize));
        }
    }
}