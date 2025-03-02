﻿using UnityEngine;
using UnityEngine.UI;

namespace Freyja.UI
{
    [AddComponentMenu("Freyja/UI/Navigations/UI Navigation Vertical")]
    public class UINavigationVertical : UINavigation
    {
        #region Methods

        public override void UpdateNavigation()
        {
            for (var i = 0; i < m_Selectables.Count; i++)
            {
                var navigation = m_Selectables[i].navigation;

                navigation.mode = Navigation.Mode.Explicit;

                navigation.selectOnUp = i > 0 ? m_Selectables[i - 1] : null;
                navigation.selectOnDown = i < m_Selectables.Count - 1 ? m_Selectables[i + 1] : null;

                m_Selectables[i].navigation = navigation;
            }
        }

        #endregion
    }
}