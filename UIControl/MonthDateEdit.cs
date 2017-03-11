using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace DS.MSClient
{
    [ToolboxItem(true)]
    public partial class MonthDateEdit : DateEdit
    {
        static MonthDateEdit() { RepositoryItemMonthsDateEdit.RegisterMonthsDateEdit(); }

        public MonthDateEdit()
            : base()
        {
            Properties.Mask.EditMask = "y";
        }

        protected override PopupBaseForm CreatePopupForm()
        {
            if (Properties.VistaDisplayMode == DevExpress.Utils.DefaultBoolean.True || Properties.VistaDisplayMode == DevExpress.Utils.DefaultBoolean.Default)
                return new MyVistaPopupDateEditForm(this);
            return base.CreatePopupForm();
        }

        public override string EditorTypeName
        { get { return RepositoryItemMonthsDateEdit.MonthsDateEditName; } }
    }
    //The attribute that points to the registration method 
    [UserRepositoryItem("RegisterMonthDateEdit")]
    public class RepositoryItemMonthsDateEdit : RepositoryItemDateEdit
    {
        static RepositoryItemMonthsDateEdit() { RegisterMonthsDateEdit(); }
        public const string MonthsDateEditName = "MonthDateEdit";
        public override string EditorTypeName { get { return MonthsDateEditName; } }
        public static void RegisterMonthsDateEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MonthsDateEditName,
                typeof(MonthDateEdit), typeof(RepositoryItemMonthsDateEdit), typeof(DateEditViewInfo), new ButtonEditPainter(), true));
        }
    }

    public class MyVistaPopupDateEditForm : VistaPopupDateEditForm
    {
        public MyVistaPopupDateEditForm(DateEdit ownerEdit) : base(ownerEdit) { }
        protected override DateEditCalendar CreateCalendar()
        { return new MyVistaDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue); }
    }

    public class MyVistaDateEditCalendar : VistaDateEditCalendar
    {
        public MyVistaDateEditCalendar(RepositoryItemDateEdit item, object editDate) : base(item, editDate) { }

        protected override void Init()
        {
            base.Init();
            this.View = DateEditCalendarViewType.YearInfo;
        }

        protected override void OnItemClick(DevExpress.XtraEditors.Calendar.CalendarHitInfo hitInfo)
        {
            DayNumberCellInfo cell = hitInfo.HitObject as DayNumberCellInfo;
            if (View == DateEditCalendarViewType.YearInfo)
            {
                DateTime dt = new DateTime(DateTime.Year, cell.Date.Month, 1);
                OnDateTimeCommit(dt, false);
            }
            else
                base.OnItemClick(hitInfo);
        }
    }
}
