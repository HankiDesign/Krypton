﻿// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2012. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 17/267 Nepean Hwy, 
//  Seaford, Vic 3198, Australia and are supplied subject to licence terms.
// 
//  Version 4.4.0.0 	www.ComponentFactory.com
// *****************************************************************************

using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon
{
    /// <summary>
    /// Specialise the generic collection with type specific rules for tab item accessor.
    /// </summary>
    public class KryptonRibbonTabCollection : TypedCollection<KryptonRibbonTab>
    {
        #region Public
        /// <summary>
        /// Gets the item with the provided unique name.
        /// </summary>
        /// <param name="name">Name of the ribbon tab instance.</param>
        /// <returns>Item at specified index.</returns>
        public override KryptonRibbonTab this[string name]
        {
            get
            {
                // Search for a tab with the same text as that requested.
                foreach(KryptonRibbonTab tab in this)
                    if (tab.Text == name)
                        return tab;

                // Let base class perform standard processing
                return base[name];
            }
        }
        #endregion
    }
}
