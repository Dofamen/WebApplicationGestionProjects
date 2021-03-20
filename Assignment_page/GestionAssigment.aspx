<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Header.Master" AutoEventWireup="true" CodeBehind="GestionAssigment.aspx.cs" Inherits="WebApplicationGestionProjects.Assignment_page.GestionAssigment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:3%">
        <h1  class="text-center">Assignment</h1>
        <p  class="text-center">&nbsp;</p>
        <div>
            <table cellpadding="1" class="w-100">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewAssigment" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewDescription_SelectedIndexChanged">
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="RBSearch" runat="server">
                            <asp:ListItem Text="Employe Name" Value="Employe" />
                            <asp:ListItem Text="Porject" Value="Project" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID="TBZoneCherche" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="BtCherche" runat="server" Text="Recherche" OnClick="BtCherche_Click" />
                    </td>
                </tr>
             </table>
            <br />
            <br />
            <table class="w-100" cellpadding="10">
                <tr>
                    <td>
                        <asp:Label ID="LbId" runat="server" Text="Id: "></asp:Label>
                        
                    </td>
                    <td><asp:TextBox ID="TBId" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Employe: "></asp:Label>
                        
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListEmploye" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Project: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListProject" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />

            <table style="margin-left:450PX" cellpadding="10" class="auto-style1">
                <tr class="text-center">
                    <td colspan="2">
                        <asp:Button ID="BtAdd" runat="server" Text="Ajouter" Width="150px" OnClick="BtAdd_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="BtUpdate" runat="server" Text="Mise" Width="150px" OnClick="BtUpdate_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="BtDel" runat="server" Text="Supression" Width="150px" OnClick="BtDel_Click" />
                    </td>
                </tr>
            </table>
        </div>
     </div>
</asp:Content>
