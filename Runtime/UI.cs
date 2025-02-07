using UnityEngine;
#if UNITY_EDITOR && ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Freyja.UI
{
    public abstract class UI : MonoBehaviour
    {
        #region Constants

        protected const string UIGrp = "UI";
        protected const string ConfigGrp = "Config";
        protected const string RuntimeGrp = "Runtime";

        #endregion

        #region Fields

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(ConfigGrp)]
        #endif
        [SerializeField]
        protected bool m_HideOnStart = true;

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(UIGrp)]
        [Required]
        #endif
        [SerializeField]
        protected RectTransform m_Content;

        #endregion

        #region Properties

        public bool UIIsVisible
        {
            get => m_Content.gameObject.activeSelf;
        }

        #endregion

        #region Methods

        protected virtual void Start()
        {
            if (m_HideOnStart)
            {
                Hide();
            }
        }

        public virtual void Show()
        {
            m_Content.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            m_Content.gameObject.SetActive(false);
        }

        protected virtual void OnPerformShow()
        {
            if (UIIsVisible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        #endregion
    }
}