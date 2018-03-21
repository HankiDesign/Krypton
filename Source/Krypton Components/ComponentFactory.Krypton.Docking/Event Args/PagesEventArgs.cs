// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2012. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 17/267 Nepean Hwy, 
//  Seaford, Vic 3198, Australia and are supplied subject to licence terms.
// 
//  Version 4.4.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System;
using ComponentFactory.Krypton.Navigator;

namespace ComponentFactory.Krypton.Docking
{
	/// <summary>
    /// Event arguments for events that need to provide a colletion of pages.
	/// </summary>
	public class PagesEventArgs : EventArgs
	{
		#region Instance Fields
        private readonly KryptonPageCollection _pages;
		#endregion

		#region Identity
		/// <summary>
        /// Initialize a new instance of the PagesEventArgs class.
		/// </summary>
        /// <param name="pages">Collection of pages.</param>
        public PagesEventArgs(KryptonPageCollection pages)
		{
            _pages = pages;
		}
        #endregion

		#region Public
        /// <summary>
        /// Gets access to a collection of pages.
        /// </summary>
        public KryptonPageCollection Pages
        {
            get { return _pages; }
        }
        #endregion
	}
}
