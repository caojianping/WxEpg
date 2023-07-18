﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WxEpg.DataPush.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="epg")]
	public partial class CompanyDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertnetworkcompany(networkcompany instance);
    partial void Updatenetworkcompany(networkcompany instance);
    partial void Deletenetworkcompany(networkcompany instance);
    partial void Insertuserchannel(userchannel instance);
    partial void Updateuserchannel(userchannel instance);
    partial void Deleteuserchannel(userchannel instance);
    #endregion
		
		public CompanyDataContext() : 
				base(global::WxEpg.DataPush.Properties.Settings.Default.epgConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CompanyDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CompanyDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CompanyDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CompanyDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<networkcompany> networkcompany
		{
			get
			{
				return this.GetTable<networkcompany>();
			}
		}
		
		public System.Data.Linq.Table<userchannel> userchannel
		{
			get
			{
				return this.GetTable<userchannel>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.networkcompany")]
	public partial class networkcompany : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private string _rank;
		
		private string _province;
		
		private string _city;
		
		private System.Nullable<System.DateTime> _createtime;
		
		private System.Nullable<System.DateTime> _updatetime;
		
		private System.Nullable<bool> _IsUpload;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnrankChanging(string value);
    partial void OnrankChanged();
    partial void OnprovinceChanging(string value);
    partial void OnprovinceChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OncreatetimeChanging(System.Nullable<System.DateTime> value);
    partial void OncreatetimeChanged();
    partial void OnupdatetimeChanging(System.Nullable<System.DateTime> value);
    partial void OnupdatetimeChanged();
    partial void OnIsUploadChanging(System.Nullable<bool> value);
    partial void OnIsUploadChanged();
    #endregion
		
		public networkcompany()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rank", DbType="VarChar(50)")]
		public string rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				if ((this._rank != value))
				{
					this.OnrankChanging(value);
					this.SendPropertyChanging();
					this._rank = value;
					this.SendPropertyChanged("rank");
					this.OnrankChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_province", DbType="VarChar(50)")]
		public string province
		{
			get
			{
				return this._province;
			}
			set
			{
				if ((this._province != value))
				{
					this.OnprovinceChanging(value);
					this.SendPropertyChanging();
					this._province = value;
					this.SendPropertyChanged("province");
					this.OnprovinceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="VarChar(50)")]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this.OncityChanging(value);
					this.SendPropertyChanging();
					this._city = value;
					this.SendPropertyChanged("city");
					this.OncityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createtime", DbType="DateTime")]
		public System.Nullable<System.DateTime> createtime
		{
			get
			{
				return this._createtime;
			}
			set
			{
				if ((this._createtime != value))
				{
					this.OncreatetimeChanging(value);
					this.SendPropertyChanging();
					this._createtime = value;
					this.SendPropertyChanged("createtime");
					this.OncreatetimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updatetime", DbType="DateTime")]
		public System.Nullable<System.DateTime> updatetime
		{
			get
			{
				return this._updatetime;
			}
			set
			{
				if ((this._updatetime != value))
				{
					this.OnupdatetimeChanging(value);
					this.SendPropertyChanging();
					this._updatetime = value;
					this.SendPropertyChanged("updatetime");
					this.OnupdatetimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsUpload", DbType="Bit")]
		public System.Nullable<bool> IsUpload
		{
			get
			{
				return this._IsUpload;
			}
			set
			{
				if ((this._IsUpload != value))
				{
					this.OnIsUploadChanging(value);
					this.SendPropertyChanging();
					this._IsUpload = value;
					this.SendPropertyChanged("IsUpload");
					this.OnIsUploadChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.userchannel")]
	public partial class userchannel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _companyId;
		
		private string _name;
		
		private System.Nullable<int> _relChannelId;
		
		private string _relChannelName;
		
		private string _stationNumber;
		
		private System.Nullable<System.DateTime> _createtime;
		
		private System.Nullable<System.DateTime> _updatetime;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OncompanyIdChanging(int value);
    partial void OncompanyIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnrelChannelIdChanging(System.Nullable<int> value);
    partial void OnrelChannelIdChanged();
    partial void OnrelChannelNameChanging(string value);
    partial void OnrelChannelNameChanged();
    partial void OnstationNumberChanging(string value);
    partial void OnstationNumberChanged();
    partial void OncreatetimeChanging(System.Nullable<System.DateTime> value);
    partial void OncreatetimeChanged();
    partial void OnupdatetimeChanging(System.Nullable<System.DateTime> value);
    partial void OnupdatetimeChanged();
    #endregion
		
		public userchannel()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_companyId", DbType="Int NOT NULL")]
		public int companyId
		{
			get
			{
				return this._companyId;
			}
			set
			{
				if ((this._companyId != value))
				{
					this.OncompanyIdChanging(value);
					this.SendPropertyChanging();
					this._companyId = value;
					this.SendPropertyChanged("companyId");
					this.OncompanyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_relChannelId", DbType="Int")]
		public System.Nullable<int> relChannelId
		{
			get
			{
				return this._relChannelId;
			}
			set
			{
				if ((this._relChannelId != value))
				{
					this.OnrelChannelIdChanging(value);
					this.SendPropertyChanging();
					this._relChannelId = value;
					this.SendPropertyChanged("relChannelId");
					this.OnrelChannelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_relChannelName", DbType="VarChar(50)")]
		public string relChannelName
		{
			get
			{
				return this._relChannelName;
			}
			set
			{
				if ((this._relChannelName != value))
				{
					this.OnrelChannelNameChanging(value);
					this.SendPropertyChanging();
					this._relChannelName = value;
					this.SendPropertyChanged("relChannelName");
					this.OnrelChannelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stationNumber", DbType="VarChar(50)")]
		public string stationNumber
		{
			get
			{
				return this._stationNumber;
			}
			set
			{
				if ((this._stationNumber != value))
				{
					this.OnstationNumberChanging(value);
					this.SendPropertyChanging();
					this._stationNumber = value;
					this.SendPropertyChanged("stationNumber");
					this.OnstationNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createtime", DbType="DateTime")]
		public System.Nullable<System.DateTime> createtime
		{
			get
			{
				return this._createtime;
			}
			set
			{
				if ((this._createtime != value))
				{
					this.OncreatetimeChanging(value);
					this.SendPropertyChanging();
					this._createtime = value;
					this.SendPropertyChanged("createtime");
					this.OncreatetimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updatetime", DbType="DateTime")]
		public System.Nullable<System.DateTime> updatetime
		{
			get
			{
				return this._updatetime;
			}
			set
			{
				if ((this._updatetime != value))
				{
					this.OnupdatetimeChanging(value);
					this.SendPropertyChanging();
					this._updatetime = value;
					this.SendPropertyChanged("updatetime");
					this.OnupdatetimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591