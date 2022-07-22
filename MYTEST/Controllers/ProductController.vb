Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MYTEST

Namespace Controllers
    Public Class ProductController
        Inherits System.Web.Mvc.Controller

        Private db As New VBDatabaseEntities

        ' GET: Product
        Function Index() As ActionResult
            Dim tbl_Product = db.tbl_Product.Include(Function(t) t.tbl_Category)
            Return View(tbl_Product.ToList())
        End Function

        ' GET: Product/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tbl_Product As tbl_Product = db.tbl_Product.Find(id)
            If IsNothing(tbl_Product) Then
                Return HttpNotFound()
            End If
            Return View(tbl_Product)
        End Function

        ' GET: Product/Create
        Function Create() As ActionResult
            ViewBag.CatId = New SelectList(db.tbl_Category, "Id", "CategoryName")
            Return View()
        End Function

        ' POST: Product/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,ProductName,Quality,CatId")> ByVal tbl_Product As tbl_Product) As ActionResult
            If ModelState.IsValid Then
                db.tbl_Product.Add(tbl_Product)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CatId = New SelectList(db.tbl_Category, "Id", "CategoryName", tbl_Product.CatId)
            Return View(tbl_Product)
        End Function

        ' GET: Product/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tbl_Product As tbl_Product = db.tbl_Product.Find(id)
            If IsNothing(tbl_Product) Then
                Return HttpNotFound()
            End If
            ViewBag.CatId = New SelectList(db.tbl_Category, "Id", "CategoryName", tbl_Product.CatId)
            Return View(tbl_Product)
        End Function

        ' POST: Product/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,ProductName,Quality,CatId")> ByVal tbl_Product As tbl_Product) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tbl_Product).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CatId = New SelectList(db.tbl_Category, "Id", "CategoryName", tbl_Product.CatId)
            Return View(tbl_Product)
        End Function

        ' GET: Product/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tbl_Product As tbl_Product = db.tbl_Product.Find(id)
            If IsNothing(tbl_Product) Then
                Return HttpNotFound()
            End If
            Return View(tbl_Product)
        End Function

        ' POST: Product/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tbl_Product As tbl_Product = db.tbl_Product.Find(id)
            db.tbl_Product.Remove(tbl_Product)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
