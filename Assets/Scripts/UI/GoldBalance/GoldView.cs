using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GoldBalance
{
    public class GoldView : MonoBehaviour
    {
        private Text _textContainer;
        private SubscriptionProperty<int> _goldCountProp;

        private string _header;
        private ushort _goldCount;
        private void Awake()
        {
            _textContainer = gameObject.GetComponent<Text>();
        }
        public void Init(string header, SubscriptionProperty<int> goldCount)
        {
            _header = header;
            _goldCountProp = goldCount;
            _goldCountProp.SubscribeOnChange(OnGoldChange);
            _textContainer.text = _header + goldCount.Value;
        }
        private void OnGoldChange(int count)
        {
            _textContainer.text = _header + count;
        }
        private void OnDestroy()
        {
            _goldCountProp.UnSubscriptionOnChange(OnGoldChange);
        }
    }
}