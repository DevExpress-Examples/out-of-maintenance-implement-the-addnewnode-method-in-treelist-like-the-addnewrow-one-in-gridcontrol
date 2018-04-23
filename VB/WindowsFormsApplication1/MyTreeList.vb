Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports System.ComponentModel

Namespace WindowsFormsApplication1
	  <System.ComponentModel.DesignerCategory("")> _
	  Public Class InitNewNodeEventArgs
		  Inherits EventArgs
		Public Sub New(ByVal nodeId As Integer)
			Me.nodeId_Renamed = nodeId
		End Sub
		Private nodeId_Renamed As Integer

		Public ReadOnly Property NodeId() As Integer
			Get
				Return nodeId_Renamed
			End Get
		End Property
	  End Class


	Public Class MyTreeList
		Inherits TreeList
		Public Delegate Sub InitNewRowEventHandler(ByVal sender As Object, ByVal a As InitNewNodeEventArgs)
		Public  Event InitNewNode As InitNewRowEventHandler
		Private _NewAddedNode As TreeListNode

		Public Sub New()
			MyBase.New()

		End Sub

		Public Sub New(ByVal ignore As Object)
			MyBase.New(ignore)
		End Sub



		Public Sub AddNewNode()
			Dim Id As Integer = -1

			_NewAddedNode = Me.AppendNode(Nothing, Id)
			isNewRowDirty = False
			Me.FocusedNode = _NewAddedNode
			RaiseInitNewNode(New InitNewNodeEventArgs(_NewAddedNode.Id))
		End Sub

		Private isNewRowDirty As Boolean = False
		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			Dim info As TreeListHitInfo = Me.CalcHitInfo(e.Location)
			If info.HitInfoType = HitInfoType.Cell Then
					isNewRowDirty = True
					Me.RefreshNode(_NewAddedNode)
			End If
			MyBase.OnMouseDown(e)
		End Sub


		Protected Overrides Sub RaiseCustomDrawNodeIndicator(ByVal e As CustomDrawNodeIndicatorEventArgs)
			If e.Node IsNot _NewAddedNode OrElse isNewRowDirty Then
				MyBase.RaiseCustomDrawNodeIndicator(e)
				Return
			End If

			e.ImageIndex = 1
			e.Painter.DrawObject(e.ObjectArgs)

		End Sub

		Protected Overridable Sub RaiseInitNewNode(ByVal e As InitNewNodeEventArgs)
            RaiseEvent InitNewNode (Me,e)
		End Sub

		Public Function IsNewNode(ByVal nodeId As Integer) As Boolean
			Return nodeId = _NewAddedNode.Id
		End Function


	End Class
End Namespace
