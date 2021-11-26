using UnityEngine;
using UnityEngine.UI;

namespace Example
{
    public class EnemyUI : MonoBehaviour
    {
        public HPBar HPBar { get; private set; }
        public RectTransform RectTransform { get; private set;}

        private Slider _slider;
        private Text _name;

        private void Awake()
        {
            _slider = this.GetComponentInChildren<Slider>();
            _name = this.GetComponentInChildren<Text>();
            RectTransform = this.GetComponent<RectTransform>();

            HPBar = new HPBar(_slider, 100f);
        }
    }
}
