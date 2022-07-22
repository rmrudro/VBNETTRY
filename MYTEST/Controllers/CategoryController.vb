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
    Public Class CategoryController
        Inherits System.Web.Mvc.Controller

        Private db As New VBDatabaseEntities

        ' GET: Category
        Function Index() As ActionResult
            Return View(db.tbl_Category.ToList())
        End Function

        ' GET: Category/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tbl_Category As tbl_Category = db.tbl_Category.Find(id)
            If IsNothing(tbl_Category) Then
                Return HttpNotFound()
            End If
            Return View(tbl_Category)
        End Function

        ' GET: Category/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Category/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,CategoryName")> ByVal tbl_Category As tbl_Category) As ActionResult
            If ModelState.IsValid Then
                db.tbl_Category.Add(tbl_Category)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tbl_Category)
        End Function

        ' GET: Category/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tbl_Category As tbl_Category = db.tbl_Category.Find(id)
            If IsNothing(tbl_Category) Then
                Return HttpNotFound()
            End If
            Return View(tbl_Category)
        End Function

        ' POST: Category/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,CategoryName")> ByVal tbl_Category As tbl_Category) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tbl_Category).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tbl_Category)
        End Function

        ' GET: Category/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tbl_Category As tbl_Category = db.tbl_Category.Find(id)
            If IsNothing(tbl_Category) Then
                Return HttpNotFound()
            End If
            Return View(tbl_Category)
        End Function

        ' POST: Category/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tbl_Category As tbl_Category = db.tbl_Category.Find(id)
            db.tbl_Category.Remove(tbl_Category)
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
