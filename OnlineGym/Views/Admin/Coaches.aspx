<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Coaches.aspx.cs" Inherits="OnlineGym.Views.Admin.Coaches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Coaches</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row mt-3">
            <div class="col-md-3">
                <h4 class="text-primary mb-2">Coach's Details</h4>
                <div class="mb-2">
                    <label for="CNameTb" class="form-label">Coach's Name</label>
                    <input type="text" class="form-control" runat="server" id="CNameTb" autocomplete="off" />
                </div>
                <div class="mb-2">
                    <label for="CGenCb" class="form-label">Coach's Gender</label>
                    <asp:DropDownList ID="CGenCb" CssClass="form-select" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-2">
                    <label for="CDOBTb" class="form-label">Coach's DOB</label>
                    <input type="date" class="form-control" runat="server" id="CDOBTb" />
                </div>
                <div class="mb-2">
                    <label for="PhoneTb" class="form-label">Coach's Phone</label>
                    <input type="text" class="form-control" runat="server" id="PhoneTb" autocomplete="off" />
                </div>
                <div class="mb-2">
                    <label for="EmailTb" class="form-label">Coach's Email</label>
                    <input type="text" class="form-control" runat="server" id="EmailTb" autocomplete="off" />
                </div>
                <div class="mb-2">
                    <label for="CExperTb" class="form-label">Coach's Experience</label>
                    <input type="text" class="form-control" runat="server" id="CExperTb" />
                </div>
                <div class="mb-2">
                    <label for="CAddTb" class="form-label">Coach's Address</label>
                    <textarea type="text" class="form-control" runat="server" id="CAddTb" autocomplete="off" />
                </div>

                <div class="row mt-2 mb-3">
                    <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger mb-2" Visible="False"></asp:Label>
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


            <div class="col-md-9 mt-2">
                <asp:GridView ID="CoachList" CssClass="table table-striped" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CoachList_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
