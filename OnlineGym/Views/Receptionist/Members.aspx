<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Receptionist/ReceptionistMaster.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="OnlineGym.Views.Receptionist.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Members</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <h4 class="text-primary">Member's Details</h4>
                <div class="mb-1">
                    <label for="MemNameTb" class="form-label">Member's Name</label>
                    <input type="text" class="form-control" runat="server" id="MemNameTb" autocomplete="off" />
                </div>
                <div class="mb-1">
                    <label for="MemGenCb" class="form-label">Member's Gender</label>
                    <asp:DropDownList CssClass="form-select" ID="MemGenCb" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-1">
                    <label for="MemAgeTb" class="form-label">Member's Age</label>
                    <input type="number" class="form-control" runat="server" id="MemAgeTb" />
                </div>
                <div class="mb-1">
                    <label for="MemPhoneTb" class="form-label">Member's Phone Number</label>
                    <input type="text" class="form-control" runat="server" id="MemPhoneTb" autocomplete="off" />
                </div>
                <div class="mb-1">
                    <label for="MemTimingList" class="form-label">Timing</label><br />
                    <asp:DropDownList CssClass="form-select" ID="MemTimingList" runat="server">
                        <asp:ListItem>07.00 AM</asp:ListItem>
                        <asp:ListItem>11.30 AM</asp:ListItem>
                        <asp:ListItem>04.30 PM</asp:ListItem>
                        <asp:ListItem>07.30 PM</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-1">
                    <label for="MemJoinDate" class="form-label">Joining Date</label>
                    <input type="date" class="form-control" runat="server" id="MemJoinDate" />
                </div>
                <div class="mb-1 dropdown">
                    <label for="MemShipList" class="form-label">MemberShip Plan</label><br />
                    <asp:DropDownList CssClass="form-control" ID="MemShipList" runat="server">
                        <asp:ListItem>1 Month</asp:ListItem>
                        <asp:ListItem>3 Month</asp:ListItem>
                        <asp:ListItem>6 Month</asp:ListItem>
                        <asp:ListItem>1 year</asp:ListItem>
                    </asp:DropDownList>
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

            <div class="col-md-9 mt-3">
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-3 mb-2">
                        <div>
                            <asp:TextBox ID="SearchMem" placeholder="Search Member" CssClass="form-control" runat="server" OnTextChanged="SearchMem_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-5 mb-2">
                        <asp:Button ID="SearchBtn" runat="server" Text="Search" BackColor="Blue" CssClass="btn btn-primary" OnClick="SearchBtn_Click" />
                        
                    </div>
                </div>
                <asp:GridView ID="MemberList" CssClass="table table-striped" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="MemberList_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
