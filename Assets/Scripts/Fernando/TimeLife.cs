using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLife : MonoBehaviour
{
    [SerializeField] private float timelife;
    private void Start()
    {
        Destroy(gameObject, timelife);
    }
}
