using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private List<EnemyUI> EnemyUIs;

        [SerializeField]
        private List<Enemy> Characters;

        private void Awake()
        {
            Characters = Glitchers.FindInterfaces.Find<Enemy>();

            EnemyUIs.ForEach(enemyUI => enemyUI.gameObject.SetActive(false));
        }

        private void Update()
        {
            for (int i = 0; i < Characters.Count; i++)
            {
                if (Characters[i].gameObject.activeSelf)
                {
                    EnemyUIs[i].gameObject.SetActive(true);
                    EnemyUIs[i].RectTransform.position = Camera.main.WorldToScreenPoint(Characters[i].UIPosition);
                }
            }
        }
    }
}

