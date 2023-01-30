using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRolling : MonoBehaviour
{
    public float speed = 1f;

    

    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        speed += Time.deltaTime / (70 + Time.deltaTime*5);

        offset.y += Time.deltaTime * speed;

        mat.mainTextureOffset = offset;

    }
}
