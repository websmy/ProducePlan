<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="WorkForms_Default, App_Web_aekzop44" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:LoginStatus ID="LoginStatus" runat="server" />
    <hr />
    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Administrator">
                <ContentTemplate>
                    This content is displayed to Administrators.
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Manager,Worker">
                <ContentTemplate>
                    This content is displayed to Managers and Workers.
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
