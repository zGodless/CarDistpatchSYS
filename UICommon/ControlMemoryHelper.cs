using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DS.Common;
using DS.Model;
using QuickFrame.Common.Configuration;
using QuickFrame.Common.Converter;

namespace DS.MSClient
{
    //窗体记忆赋值
    public static class ControlMemoryHelper
    {
        public static void SaveControl(string FilePath, LayoutControl _layout)
        {
            MemberControl _control = Program._MemberControlList.Find(m => m.MemberControlType == FilePath);
            if (_control == null)
            {
                _control= new MemberControl();
                 Program._MemberControlList.Add(_control);
            }
            _control.MemberControlType = FilePath;
            _control._ItmeItems = new List<MemberControlItem>();
            foreach (Control c in _layout.Controls)
            {
                if (c is BaseEdit)
                {
                    BaseEdit be = c as BaseEdit;
                    if (c is DateEdit)
                    {
                        if(ValueConvert.ToDateTime(be.EditValue).ToString("yyyy-MM-dd")!="0001-01-01")
                        {
                            MemberControlItem model = new MemberControlItem();
                            model.ControlName = be.Name;
                            model.ControlValue = ValueConvert.ToDateTime(be.EditValue).ToString("yyyy-MM-dd");
                            _control._ItmeItems.Add(model);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ValueConvert.ToString(be.EditValue)) && ValueConvert.ToString(be.EditValue) != "0")
                        {
                            MemberControlItem model = new MemberControlItem();
                            model.ControlName = be.Name;
                            model.ControlValue = ValueConvert.ToString(be.EditValue);
                            _control._ItmeItems.Add(model);
                        }
                        else if (ValueConvert.ToString(be.Name).Contains("MakeUpNumber"))
                        {
                            MemberControlItem model = new MemberControlItem();
                            model.ControlName = be.Name;
                            model.ControlValue = ValueConvert.ToString(be.EditValue);
                            _control._ItmeItems.Add(model);
                        }
                    }
                }
            }
        }
        public static void Delete(string FilePath)
        {
            MemberControl _control = Program._MemberControlList.Find(m => m.MemberControlType == FilePath);
            if (_control != null)
            {
                Program._MemberControlList.Remove(_control);
            }
        }
        public static void ReadControl(string FilePath, LayoutControl _layout)
        {
            MemberControl _control = Program._MemberControlList.Find(m => m.MemberControlType == FilePath);
            if (_control != null)
            {
                foreach (Control c in _layout.Controls)
                {
                    if (c is BaseEdit)
                    {
                        BaseEdit be = c as BaseEdit;
                        MemberControlItem _item = _control._ItmeItems.Find(m=>m.ControlName == be.Name);
                        if (_item != null)
                        {
                            if (c is DateEdit)
                            {
                                if (ValueConvert.ToString(_item.ControlValue) == "0001-01-01")
                                {
                                    be.EditValue = null;
                                }
                                else
                                {
                                    be.EditValue = _item.ControlValue;
                                }
                            }
                            else
                            {
                                if (ValueConvert.ToString(_item.ControlValue) == "")
                                {
                                    be.EditValue = null;
                                }
                                else
                                {
                                    Regex rg=new Regex("^[0-9]+$");
                                    if (rg.IsMatch(_item.ControlValue))
                                    {
                                        be.EditValue = ValueConvert.ToInt32(_item.ControlValue);
                                    }
                                    else
                                    {
                                        be.EditValue = ValueConvert.ToString(_item.ControlValue);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
