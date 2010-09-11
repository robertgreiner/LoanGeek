<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/LoanGeek.Master" Inherits="System.Web.Mvc.ViewPage<LoanGeek.Models.LoanData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LoanGeek | Online Mortgage Calculator
</asp:Content>

<asp:Content ID="LoanGeekContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mortgage Calculator</h2>

    <% using (Html.BeginForm()) { %>
        <div class="label">Loan Amount</div> <%: Html.TextBoxFor(x => x.Principal)%><br />
        <div class="label">Loan Term</div> <%: Html.TextBoxFor(x => x.LoanTerm)%><br />
        <div class="label">Interest Rate</div> <%: Html.TextBoxFor(x => x.InterestRate)%><br />
        <div class="label">Property Tax</div> <%: Html.TextBoxFor(x => x.PropertyTaxPercent)%><br />
        <div class="label">PMI</div> <%: Html.TextBoxFor(x => x.PmiPercent)%><br />
        <div class="label">HOA</div> <%: Html.TextBoxFor(x => x.HoaDuesYearly)%><br />
        <div class="label">Insurance</div> <%: Html.TextBoxFor(x => x.InsuranceYearly)%><br />
        <input class="button" type="submit" name="submit" value="Calculate Loan" />
    <% } %>

    <% if (ViewData["MonthlyPayment"] != null) { %>
        <p>Total Monthly Payment: $<%: ViewData["MonthlyPayment"]%></p>
        <p class="small">
            Note: These values are estimates based on your input and current market trends.  
            The results obtained from this site are not guaranteed to be accurate and should only be used for informational purposes.
        </p>
    <% } %>

</asp:Content>
