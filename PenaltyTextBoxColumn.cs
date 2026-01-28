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
    class PenaltyTextBoxColumn : DataGridViewColumn
    {
        public PenaltyTextBoxColumn()
            : base(new PenaltyTextBoxCell())
        {

        }
       
    }

    class PenaltyTextBoxCell : DataGridViewComboBoxCell
    {

        public PenaltyTextBoxCell()
            : base()
        {
            string [] pole = { "0", "5", "50"};
            this.DataSource = pole;
            this.AutoComplete = false;
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
            DataGridViewComboBoxEditingControl tb;
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            tb = DataGridView.EditingControl as DataGridViewComboBoxEditingControl;
            
            //tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }


        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '1' || e.KeyChar == '4' || e.KeyChar == '7')
                e.KeyChar = '0';
            else if (e.KeyChar == '2' || e.KeyChar == '5' || e.KeyChar == '8')
                e.KeyChar = '5';
            else if (e.KeyChar == '3' || e.KeyChar == '6' || e.KeyChar == '9')
            {
                e.KeyChar = '3';           
                //this.Value = "50";
                //e.Handled = true;
            }
            

        }

       
    }

}
