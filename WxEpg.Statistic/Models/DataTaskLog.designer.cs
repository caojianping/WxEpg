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

namespace WxEpg.Statistic.Models
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
	public partial class DataTaskLogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    #endregion
		
		public DataTaskLogDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["epgConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataTaskLogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataTaskLogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataTaskLogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataTaskLogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TaskLog> TaskLog
		{
			get
			{
				return this.GetTable<TaskLog>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TaskLog")]
	public partial class TaskLog
	{
		
		private int _VideoId;
		
		private int _TaskType;
		
		private System.Nullable<int> _EditId;
		
		private System.Nullable<System.DateTime> _EditTime;
		
		private System.Nullable<int> _AuditId;
		
		private System.Nullable<System.DateTime> _AuditTime;
		
		private System.Nullable<int> _Step;
		
		private string _EditName;
		
		private string _AuditName;
		
		private string _VideoName;
		
		public TaskLog()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VideoId", DbType="Int NOT NULL")]
		public int VideoId
		{
			get
			{
				return this._VideoId;
			}
			set
			{
				if ((this._VideoId != value))
				{
					this._VideoId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskType", DbType="Int NOT NULL")]
		public int TaskType
		{
			get
			{
				return this._TaskType;
			}
			set
			{
				if ((this._TaskType != value))
				{
					this._TaskType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EditId", DbType="Int")]
		public System.Nullable<int> EditId
		{
			get
			{
				return this._EditId;
			}
			set
			{
				if ((this._EditId != value))
				{
					this._EditId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EditTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> EditTime
		{
			get
			{
				return this._EditTime;
			}
			set
			{
				if ((this._EditTime != value))
				{
					this._EditTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuditId", DbType="Int")]
		public System.Nullable<int> AuditId
		{
			get
			{
				return this._AuditId;
			}
			set
			{
				if ((this._AuditId != value))
				{
					this._AuditId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuditTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> AuditTime
		{
			get
			{
				return this._AuditTime;
			}
			set
			{
				if ((this._AuditTime != value))
				{
					this._AuditTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Step", DbType="Int")]
		public System.Nullable<int> Step
		{
			get
			{
				return this._Step;
			}
			set
			{
				if ((this._Step != value))
				{
					this._Step = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EditName", DbType="VarChar(100)")]
		public string EditName
		{
			get
			{
				return this._EditName;
			}
			set
			{
				if ((this._EditName != value))
				{
					this._EditName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuditName", DbType="VarChar(100)")]
		public string AuditName
		{
			get
			{
				return this._AuditName;
			}
			set
			{
				if ((this._AuditName != value))
				{
					this._AuditName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VideoName", DbType="VarChar(50)")]
		public string VideoName
		{
			get
			{
				return this._VideoName;
			}
			set
			{
				if ((this._VideoName != value))
				{
					this._VideoName = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
