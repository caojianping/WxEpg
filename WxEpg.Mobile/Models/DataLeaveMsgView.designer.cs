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
	public partial class DataLeaveMsgViewDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    #endregion
		
		public DataLeaveMsgViewDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["epgConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataLeaveMsgViewDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataLeaveMsgViewDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataLeaveMsgViewDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataLeaveMsgViewDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<LeaveMsgView> LeaveMsgView
		{
			get
			{
				return this.GetTable<LeaveMsgView>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LeaveMsgView")]
	public partial class LeaveMsgView
	{
		
		private int _Id;
		
		private string _WxId;
		
		private string _Contents;
		
		private bool _Status;
		
		private string _Reply;
		
		private System.DateTime _CreateTime;
		
		private string _UserName;
		
		public LeaveMsgView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
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
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WxId", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string WxId
		{
			get
			{
				return this._WxId;
			}
			set
			{
				if ((this._WxId != value))
				{
					this._WxId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contents", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string Contents
		{
			get
			{
				return this._Contents;
			}
			set
			{
				if ((this._Contents != value))
				{
					this._Contents = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this._Status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reply", DbType="VarChar(500)")]
		public string Reply
		{
			get
			{
				return this._Reply;
			}
			set
			{
				if ((this._Reply != value))
				{
					this._Reply = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateTime", DbType="DateTime NOT NULL")]
		public System.DateTime CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				if ((this._CreateTime != value))
				{
					this._CreateTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
	}
}
#pragma warning restore 1591