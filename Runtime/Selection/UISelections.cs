using System.Collections.Generic;

using UnityEngine;
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
        private List<UISelection> m_UISelections;

        #endregion

        #region Privates

        private int _selectedIndex;
        private readonly Dictionary<string, UISelection> _selectionsDict = new Dictionary<string, UISelection>();

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

        public UISelection GetLatestSelection()
        {
            if (m_AlwaysGetFirstIndex)
            {
                return m_UISelections[0];
            }

            return m_UISelections[_selectedIndex];
        }

        private void RegisterUISelections()
        {
            if (m_UISelections == null || m_UISelections.Count <= 0)
            {
                return;
            }

            for (var i = 0; i < m_UISelections.Count; i++)
            {
                var uiSelection = m_UISelections[i];
                _selectionsDict.Add(uiSelection.name, uiSelection);
            }
        }

        private void UnRegisterUISelections()
        {
            if (m_UISelections == null || m_UISelections.Count <= 0)
            {
                return;
            }

            _selectionsDict.Clear();
        }

        public void GetUISelection(string selectedName)
        {
            if (m_UISelections == null || m_UISelections.Count <= 0)
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
                    _selectedIndex = currentIndex;
                    break;
                }

                currentIndex++;
            }
        }

        #endregion
    }
}