using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList;

namespace DS.MSClient.UICommon
{
	/// <summary>
	/// 自定义节点
	/// </summary>
	public class CustomNode
	{
		private int _id;
		private string _type;
		private string _name;
		private int _array;
		private object _obj;
		private CustomNodes _owner;
		private readonly CustomNodes _customNodes;

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="type">类型</param>
		/// <param name="name">名称</param>
		/// <param name="array">排序</param>
		/// <param name="obj">对象</param>
		public CustomNode(int id, string type, string name, int array = 0, object obj = null)
		{
			_customNodes = new CustomNodes { ParentNode = this };
			_id = id;
			_type = type;
			_name = name;
			_array = array;
			_obj = obj;
		}

		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="customNodes">子节点集</param>
		/// <param name="id">ID</param>
		/// <param name="type">类型</param>
		/// <param name="name">名称</param>
		/// <param name="array">排序</param>
		/// <param name="obj">对象</param>
		public CustomNode(CustomNodes customNodes, int id, string type, string name, int array = 0, object obj = null)
		{
			_customNodes = customNodes;
			_customNodes.ParentNode = this;
			_id = id;
			_type = type;
			_name = name;
			_array = array;
			_obj = obj;
		}

		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			get { return _id; }
			set
			{
				if (_id == value) return;
				_id = value;
				OnChanged();
			}
		}

		/// <summary>
		/// 类型
		/// </summary>
		public string Type
		{
			get { return _type; }
			set
			{
				if (_type == value) return;
				_type = value;
				OnChanged();
			}
		}

		/// <summary>
		/// 名称
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if (_name == value) return;
				_name = value;
				OnChanged();
			}
		}

		/// <summary>
		/// 排序
		/// </summary>
		public int Array
		{
			get { return _array; }
			set
			{
				if (_array == value) return;
				_array = value;
				OnChanged();
			}
		}

		/// <summary>
		/// 对象
		/// </summary>
		public object Obj
		{
			get { return _obj; }
			set
			{
				if (_obj == value) return;
				_obj = value;
				OnChanged();
			}
		}

		/// <summary>
		/// 所属节点集
		/// </summary>
		public CustomNodes Owner
		{
			get { return _owner; }
			set { _owner = value; }
		}

		/// <summary>
		/// 子节点集
		/// </summary>
		public CustomNodes CustomNodes
		{
			get { return _customNodes; }
		}

		private void OnChanged()
		{
			if (_owner == null) return;
			var index = _owner.IndexOf(this);
			_owner.ResetItem(index);
		}
	}

	/// <summary>
	/// 自定义节点集
	/// </summary>
	public class CustomNodes : BindingList<CustomNode>, TreeList.IVirtualTreeListData
	{
		/// <summary>
		/// 父节点
		/// </summary>
		public CustomNode ParentNode { get; set; }

		public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
		{
			var obj = info.Node as CustomNode;
			if (obj != null) info.Children = obj.CustomNodes;
		}

		protected override void InsertItem(int index, CustomNode item)
		{
			item.Owner = this;
			base.InsertItem(index, item);
		}

		public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
		{
			var obj = info.Node as CustomNode;
			if (obj == null) return;
			switch (info.Column.FieldName)
			{
				case "Name":
					info.CellData = obj.Name;
					break;
			}
		}

		public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
		{
			var obj = info.Node as CustomNode;
			if (obj == null) return;
			switch (info.Column.FieldName)
			{
				case "Name":
					obj.Name = (string)info.NewCellData;
					break;
			}
		}
	}
}
