using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI_Enums;

public abstract class BaseUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject parent;

    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void BindDatas();
    protected void Bind<T>(Type type, GameObject go) where T : UnityEngine.Object // UI 정보 바인딩
    {
        String[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);
        //Debug.Log(_objects.Count);

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Substring(names[i].Length - 1) == "_")
            {
                if (typeof(T) == typeof(GameObject))
                    objects[i] = Util.FindChild(go, names[i] + 1, true);
                else
                    objects[i] = Util.FindChild<T>(go, names[i] + 1, true);

            }
            else
            {
                if (typeof(T) == typeof(GameObject))
                    objects[i] = Util.FindChild(go, names[i], true);
                else
                    objects[i] = Util.FindChild<T>(go, names[i], true);
            }


            if (objects[i] == null)
                Debug.Log($"Failed to bind({names[i]})");
        }
    }
    protected T Get<T>(int idx) where T : UnityEngine.Object // UI 가져오는 부분
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            //Debug.Log();
            return null;
        }
            

        return objects[idx] as T;
    }
}