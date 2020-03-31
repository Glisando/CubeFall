using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class BGScroll : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.3f;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = _meshRenderer.sharedMaterial.mainTextureOffset;

        offset.y += Time.deltaTime * _scrollSpeed;
        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }

}