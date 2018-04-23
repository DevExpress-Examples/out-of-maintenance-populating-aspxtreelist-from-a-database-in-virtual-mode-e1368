Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace VirtualModeDemo
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ASPxTreeList1_VirtualModeNodeCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListVirtualNodeEventArgs)
		End Sub

		Protected Sub ASPxTreeList1_VirtualModeNodeCreating(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListVirtualModeNodeCreatingEventArgs)
			Dim rowView As DataRowView = TryCast(e.NodeObject, DataRowView)
			If rowView Is Nothing Then
				Return
			End If
			e.NodeKeyValue = rowView("EmployeeID")

			e.SetNodeValue("LastName", rowView("LastName"))
			e.SetNodeValue("FirstName", rowView("FirstName"))
			e.SetNodeValue("Title", rowView("Title"))
			e.SetNodeValue("TitleOfCourtesy", rowView("TitleOfCourtesy"))
			e.SetNodeValue("ReportsTo", rowView("ReportsTo"))
		End Sub

		Protected Sub ASPxTreeList1_VirtualModeCreateChildren(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListVirtualModeCreateChildrenEventArgs)
			Dim children As DataView = Nothing
			Dim parent As DataRowView = TryCast(e.NodeObject, DataRowView)
			If parent Is Nothing Then
				children = CType(SqlDataSource2.Select(DataSourceSelectArguments.Empty), DataView)
			Else
				SqlDataSource1.SelectParameters("Param").DefaultValue = parent("EmployeeID").ToString()
				children = CType(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
			End If
			e.Children = children
		End Sub
	End Class
End Namespace
