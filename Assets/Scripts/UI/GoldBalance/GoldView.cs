using UnityEngine;
using UnityEngine.UI;

namespace UI.GoldBalance
{
    public class GoldView : MonoBehaviour
    {
        private Text _textContainer;
        private int _goldCount;

        private const string _header="Gold:";
        private void Awake()
        {
            _goldCount = 10;
            _textContainer = gameObject.GetComponent<Text>();
            Init(_goldCount);
        }
        public void Init(int goldCount)
        {
           // _header = header;
            _goldCount += goldCount;
            _textContainer.text = _header + _goldCount;
        }
    }
}