using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private void Awake() => Instance = this;

    private void OnShake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    public static void Shake(float duration, float strength)
    {

        Instance.OnShake(duration, strength);
        
    }
    void FixedUpdate()
    {
        this.transform.position = new Vector3(0, 0, -10);
        this.transform.rotation = Quaternion.Euler(0,0,0);
    }
}