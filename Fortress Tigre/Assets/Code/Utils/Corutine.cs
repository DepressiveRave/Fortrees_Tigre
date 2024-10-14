using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Corutine : MonoBehaviour
{
    private static Corutine instance
    {
        get
        {
            if (m_instance == null)
            {
                var go = new GameObject(name: "[COROUTINE MANAGER]");
                m_instance = go.AddComponent<Corutine>();
                DontDestroyOnLoad(go);
            }

            return m_instance;
        }
    }

    private static Corutine m_instance;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
        {
            instance.StopCoroutine(routine);
        }
    }
}
