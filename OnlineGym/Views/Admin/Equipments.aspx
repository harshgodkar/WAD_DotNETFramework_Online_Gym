<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Equipments.aspx.cs" Inherits="OnlineGym.Views.Admin.Equipments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Equipments</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row mt-3">
            <div class="col-md-3">
                <h4 class="text-primary">Equipment Details</h4>
                <div class="mb-2">
                    <label for="EquNameTb" class="form-label">Equipment Name</label>
                    <input type="text" class="form-control" runat="server" id="EquNameTb" />
                </div>
                <div class="mb-2">
                    <label for="EquDescTb" class="form-label">Description</label>
                    <textarea type="text" class="form-control" runat="server" id="EquDescTb" autocomplete="off" />
                </div>
                <div class="mb-2">
                    <label for="EquTb" class="form-label">Muscles Used</label>
                    <input type="text" class="form-control" runat="server" id="EquTb" />
                </div>
                <div class="mb-2">
                    <label for="EquDelDate" class="form-label">Delivery Date</label>
                    <input type="date" class="form-control" runat="server" id="EquDelDate" />
                </div>
                <div class="mb-2">
                    <label for="EquCost" class="form-label">Equipment Cost</label>
                    <input type="number" class="form-control" runat="server" id="EquCost" />
                </div>
                <div class="row mt-3 mb-5">
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
                <asp:GridView ID="EquipList" CssClass="table table-striped" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="EquipList_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
