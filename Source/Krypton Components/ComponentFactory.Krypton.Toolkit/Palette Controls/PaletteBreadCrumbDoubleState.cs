﻿// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2012. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 17/267 Nepean Hwy, 
//  Seaford, Vic 3198, Australia and are supplied subject to licence terms.
// 
//  Version 4.4.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit
{
	/// <summary>
	/// Implement storage for bread crumb appearance states.
	/// </summary>
    public class PaletteBreadCrumbDoubleState : PaletteDouble
    {
        #region Instance Fields
        private readonly PaletteTriple _paletteCrumb;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteBreadCrumbDoubleState class.
		/// </summary>
        /// <param name="redirect">Inheritence redirection instance.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public PaletteBreadCrumbDoubleState(PaletteBreadCrumbRedirect redirect,
                                            NeedPaintHandler needPaint) 
            : base(redirect, needPaint)
		{
            _paletteCrumb = new PaletteTriple(redirect.BreadCrumb, needPaint);
        }
        #endregion

		#region IsDefault
		/// <summary>
		/// Gets a value indicating if all values are default.
		/// </summary>
		[Browsable(false)]
		public override bool IsDefault
		{
            get
            {
                return (base.IsDefault && _paletteCrumb.IsDefault);
            }
		}
		#endregion

        #region BreadCrumb
        /// <summary>
        /// Gets access to the bread crumb appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining bread crumb appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple BreadCrumb
        {
            get { return _paletteCrumb; }
        }

        private bool ShouldSerializeBreadCrumb()
        {
            return !_paletteCrumb.IsDefault;
        }
        #endregion
    }
}
