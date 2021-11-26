using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace Example
{
    public class HPBar 
    {
        public Slider Slider { get; private set; }
        public float MaxHP { get; private set; }
        public float MinHP { get; private set; }
        public float HP
        {
            get => Slider.value;
            set
            { 
                Slider.value = value;
            }
        }

        public HPBar(Slider slider, float max) : this(slider, 0f, max)
        {
        }

        public HPBar(Slider slider, float min, float max)
        {
            Slider = slider;
            MinHP = min;
            MaxHP = max;

            slider.minValue = MinHP;
            slider.maxValue = MaxHP;

            HP = MaxHP;
        }
        
        public async void SetDamage(float damage)
        {
            const float delayTime = 0.7f;
            float currentTime = 0f;

            var currentHP = HP;
            var targetHP = HP - damage;

            while (currentTime <= delayTime)
            {
                HP = Mathf.Lerp(currentHP, targetHP, EaseCurve.EaseInOutQuad(currentTime));

                await Task.Delay(20);

                currentTime += 0.02f;
            }
        }
    }
}
