using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Calculator.UI
{
    public class ScrollViewSizeFitter : UIBehaviour, ILayoutSelfController
    {
        [SerializeField] private float maxHeight;
        [SerializeField] private RectTransform contentRect;
        
        private RectTransform _rect;
        
        private RectTransform Rect
        {
            get
            {
                if (_rect == null)
                    _rect = GetComponent<RectTransform>();
                return _rect;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetDirty();
        }

        protected override void OnDisable()
        {
            LayoutRebuilder.MarkLayoutForRebuild(Rect);
            base.OnDisable();
        }

        protected override void OnRectTransformDimensionsChange()
        {
            SetDirty();
        }

        public void SetLayoutHorizontal()
        {
        }

        public void SetLayoutVertical()
        {
            if (!contentRect)
            {
                return;
            }

            var height = Mathf.Min(maxHeight, contentRect.rect.height);
            Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        private void SetDirty()
        {
            if (!IsActive())
                return;

            LayoutRebuilder.MarkLayoutForRebuild(Rect);
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            SetDirty();
        }
#endif
    }
}
