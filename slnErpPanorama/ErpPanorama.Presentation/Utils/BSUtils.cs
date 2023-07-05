using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace ErpPanorama.Presentation.Utils
{
    public  class BSUtils
    {
        public static void LoaderLook(LookUpEdit Control, object DataSource, string FieldDisplay, string FieldValue, bool DefaulValue)
        {
            var _with1 = Control;
            _with1.Properties.DataSource = DataSource;
            _with1.Properties.Columns.Clear();
            _with1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(FieldDisplay, 200, "Descripción"));
            _with1.Properties.DisplayMember = FieldDisplay;
            _with1.Properties.ValueMember = FieldValue;
            if (DefaulValue)
                _with1.ItemIndex = 0;
            else
                _with1.EditValue = null;

        }
    }
}
