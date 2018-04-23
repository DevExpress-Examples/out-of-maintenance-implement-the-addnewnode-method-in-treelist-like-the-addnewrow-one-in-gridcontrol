Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			myTreeList1.DataSource = CreateDataSource()
			gridControl1.DataSource = CreateDataSource()
			gridView1.AddNewRow()

			myTreeList1.ExpandAll()
		End Sub

		Private Sub myTreeList1_InitNewNode(ByVal sender As Object, ByVal a As InitNewNodeEventArgs) Handles myTreeList1.InitNewNode
			myTreeList1.GetNodeByVisibleIndex(a.NodeId).SetValue(0, "test")
		End Sub

		Private Sub gridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles gridView1.InitNewRow

		End Sub

		Private Function CreateDataSource() As DataTable
			Dim dataTable As New DataTable()
			dataTable.Columns.Add("Name", GetType(String))
			dataTable.Columns.Add("Order Date", GetType(DateTime))
			dataTable.Columns.Add("OrderCost", GetType(Double))
			dataTable.Rows.Add(New Object() { "John Smith", " 01 / 01 / 2010", 102 })
			dataTable.Rows.Add(New Object() { "Ivanov", "01/01/2011", 2000 })
			dataTable.Rows.Add(New Object() { "Petrov", "01 / 05 / 2011", 345 })
			dataTable.Rows.Add(New Object() { "John Smith", " 04 / 01 / 2010", 102.78 })
			dataTable.Rows.Add(New Object() { "Ivanov", "01/11/2011", 450.78 })
			Return dataTable

		End Function


		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			myTreeList1.AddNewNode()
		End Sub
	End Class
End Namespace