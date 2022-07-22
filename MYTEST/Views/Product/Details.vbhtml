@ModelType MYTEST.tbl_Product
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>tbl_Product</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ProductName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProductName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Quality)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Quality)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.tbl_Category.CategoryName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.tbl_Category.CategoryName)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
