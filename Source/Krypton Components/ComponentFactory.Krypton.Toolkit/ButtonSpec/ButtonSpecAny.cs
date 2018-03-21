﻿// *****************************************************************************
//
//  © Component Factory Pty Ltd 2012. All rights reserved.
//	The software and associated documentation supplied hereunder are the
//  proprietary information of Component Factory Pty Ltd, 17/267 Nepean Hwy,
//  Seaford, Vic 3198, Australia and are supplied subject to licence terms.
//
//  Version 4.4.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System;
using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit
{
	/// <summary>
	/// Button specification that can be assigned as any button type.
	/// </summary>
	public class ButtonSpecAny : ButtonSpec
	{
		#region Instance Fields

		private bool _visible;
		private ButtonEnabled _enabled;
		private ButtonCheckState _checked;
		private ButtonEnabled _wasEnabled;
		private ButtonCheckState _wasChecked;

		#endregion Instance Fields

		#region Identity

		/// <summary>
		/// Initialize a new instance of the AnyButtonSpec class.
		/// </summary>
		public ButtonSpecAny()
		{
			_visible = true;
			_enabled = ButtonEnabled.Container;
			_checked = ButtonCheckState.NotCheckButton;
		}

		/// <summary>
		/// Make a clone of this object.
		/// </summary>
		/// <returns>New instance.</returns>
		public override object Clone()
		{
			var clone = (ButtonSpecAny)base.Clone();
			clone.Visible = Visible;
			clone.Enabled = Enabled;
			clone.Checked = Checked;
			clone.Type = Type;
			return clone;
		}

		#endregion Identity

		#region IsDefault

		/// <summary>
		/// Gets a value indicating if all values are default.
		/// </summary>
		[Browsable(false)]
		public override bool IsDefault => base.IsDefault &&
		                                  Visible &&
		                                  Enabled == ButtonEnabled.Container &&
		                                  Checked == ButtonCheckState.NotCheckButton;

		#endregion IsDefault

		#region Visible

		/// <summary>
		/// Gets and sets if the button should be shown.
		/// </summary>
		[Localizable(true)]
		[Category("Behavior")]
		[Description("Should the button be shown.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(true)]
		public bool Visible
		{
			get => _visible;

			set
			{
				if (_visible == value) return;

				_visible = value;
				OnButtonSpecPropertyChanged(nameof(Visible));
			}
		}

		/// <summary>
		/// Resets the Visible property to its default value.
		/// </summary>
		public void ResetVisible()
		{
			Visible = true;
		}

		#endregion Visible

		#region Enabled

		/// <summary>
		/// Gets and sets the button enabled state.
		/// </summary>
		[Localizable(true)]
		[Category("Behavior")]
		[Description("Defines the button enabled state.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(typeof(ButtonEnabled), "Container")]
		public ButtonEnabled Enabled
		{
			get => _enabled;

			set
			{
				if (_enabled == value) return;

				_enabled = value;
				OnButtonSpecPropertyChanged(nameof(Enabled));
			}
		}

		/// <summary>
		/// Resets the Enabled property to its default value.
		/// </summary>
		public void ResetEnabled()
		{
			Enabled = ButtonEnabled.Container;
		}

		#endregion Enabled

		#region Checked

		/// <summary>
		/// Gets and sets if the button is checked or capable of being checked.
		/// </summary>
		[Localizable(true)]
		[Category("Behavior")]
		[Description("Defines if the button is checked or capable of being checked.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(typeof(ButtonCheckState), "NotCheckButton")]
		public ButtonCheckState Checked
		{
			get => _checked;

			set
			{
				if (_checked == value) return;

				_checked = value;
				OnButtonSpecPropertyChanged(nameof(Checked));
			}
		}

		private bool ShouldSerializeChecked()
		{
			return (Checked != ButtonCheckState.NotCheckButton);
		}

		/// <summary>
		/// Resets the Checked property to its default value.
		/// </summary>
		public void ResetChecked()
		{
			Checked = ButtonCheckState.NotCheckButton;
		}

		#endregion Checked

		#region KryptonCommand

		/// <summary>
		/// Gets and sets the associated KryptonCommand.
		/// </summary>
		[Category("Behavior")]
		[Description("Command associated with the button.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(null)]
		public override KryptonCommand KryptonCommand
		{
			get => base.KryptonCommand;

			set
			{
				if (base.KryptonCommand == value) return;

				if (base.KryptonCommand == null)
				{
					_wasEnabled = Enabled;
					_wasChecked = Checked;
				}

				base.KryptonCommand = value;

				if (base.KryptonCommand != null) return;

				Enabled = _wasEnabled;
				Checked = _wasChecked;
			}
		}

		#endregion KryptonCommand

		#region Type

		/// <summary>
		/// Gets and sets the button type.
		/// </summary>
		[Localizable(true)]
		[Category("Behavior")]
		[Description("Defines the type of button specification.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(typeof(PaletteButtonSpecStyle), "Generic")]
		public PaletteButtonSpecStyle Type
		{
			get => ProtectedType;

			set
			{
				if (ProtectedType == value) return;
				ProtectedType = value;
				OnButtonSpecPropertyChanged(nameof(Type));
			}
		}

		/// <summary>
		/// Resets the Type property to its default value.
		/// </summary>
		public void ResetType()
		{
			Type = PaletteButtonSpecStyle.Generic;
		}

		#endregion Type

		#region CopyFrom

		/// <summary>
		/// Value copy form the provided source to ourself.
		/// </summary>
		/// <param name="source">Source instance.</param>
		public void CopyFrom(ButtonSpecAny source)
		{
			// Copy class specific values
			Visible = source.Visible;
			Enabled = source.Enabled;
			Checked = source.Checked;

			// Let base class copy the base values
			base.CopyFrom(source);
		}

		#endregion CopyFrom

		#region IButtonSpecValues

		/// <summary>
		/// Gets the button visible value.
		/// </summary>
		/// <param name="palette">Palette to use for inheriting values.</param>
		/// <returns>Button visibiliy.</returns>
		public override bool GetVisible(IPalette palette)
		{
			return Visible;
		}

		/// <summary>
		/// Gets the button enabled state.
		/// </summary>
		/// <param name="palette">Palette to use for inheriting values.</param>
		/// <returns>Button enabled state.</returns>
		public override ButtonEnabled GetEnabled(IPalette palette)
		{
			return Enabled;
		}

		/// <summary>
		/// Gets the button checked state.
		/// </summary>
		/// <param name="palette">Palette to use for inheriting values.</param>
		/// <returns>Button checked state.</returns>
		public override ButtonCheckState GetChecked(IPalette palette)
		{
			return Checked;
		}

		#endregion IButtonSpecValues

		#region Protected

		/// <summary>
		/// Raises the ButtonSpecPropertyChanged event.
		/// </summary>
		/// <param name="propertyName">Name of the appearance property that has changed.</param>
		protected override void OnButtonSpecPropertyChanged(string propertyName)
		{
			base.OnButtonSpecPropertyChanged(propertyName);

			switch (propertyName)
			{
				case "KryptonCommand":
					if (KryptonCommand == null) return;

					if (Checked != ButtonCheckState.NotCheckButton)
						Checked = KryptonCommand.Checked ? ButtonCheckState.Checked : ButtonCheckState.Unchecked;

					Enabled = KryptonCommand.Enabled ? ButtonEnabled.True : ButtonEnabled.False;
					break;

				case "Checked":
					if (KryptonCommand != null)
						KryptonCommand.Checked = Checked == ButtonCheckState.Checked;
					break;
			}
		}

		/// <summary>
		/// Handles a change in the property of an attached command.
		/// </summary>
		/// <param name="sender">Source of the event.</param>
		/// <param name="e">A PropertyChangedEventArgs that contains the event data.</param>
		protected override void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnCommandPropertyChanged(sender, e);

			switch (e.PropertyName)
			{
				case "Checked":
					Checked = KryptonCommand.Checked ? ButtonCheckState.Checked : ButtonCheckState.Unchecked;
					break;

				case "Enabled":
					Enabled = KryptonCommand.Enabled ? ButtonEnabled.True : ButtonEnabled.False;
					break;
			}
		}

		/// <summary>
		/// Raises the Click event.
		/// </summary>
		/// <param name="e">An EventArgs containing the event data.</param>
		protected override void OnClick(EventArgs e)
		{
			// Only if associated view is enabled to we perform an action
			if (GetViewEnabled())
			{
				// If a checked style button
				if (Checked != ButtonCheckState.NotCheckButton)
				{
					// Then invert the checked state
					if (Checked == ButtonCheckState.Unchecked)
						Checked = ButtonCheckState.Checked;
					else
						Checked = ButtonCheckState.Unchecked;
				}
			}

			base.OnClick(e);
		}

		#endregion Protected
	}
}