/// <reference path="Supplier.js" />
function AddSupplierSuccess(data) {
    if (data.Success == 1) {
        $("[name = 'idProperty']").val();
        $("[name = '" + $("[name = 'idProperty']").val() + "']").val(data.Supplier.Code);
        alert($("[name = '" + $("[name = 'idProperty']").val() + "']").val() + " - " + data.Supplier.Code);
        $('#DivToAppendPartialView2').dialog('close');
    }
    else {
        alert(data.Message);
        $("[name='" + data.element + "']").focus();
    }}    

    function Add() {
        $("#frmAddSupplier").submit();
    }
