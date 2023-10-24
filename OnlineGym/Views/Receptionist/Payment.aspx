<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Receptionist/ReceptionistMaster.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="OnlineGym.Views.Receptionist.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Payment</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row mt-2">
            <div class="col-md-3">
                <h4 class="text-primary">Payment Details</h4>
                <div class="mb-2">
                    <label for="MemberCb" class="form-label">Member's Name</label>
                    <asp:DropDownList ID="MemberCb" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MemberCb_SelectedIndexChanged"></asp:DropDownList>

    
                </div>
                <div class="mb-2">
                    <label for="PayAmt" class="form-label">Payment Amount</label>
                    <input type="number" class="form-control" runat="server" id="PayAmt" />
                </div>
                <div class="mb-2 dropdown">
                    <label for="PayPlanListIp" class="form-label">Payment Plan</label>
                    <asp:DropDownList ID="PayPlanListIp" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-2">
                    <label for="Paydate" class="form-label">Payment Date</label>
                    <input type="date" class="form-control" runat="server" id="Paydate" />
                </div>
                <div class="row mt-2 mb-5">
                    <div class="col d-grid ">
                        <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger mb-2"></asp:Label>
                        <asp:Label ID="SuccMsg" runat="server" CssClass="text-success mb-2"></asp:Label>
                        <asp:Button ID="AddBtn" CssClass="btn btn-block btn-primary" runat="server" Text="Pay" OnClick="AddBtn_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-9">
                <asp:GridView ID="PaymentList" CssClass="table table-striped" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
