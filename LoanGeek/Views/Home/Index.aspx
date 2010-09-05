<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/LoanGeek.Master" Inherits="System.Web.Mvc.ViewPage<LoanGeek.Models.LoanData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LoanGeek | Online Mortgage Calculator
</asp:Content>

<asp:Content ID="LoanGeekContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>LoanGeek</h2>

    <% using (Html.BeginForm()) { %>
        <p>Loan Amount: <%: Html.TextBoxFor(x => x.Principal)%></p>
        <p>Loan Term: <%: Html.TextBoxFor(x => x.LoanTerm)%></p>
        <p>Interest Rate: <%: Html.TextBoxFor(x => x.InterestRate)%></p>
        <p>Property Tax: <%: Html.TextBoxFor(x => x.PropertyTaxPercent)%></p>
        <p>PMI: <%: Html.TextBoxFor(x => x.PmiPercent)%></p>
        <p>HOA: <%: Html.TextBoxFor(x => x.HoaDuesYearly)%></p>
        <p>Insurance: <%: Html.TextBoxFor(x => x.InsuranceYearly)%></p>
        <input type="submit" value="Calculate Loan" />
    <% } %>
</asp:Content>
