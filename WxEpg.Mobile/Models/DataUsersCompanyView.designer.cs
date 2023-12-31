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

namespace WxEpg.Mobile.Models
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
	public partial class DataUsersCompanyViewDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    #endregion
		
		public DataUsersCompanyViewDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["epgConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataUsersCompanyViewDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataUsersCompanyViewDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataUsersCompanyViewDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataUsersCompanyViewDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<UsersCompanyView> UsersCompanyView
		{
			get
			{
				return this.GetTable<UsersCompanyView>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UsersCompanyView")]
	public partial class UsersCompanyView
	{
		
		private string _userid;
		
		private string _wxid;
		
		private string _head;
		
		private string _username;
		
		private System.Nullable<int> _companyid;
		
		private string _name;
		
		private string _province;
		
		private string _city;
		
		private System.DateTime _createtime;
		
		private System.DateTime _lasttime;
		
		private System.Nullable<int> _subscribe;
		
		private string _UserProvince;
		
		private string _UserCity;
		
		private string _phone;
		
		private int _id;
		
		public UsersCompanyView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userid", DbType="VarChar(50)")]
		public string userid
		{
			get
			{
				return this._userid;
			}
			set
			{
				if ((this._userid != value))
				{
					this._userid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wxid", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string wxid
		{
			get
			{
				return this._wxid;
			}
			set
			{
				if ((this._wxid != value))
				{
					this._wxid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_head", DbType="VarChar(50)")]
		public string head
		{
			get
			{
				return this._head;
			}
			set
			{
				if ((this._head != value))
				{
					this._head = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(50)")]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this._username = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_companyid", DbType="Int")]
		public System.Nullable<int> companyid
		{
			get
			{
				return this._companyid;
			}
			set
			{
				if ((this._companyid != value))
				{
					this._companyid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
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
					this._name = value;
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
					this._province = value;
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
					this._city = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createtime", DbType="DateTime NOT NULL")]
		public System.DateTime createtime
		{
			get
			{
				return this._createtime;
			}
			set
			{
				if ((this._createtime != value))
				{
					this._createtime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lasttime", DbType="DateTime NOT NULL")]
		public System.DateTime lasttime
		{
			get
			{
				return this._lasttime;
			}
			set
			{
				if ((this._lasttime != value))
				{
					this._lasttime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_subscribe", DbType="Int")]
		public System.Nullable<int> subscribe
		{
			get
			{
				return this._subscribe;
			}
			set
			{
				if ((this._subscribe != value))
				{
					this._subscribe = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserProvince", DbType="VarChar(50)")]
		public string UserProvince
		{
			get
			{
				return this._UserProvince;
			}
			set
			{
				if ((this._UserProvince != value))
				{
					this._UserProvince = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserCity", DbType="VarChar(50)")]
		public string UserCity
		{
			get
			{
				return this._UserCity;
			}
			set
			{
				if ((this._UserCity != value))
				{
					this._UserCity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(11)")]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this._phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL")]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
