﻿@ModelType IEnumerable(Of MYTEST.tbl_Product)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ProductName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Quality)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.tbl_Category.CategoryName)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ProductName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Quality)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.tbl_Category.CategoryName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
