'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class tbl_Category
    Public Property Id As Integer
    Public Property CategoryName As String

    Public Overridable Property tbl_Product As ICollection(Of tbl_Product) = New HashSet(Of tbl_Product)

End Class