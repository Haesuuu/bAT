<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lt6.StudentWebApp_Par._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="p-2">
        <div class="container">
            <div class="row">
                <center>
                    <h2 id="gettingStartedTitle">Student DataBase</h2>
                </center>
            </div>

            <div class="row">



                <div class="column col-md-6 p-2">
                    <div class="row mb-2">
                        <label class="col-form-label">Student ID</label>
                        <asp:TextBox ID="txtid" CssClass="form-control" runat="server" placeholder="Enter ID"></asp:TextBox>
                    </div>
                    <div class="row mb-2">
                        <label class="col-form-label">Full Name</label>
                        <asp:TextBox ID="txtfname" CssClass="form-control" runat="server" placeholder="Enter Full name"></asp:TextBox>
                    </div>
                    <div class="row mb-2">
                        <label class="col-form-label">Program</label>
                        <asp:TextBox ID="txtpro" CssClass="form-control" runat="server" placeholder="Enter Program"></asp:TextBox>
                    </div>
                    <div class="row mb-2">
                        <label class="col-form-label">Age</label>
                        <asp:TextBox ID="txtage" CssClass="form-control" runat="server" placeholder="Enter Age"></asp:TextBox>
                    </div>
                    <div class="row mb-2">
                        <label class="col-form-label">Address</label>
                        <asp:TextBox ID="txtadd" CssClass="form-control" runat="server" placeholder="Enter Address"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button2" CssClass="btn btn-primary px-4 py-1" runat="server" Text="Add Student" OnClick="btn2Submit_Click" />
                </div>

                <div class="column col-md-6 p-2">
                    <asp:GridView ID="gvInventory" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="ProductID"
                        CssClass="table table-hover text-white table-bordered"
                        OnRowEditing="gvInventory_RowEditing"
                        OnRowUpdating="gvInventory_RowUpdating"
                        OnRowCancelingEdit="gvInventory_RowCancelingEdit"
                        OnRowDeleting="gvInventory_RowDeleting" OnSelectedIndexChanged="gvInventory_SelectedIndexChanged">

                        <Columns>
                            <asp:BoundField DataField="StudentID" HeaderText="Student ID" ItemStyle-CssClass="p-2" HeaderStyle-CssClass="p-2" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" ItemStyle-CssClass="p-2" HeaderStyle-CssClass="p-2" />
                            <asp:BoundField DataField="Program" HeaderText="Program" ItemStyle-CssClass="p-2" HeaderStyle-CssClass="p-2" />
                            <asp:BoundField DataField="age" HeaderText="Age" ItemStyle-CssClass="p-2" HeaderStyle-CssClass="p-2" />
                            <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-CssClass="p-2" HeaderStyle-CssClass="p-2" />
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button" HeaderText="Actions" ItemStyle-CssClass="p-2" HeaderStyle-CssClass="p-2" />
                        </Columns>

                        <HeaderStyle BackColor="#0d1f33" Font-Bold="True" ForeColor="#00BFFF" />
                        <RowStyle BackColor="#1a2a3a" ForeColor="#ffffff" />
                        <AlternatingRowStyle BackColor="#263447" ForeColor="#ffffff" />
                        <SelectedRowStyle BackColor="#00BFFF" ForeColor="#ffffff" Font-Bold="True" />
                        <PagerStyle BackColor="#0d1f33" ForeColor="#00BFFF" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>

</asp:Content>

