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
	public partial class DataVideoExtendViewDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    #endregion
		
		public DataVideoExtendViewDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["epgConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataVideoExtendViewDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataVideoExtendViewDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataVideoExtendViewDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataVideoExtendViewDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<VideoExtendView> VideoExtendView
		{
			get
			{
				return this.GetTable<VideoExtendView>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VideoExtendView")]
	public partial class VideoExtendView
	{
		
		private int _videoId;
		
		private string _name;
		
		private string _mainType;
		
		private int _visitCount;
		
		private int _loveCount;
		
		private int _discussCount;
		
		private decimal _grade;
		
		private System.DateTime _updateTime;
		
		private System.Nullable<int> _gradeCount;
		
		public VideoExtendView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_videoId", DbType="Int NOT NULL")]
		public int videoId
		{
			get
			{
				return this._videoId;
			}
			set
			{
				if ((this._videoId != value))
				{
					this._videoId = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mainType", DbType="VarChar(50)")]
		public string mainType
		{
			get
			{
				return this._mainType;
			}
			set
			{
				if ((this._mainType != value))
				{
					this._mainType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_visitCount", DbType="Int NOT NULL")]
		public int visitCount
		{
			get
			{
				return this._visitCount;
			}
			set
			{
				if ((this._visitCount != value))
				{
					this._visitCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loveCount", DbType="Int NOT NULL")]
		public int loveCount
		{
			get
			{
				return this._loveCount;
			}
			set
			{
				if ((this._loveCount != value))
				{
					this._loveCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_discussCount", DbType="Int NOT NULL")]
		public int discussCount
		{
			get
			{
				return this._discussCount;
			}
			set
			{
				if ((this._discussCount != value))
				{
					this._discussCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_grade", DbType="Decimal(18,2) NOT NULL")]
		public decimal grade
		{
			get
			{
				return this._grade;
			}
			set
			{
				if ((this._grade != value))
				{
					this._grade = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updateTime", DbType="DateTime NOT NULL")]
		public System.DateTime updateTime
		{
			get
			{
				return this._updateTime;
			}
			set
			{
				if ((this._updateTime != value))
				{
					this._updateTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gradeCount", DbType="Int")]
		public System.Nullable<int> gradeCount
		{
			get
			{
				return this._gradeCount;
			}
			set
			{
				if ((this._gradeCount != value))
				{
					this._gradeCount = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
