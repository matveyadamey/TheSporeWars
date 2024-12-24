using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSaver : MonoBehaviour
{
    void Awake()
    {
        if (SavingData.isAudioExistStatic == 0)
        {
            SavingData.isAudioExistStatic = 1;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
