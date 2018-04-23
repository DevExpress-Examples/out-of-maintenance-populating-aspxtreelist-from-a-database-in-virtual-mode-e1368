using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace VirtualModeDemo {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxTreeList1_VirtualModeNodeCreated(object sender, DevExpress.Web.ASPxTreeList.TreeListVirtualNodeEventArgs e) {
        }

        protected void ASPxTreeList1_VirtualModeNodeCreating(object sender, DevExpress.Web.ASPxTreeList.TreeListVirtualModeNodeCreatingEventArgs e) {
            DataRowView rowView = e.NodeObject as DataRowView;
            if (rowView == null) return;
            e.NodeKeyValue = rowView["EmployeeID"];

            e.SetNodeValue("LastName", rowView["LastName"]);
            e.SetNodeValue("FirstName", rowView["FirstName"]);
            e.SetNodeValue("Title", rowView["Title"]);
            e.SetNodeValue("TitleOfCourtesy", rowView["TitleOfCourtesy"]);
            e.SetNodeValue("ReportsTo", rowView["ReportsTo"]);
        }

        protected void ASPxTreeList1_VirtualModeCreateChildren(object sender, DevExpress.Web.ASPxTreeList.TreeListVirtualModeCreateChildrenEventArgs e) {
            DataView children = null;
            DataRowView parent = e.NodeObject as DataRowView;
            if (parent == null ) {
                children = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            }
            else {
                SqlDataSource1.SelectParameters["Param"].DefaultValue = parent["EmployeeID"].ToString();
                children = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            }
            e.Children = children;
        }
    }
}
