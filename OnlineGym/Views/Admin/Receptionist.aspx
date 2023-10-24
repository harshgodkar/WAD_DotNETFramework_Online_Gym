<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Receptionist.aspx.cs" Inherits="OnlineGym.Views.Admin.Receptionist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Receptionist</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row mt-3">
            <div class="col-md-3">
                <h4 class="text-primary">Receptionist's Details</h4>
                <div class="mb-1">
                    <label for="RecNameTb" class="form-label">Receptionist's Name</label>
                    <input type="text" class="form-control" runat="server" id="RecNameTb" autocomplete="off" />
                </div>
                <div class="mb-1">
                    <label for="RecGenCb" class="form-label">Receptionist's Gender</label>
                    <asp:DropDownList ID="RecGenCb" CssClass="form-select" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-1">
                    <label for="RecDOBTb" class="form-label">Receptionist's DOB</label>
                    <input type="date" class="form-control" runat="server" id="RecDOBTb" />
                </div>
                <div class="mb-1">
                    <label for="RecPhoneTb" class="form-label">Receptionist's Phone</label>
                    <input type="text" class="form-control" runat="server" id="RecPhoneTb" autocomplete="off" />
                </div>
                <div class="mb-1">
                    <label for="RecAddTb" class="form-label">Receptionist's Address</label>
                    <textarea type="text" class="form-control" runat="server" id="RecAddTb"/>
                </div>
                <div class="mb-1">
                    <label for="RecEmailTb" class="form-label">Receptionist's Email</label>
                    <input type="text" class="form-control" runat="server" id="RecEmailTb" autocomplete="off" />
                </div>
                <div class="mb-1">
                    <label for="RecPasswordtb" class="form-label">Receptionist's Password</label>
                    <input type="text" class="form-control" runat="server" id="RecPasswordtb" autocomplete="off" />
                </div>

                <div class="row mt-2 mb-5">
                    <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger mb-2"></asp:Label>
                    <asp:Label ID="SuccMsg" runat="server" CssClass="text-success mb-2"></asp:Label>
                    <div class="col d-grid">
                        <asp:Button ID="AddBtn" CssClass="btn btn-block btn-primary" runat="server" Text="Add" OnClick="AddBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="EditBtn" CssClass="btn btn-block btn-warning" runat="server" Text="Edit" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="DelBtn" CssClass="btn btn-block btn-danger" runat="server" Text="Delete" OnClick="DelBtn_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-9">
                <asp:GridView ID="ReceptionistList" CssClass="table table-striped" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ReceptionistList_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
