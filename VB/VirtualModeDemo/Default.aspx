<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VirtualModeDemo._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [ReportsTo]  FROM [Employees]&#13;&#10;WHERE [ReportsTo] = @Param">
			<SelectParameters>
				<asp:Parameter Name="Param" DBType="Int32"/>
			</SelectParameters>
		</asp:SqlDataSource>
		<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [ReportsTo]  FROM [Employees]&#13;&#10;WHERE [ReportsTo] is null">
		</asp:SqlDataSource>

	</div>
		<dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" AutoGenerateColumns="False"
			KeyFieldName="EmployeeID" OnVirtualModeCreateChildren="ASPxTreeList1_VirtualModeCreateChildren"
			OnVirtualModeNodeCreated="ASPxTreeList1_VirtualModeNodeCreated" OnVirtualModeNodeCreating="ASPxTreeList1_VirtualModeNodeCreating">
			<Columns>
				<dxwtl:TreeListTextColumn FieldName="LastName" VisibleIndex="0">
				</dxwtl:TreeListTextColumn>
				<dxwtl:TreeListTextColumn FieldName="FirstName" VisibleIndex="1">
				</dxwtl:TreeListTextColumn>
				<dxwtl:TreeListTextColumn FieldName="Title" VisibleIndex="2">
				</dxwtl:TreeListTextColumn>
				<dxwtl:TreeListTextColumn FieldName="TitleOfCourtesy" VisibleIndex="3">
				</dxwtl:TreeListTextColumn>
			</Columns>
		</dxwtl:ASPxTreeList>
	</form>
</body>
</html>
