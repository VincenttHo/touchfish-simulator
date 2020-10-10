using UnityEngine;
using System.Collections;
//转载请说明出处

public class PreFrameRaycast : MonoBehaviour
{
    private RaycastHit hitInfo;
    private Transform tr;

    void Awake()
    {
        tr = this.transform;
    }

    void Update()
    {
        hitInfo = new RaycastHit();
        Physics.Raycast(tr.position, tr.forward, out hitInfo);
        Debug.DrawRay(tr.position, tr.forward, Color.red);
    }
    //返回射线的碰撞信息
    public RaycastHit GetHitInfo()
    {
        if (hitInfo.Equals(null))
        {
            Debug.LogWarning("hitInfo is null");
        }
        return hitInfo;
    }
}