using System;

using UnityEngine.EventSystems;

namespace Freyja.UI
{
    public abstract class UISelection : UI, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler, IDeselectHandler
    {
        public event Action OnSelectPerformed;
        public event Action OnDeselectPerformed;

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            eventData.selectedObject = gameObject;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            eventData.selectedObject = gameObject;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
        }

        public virtual void OnSelect(BaseEventData eventData)
        {
            OnSelectPerformed?.Invoke();
        }

        public virtual void OnDeselect(BaseEventData eventData)
        {
            OnDeselectPerformed?.Invoke();
        }

        public virtual void OnSubmit(BaseEventData eventData)
        {
        }
    }
}