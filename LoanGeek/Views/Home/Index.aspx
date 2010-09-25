<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/LoanGeek.Master" Inherits="System.Web.Mvc.ViewPage<LoanGeek.Models.LoanData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LoanGeek | Online Mortgage Calculator
</asp:Content>

<asp:Content ID="LoanGeekContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="clear"></div>
    
    <div class="box590">
        <h2>Mortgage Calculator</h2>
    </div>

    <div class="box280">
        <% if (ViewData["MonthlyPayment"] != null) { %>
            <h2>Monthly Breakdown</h2>
        <% } %>
    </div>

    <div class="clear"></div>

    <div class="box590">
        <% using (Html.BeginForm()) { %>
            <div class="label">Loan Amount ($)</div> <%: Html.TextBoxFor(x => x.Principal)%><br />
            <div class="label">Loan Term (years) </div> <%: Html.TextBoxFor(x => x.LoanTerm)%><br />
            <div class="label">Interest Rate (%) </div> <%: Html.TextBoxFor(x => x.InterestRate)%><br />
            <div class="label">Property Tax (%) </div> <%: Html.TextBoxFor(x => x.PropertyTaxPercent)%><br />
            <div class="label">PMI (%) </div> <%: Html.TextBoxFor(x => x.PmiPercent)%><br />
            <div class="label">HOA ($/year)</div> <%: Html.TextBoxFor(x => x.HoaDuesYearly)%><br />
            <div class="label">Insurance ($/year) </div> <%: Html.TextBoxFor(x => x.InsuranceYearly)%><br />
            <input class="button" type="submit" name="submit" value="Calculate Loan" />
        <% } %>
    </div>

    <div class="box280">
        <% if (ViewData["MonthlyPayment"] != null) { %>
            
            <h4>Total: $<%: ViewData["MonthlyPayment"]%></h4>
            <br />
            <p><strong>Principal:</strong> $<%: ViewData["Principal"]%></p>
            <p><strong>Interest:</strong> $<%: ViewData["Interest"]%></p>
            <p><strong>Property Tax:</strong> $<%: ViewData["PropertyTax"]%></p>
            <p><strong>PMI:</strong> $<%: ViewData["Pmi"]%></p>
            <p><strong>HOA:</strong> $<%: ViewData["Hoa"]%></p>
            <p><strong>Insurance:</strong> $<%: ViewData["Insurance"]%></p>
            <br />
            <p class="small">
                Note: These values are estimates based on your input and current market trends.  
                The results obtained from this site are not guaranteed to be accurate and should only be used for informational purposes.
            </p>
        <% } %>
    </div>

</asp:Content>
