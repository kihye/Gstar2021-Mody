using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    //멤버 변수
    [SerializeField]
    protected int _money;
    protected int _atk;
    protected int _def;

    //멤버 프로퍼티
    public int Money { get { return _money; } set { _money = value; } }
    public int ATK { get { return _atk; } set { _atk = value; } }
    public int DEF { get { return _def; } set { _def = value; } }

    // Start is called before the first frame update
    private void Start()
    {
        _money = 1000000000;
        _atk = 10;
        _def = 10;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
