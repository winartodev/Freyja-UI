using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR && ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Freyja.UI
{
    [AddComponentMenu("Freyja/UI/Selections/UI Selections")]
    public class UISelections : MonoBehaviour
    {
        #region Constantas

        private const string ConfigGrp = "Config";
        private const string UIGrp = "UI";

        #endregion

        #region Fields

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(ConfigGrp)]
        #endif
        [SerializeField]
        private bool m_AlwaysGetFirstIndex;

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(UIGrp)]
        #endif
        [Space(8)]
        [SerializeField]
        private List<Selectable> m_Selectables;

        #endregion

        #region Privates

        public int SelectedIndex { get; private set; }
        private readonly Dictionary<string, Selectable> _selectionsDict = new Dictionary<string, Selectable>();

        #endregion

        #region MyRegion

        private void OnEnable()
        {
            RegisterUISelections();
        }

        private void OnDisable()
        {
            UnRegisterUISelections();
        }

        public Selectable GetLatestSelection()
        {
            if (m_AlwaysGetFirstIndex)
            {
                SelectedIndex = 0;
                return m_Selectables[0];
            }

            return m_Selectables[SelectedIndex];
        }

        private void RegisterUISelections()
        {
            if (m_Selectables == null || m_Selectables.Count <= 0)
            {
                return;
            }

            for (var i = 0; i < m_Selectables.Count; i++)
            {
                var uiSelection = m_Selectables[i];
                _selectionsDict.Add(uiSelection.name, uiSelection);
            }
        }

        private void UnRegisterUISelections()
        {
            if (m_Selectables == null || m_Selectables.Count <= 0)
            {
                return;
            }

            _selectionsDict.Clear();
        }

        public Selectable GetSelectable(int index)
        {
            if (m_Selectables == null)
            {
                return null;
            }

            if (index < 0 || index >= m_Selectables.Count)
            {
                return null;
            }

            return m_Selectables[index];
        }

        public void SelectUI(string selectedName)
        {
            if (m_Selectables == null || m_Selectables.Count <= 0)
            {
                return;
            }

            var uiSelection = _selectionsDict.GetValueOrDefault(selectedName);
            if (uiSelection == null)
            {
                return;
            }

            var currentIndex = 0;
            foreach (var key in _selectionsDict.Keys)
            {
                if (key == uiSelection.name)
                {
                    SelectedIndex = currentIndex;
                    break;
                }

                currentIndex++;
            }
        }

        public void GetNextSelection()
        {
            if (SelectedIndex >= m_Selectables.Count - 1)
            {
                SelectedIndex = 0;
            }
            else
            {
                SelectedIndex++;
            }
        }

        public void GetPreviousSelection()
        {
            if (SelectedIndex <= 0)
            {
                SelectedIndex = m_Selectables.Count - 1;
            }
            else
            {
                SelectedIndex--;
            }
        }

        #endregion
    }
}