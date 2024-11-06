using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animation Anim;
    private void Awake()
    {
        Anim.Play("Rotate");
    }

}
