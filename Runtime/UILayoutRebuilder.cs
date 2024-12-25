using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR && ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Freyja.UI
{
    [AddComponentMenu("Freyja/UI/UI Layout Rebuilder")]
    public class UILayoutRebuilder : MonoBehaviour
    {
        #region Constants

        private const string ConfigGrp = "Config";
        private const string RequiredGrp = "Required";

        #endregion

        #region Fields

    #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(ConfigGrp)]
    #endif
        [SerializeField]
        private bool m_RebuildOnStart;

    #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(RequiredGrp)]
    #endif
        [SerializeField]
        private RectTransform m_Layout;

        #endregion

        #region Methods

        private void Start()
        {
            if (m_RebuildOnStart)
            {
                RebuildLayout(m_Layout);
            }
        }

        public void RebuildLayout(RectTransform layout)
        {
            if (layout == null)
            {
                return;
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
        }

        #endregion
    }
}