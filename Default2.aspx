<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="lt6.StudentWebApp_Par._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="p-2">
        <div class="container">
            <div class="row">
                <!--FIRST ONEE-->
                <center>
                    <h2 id="gettingStartedTitle">USER LIST </h2>
                </center>

                <div class="row">


                    <div class="column col-md-5">
                        <!--elements for input-->
                        <div class="row">
                            <label class="col-form-label">Name    </label>
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name"></asp:TextBox>
                        </div>
                        <div class="row">
                            <label class="col-form-label">Email    </label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Add User"
                            OnClick="btnSubmit_Click" />
                    </div>


                    <div class="column col-md-7 p-2">
                        <!--table itself-->
                        <center>
                            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ID"
                                CssClass="table table-bordered table-hover text-white"
                                OnRowEditing="gvUsers_RowEditing"
                                OnRowUpdating="gvUsers_RowUpdating"
                                OnRowCancelingEdit="gvUsers_RowCancelingEdit"
                                OnRowDeleting="gvUsers_RowDeleting">

                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="UserName" HeaderText="Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button" HeaderText="Actions" />
                                </Columns>
                            </asp:GridView>

                        </center>
                    </div>
                </div>
            </div>
