<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Header.Master" AutoEventWireup="true" CodeBehind="GestionDepartement.aspx.cs" Inherits="WebApplicationGestionProjects.Departement.GestionDepartement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:3%">
        <h1  class="text-center">Edite Departement</h1>
        <div>
            <table cellpadding="1" class="w-100">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewDepartement" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewDescription_SelectedIndexChanged" DataKeyNames="departementID">
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="RBSearch" runat="server">
                            <asp:ListItem Text="Description" Value="Description" />
                            <asp:ListItem Text="Ville" Value="Ville" />
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
                        <asp:Label ID="Label3" runat="server" Text="Description: "></asp:Label>
                        
                    </td>
                    <td><asp:TextBox ID="TBDescription" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Ville: "></asp:Label>
                        
                    </td>
                    <td><asp:TextBox ID="TBVille" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td> 
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
