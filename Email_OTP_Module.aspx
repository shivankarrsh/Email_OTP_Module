<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Email_OTP_Module.aspx.vb" Inherits="Email_OTP_Module._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <table class="TableBkg1" width="800">

    <tr>

        <td valign="middle" class="Header2" width="100%" bgcolor="#DCDCDC" style="height: 15px" colspan="2">

         Email Verification

        </td>

    </tr>

   <tr>

                <td class="TextLevel2" style="width: 65px" > EmailId:</td>

                 

                <td class="TextLevel2">

                    <asp:TextBox ID="txtemail" runat="server" Width="204px"></asp:TextBox>

                   

                </td>

            </tr>

            <tr>

                <td class="TextLevel2" style="width: 65px" >

                <asp:Label ID ="lblOTP" runat="server" Text ="OTP" Visible=false/>

                 </td>

                 

                <td class="TextLevel2">

             

                    <asp:TextBox ID="txtOTP" runat="server" Visible ="false" Width="204px"></asp:TextBox>

                  <%--  <asp:Label ID ="lblDisplay" runat="server" visible =false/>--%>

                </td>

            </tr>

            <tr>

            <td bgcolor="white" colspan="2" style="height: 26px" align="right">

            <asp:Label ID ="lblErr" runat="server" /> &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;

             &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;

             <asp:Button ID="btn_confirmOtp" runat="server" Text ="ConfirmOTP" Visible =false />

                <asp:Button ID="btn_Search" runat="server" Text="Search" />

              

               

              

            </td>

        </tr>




    </table>
    <asp:Timer ID="Timer1" runat="server">
    </asp:Timer>
</asp:Content>
