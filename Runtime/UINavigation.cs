using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR && ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Freyja.UI
{
    public abstract class UINavigation : MonoBehaviour
    {
        #region Constants

        protected const string UIGrp = "UI";
        protected const string SelectableGrp = "Selectable";

        #endregion

        #region Fields

    #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(SelectableGrp, order: 10)]
    #endif
        [SerializeField]
        protected List<Selectable> m_Selectables = new List<Selectable>();

        #endregion

        #region Methods

        protected virtual void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            UpdateNavigation();
        }

        public abstract void UpdateNavigation();

        public void AddSelectable(Selectable selectable)
        {
            if (!m_Selectables.Contains(selectable))
            {
                m_Selectables.Add(selectable);
            }
        }

        public void RemoveSelectable(Selectable selectable)
        {
            m_Selectables.Remove(selectable);
        }

        #endregion
    }
}