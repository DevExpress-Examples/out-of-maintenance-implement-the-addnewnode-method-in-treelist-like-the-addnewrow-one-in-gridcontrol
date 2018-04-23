using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            myTreeList1.DataSource = CreateDataSource();
            gridControl1.DataSource = CreateDataSource();
            gridView1.AddNewRow();
          
            myTreeList1.ExpandAll();
        }

        void myTreeList1_InitNewNode(object sender, InitNewNodeEventArgs a) {
            myTreeList1.GetNodeByVisibleIndex(a.NodeId).SetValue(0, "test");
        }

        void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e) {
            
        }

        private DataTable CreateDataSource() {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Order Date", typeof(DateTime));
            dataTable.Columns.Add("OrderCost", typeof(double));
            dataTable.Rows.Add(new object[] { "John Smith", " 01 / 01 / 2010", 102 });
            dataTable.Rows.Add(new object[] { "Ivanov", "01/01/2011", 2000 });
            dataTable.Rows.Add(new object[] { "Petrov", "01 / 05 / 2011", 345 });
            dataTable.Rows.Add(new object[] { "John Smith", " 04 / 01 / 2010", 102.78 });
            dataTable.Rows.Add(new object[] { "Ivanov", "01/11/2011", 450.78 });
            return dataTable;

        }


        private void Form1_Load(object sender, EventArgs e) {
            myTreeList1.AddNewNode();
        }
    }
}