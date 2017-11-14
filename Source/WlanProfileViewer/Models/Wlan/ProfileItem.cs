﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

using WlanProfileViewer.Common;

namespace WlanProfileViewer.Models.Wlan
{
	public class ProfileItem : BindableBase
	{
		/// <summary>
		/// Profile name
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Interface ID
		/// </summary>
		public Guid InterfaceId { get; }

		/// <summary>
		/// Interface name (only for Netsh)
		/// </summary>
		public string InterfaceName { get; }

		/// <summary>
		/// Interface description (wireless LAN adapter name)
		/// </summary>
		public string InterfaceDescription { get; }

		/// <summary>
		/// Authentication method (WPA, WPA2 ...)
		/// </summary>
		public AuthenticationMethod Authentication { get; }

		/// <summary>
		/// Data encryption type (TKIP, CCMP ...)
		/// </summary>
		public EncryptionType Encryption { get; }

		/// <summary>
		/// Profile ID
		/// </summary>
		public string Id => _id ?? (_id = Name + InterfaceId.ToString());
		private string _id;

		/// <summary>
		/// Position in preference order
		/// </summary>
		public int Position
		{
			get { return _position; }
			set
			{
				var floored = Max(value, 0);
				SetPropertyValue(ref _position, floored);
			}
		}
		private int _position;

		/// <summary>
		/// Count of positions in preference order
		/// </summary>
		public int PositionCount
		{
			get { return _positionCount; }
			set { SetPropertyValue(ref _positionCount, value); }
		}
		private int _positionCount;

		/// <summary>
		/// Whether this profile is automatic connection mode
		/// </summary>
		public bool IsAutomatic
		{
			get { return _isAutomatic; }
			set { SetPropertyValue(ref _isAutomatic, value); }
		}
		private bool _isAutomatic;

		/// <summary>
		/// Signal quality (0-100)
		/// </summary>
		public int Signal
		{
			get { return _signal; }
			set
			{
				var clamped = Max(Min(value, 100), 0);
				SetPropertyValue(ref _signal, clamped);
			}
		}
		private int _signal;

		/// <summary>
		/// Whether this profile is connected to a wireless LAN
		/// </summary>
		public bool IsConnected
		{
			get { return _isConnected; }
			set { SetPropertyValue(ref _isConnected, value); }
		}
		private bool _isConnected;

		/// <summary>
		/// Whether this profile is set to be target
		/// </summary>
		public bool IsTarget { get; set; }

		#region Constructor

		public ProfileItem(
			string name,
			Guid interfaceId,
			string interfaceName,
			string interfaceDescription,
			AuthenticationMethod authentication,
			EncryptionType encryption,
			int position,
			bool isAutomatic,
			int signal,
			bool isConnected)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			if (interfaceId == Guid.Empty)
				throw new ArgumentException(nameof(interfaceId));

			this.Name = name;
			this.InterfaceId = interfaceId;
			this.InterfaceName = interfaceName;
			this.InterfaceDescription = interfaceDescription;
			this.Authentication = authentication;
			this.Encryption = encryption;
			this.Position = position;
			this.IsAutomatic = isAutomatic;
			this.Signal = signal;
			this.IsConnected = isConnected;
		}

		#endregion
	}
}