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
        
        <p><h4>Loan Details</h4><br /></p>

        <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary() %>
            <div class="label"><h3>Purchase Price ($)</h3> </div> <%: Html.TextBoxFor(x => x.PurchasePrice) %><br />
            <div class="label"><h3>Down Payment (%)</h3> </div> <%: Html.TextBoxFor(x => x.DownPayment) %><br />
            <div class="label"><h3>Loan Amount ($)</h3> </div> <%: Html.TextBox("principal") %><br />
            <div class="label"><h3>Loan Term (years)</h3> </div> <%: Html.TextBoxFor(x => x.LoanTerm) %><br />
            <div class="label"><h3>Interest Rate (%)</h3> </div> <%: Html.TextBoxFor(x => x.InterestRate) %><br />
            <div class="label"><h3>Property Tax (%)</h3> </div> <%: Html.TextBoxFor(x => x.PropertyTaxPercent) %><br />
            <div class="label"><h3>PMI (%)</h3> </div> <%: Html.TextBoxFor(x => x.PmiPercent) %><br />
            <div class="label"><h3>HOA ($/year)</h3> </div> <%: Html.TextBoxFor(x => x.HoaDuesYearly) %><br />
            <div class="label"><h3>Insurance ($/year)</h3> </div> <%: Html.TextBoxFor(x => x.InsuranceYearly) %><br />
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
