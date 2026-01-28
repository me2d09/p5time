//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn
{
    class NumericTextBoxColumn : DataGridViewColumn
    {
        public NumericTextBoxColumn()
            : base(new NumericTextBoxCell())
        {

        }
       
    }

    class NumericTextBoxCell : DataGridViewTextBoxCell
    {

        public NumericTextBoxCell()
            : base()
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs e, int rowIndex)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            base.OnKeyPress(e, rowIndex);
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            DataGridViewTextBoxEditingControl tb;
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            tb = DataGridView.EditingControl as DataGridViewTextBoxEditingControl;

            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
        }

       
    }

}
