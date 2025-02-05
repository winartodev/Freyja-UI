using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR && ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Freyja.UI
{
    [AddComponentMenu("Freyja/UI/Navigations/UI Navigation Grid")]
    public class UINavigationGrid : UINavigation
    {
        #region Fields

    #if ODIN_INSPECTOR
        [TitleGroup(UIGrp)]
        [Required]
    #endif
        [SerializeField]
        private GridLayoutGroup m_GridLayoutGroup;

    #if ODIN_INSPECTOR
        [TitleGroup(UIGrp)]
    #endif
        [SerializeField]
        private RectTransform m_Content;

        #endregion

        #region Properties

        private bool IsFixedColumnCount
        {
            get => m_GridLayoutGroup.constraint == GridLayoutGroup.Constraint.FixedColumnCount;
        }

        private bool IsFixedRowCount
        {
            get => m_GridLayoutGroup.constraint == GridLayoutGroup.Constraint.FixedRowCount;
        }

        #endregion

        #region Methods

        public override void UpdateNavigation()
        {
            var constraintCount = (int)(m_Content.sizeDelta.x / (m_GridLayoutGroup.cellSize.x + m_GridLayoutGroup.spacing.x / 2));

            if (IsFixedRowCount && m_GridLayoutGroup.constraintCount >= m_Selectables.Count)
            {
                Logger.Show.LogError(this, $"Constraint count ({m_GridLayoutGroup.constraintCount}) cannot be greater than or equal to the number of selectables ({m_Selectables.Count}).");
                return;
            }

            for (var i = 0; i < m_Selectables.Count; i++)
            {
                var navigation = m_Selectables[i].navigation;
                navigation.mode = Navigation.Mode.Explicit;

                navigation.selectOnRight = HandleSelectOnRight(constraintCount, i);
                navigation.selectOnLeft = HandleSelectOnLeft(constraintCount, i);

                navigation.selectOnUp = HandleSelectOnUp(constraintCount, i);
                navigation.selectOnDown = HandleSelectOnDown(constraintCount, i);
                m_Selectables[i].navigation = navigation;
            }
        }

        private Selectable HandleSelectOnRight(int constraintCount, int index)
        {
            return constraintCount > 1 && index < m_Selectables.Count - 1 ? m_Selectables[index + 1] : null;
        }

        private Selectable HandleSelectOnLeft(int constraintCount, int index)
        {
            return constraintCount > 1 && index > 0 ? m_Selectables[index - 1] : null;
        }

        private Selectable HandleSelectOnUp(int constraintCount, int index)
        {
            if (IsFixedColumnCount && constraintCount <= 1)
            {
                return index > 0 ? m_Selectables[index - 1] : null;
            }

            return m_Selectables.Count > constraintCount && index - constraintCount >= 0 ? m_Selectables[index - constraintCount] : null;
        }

        private Selectable HandleSelectOnDown(int constraintCount, int index)
        {
            if (IsFixedColumnCount && constraintCount <= 1)
            {
                return index < m_Selectables.Count - 1 ? m_Selectables[index + 1] : null;
            }

            return m_Selectables.Count > constraintCount && index + constraintCount < m_Selectables.Count ? m_Selectables[index + constraintCount] : null;
        }

        #endregion
    }
}