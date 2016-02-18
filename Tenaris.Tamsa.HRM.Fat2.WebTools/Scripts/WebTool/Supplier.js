/// <reference path="Supplier.js" />
function AddSupplierSuccess(data) {
    if (data.Success == 1) {
        var idProperty = $("[name = 'idProperty']").val();
        var Select = $("[name = '" + idProperty + "']");
        Select.append($('<option>', { value: data.Supplier.Code, text: data.Supplier.Code }));
        Select.val(data.Supplier.Code);

        
        //$("[name = '" + $("[name = 'idProperty']").val() + "'").append($('option', { value: data.Supplier.Code, text: data.Supplier.Code }));
        ////alert($("[name = '" + $("[name = 'idProperty']").val() + "']").val() + " - " + data.Supplier.Code);
        //$("[name = '" + $("[name = 'idProperty'] option:eq('" + data.Supplier.Code + "')") + "'").prop('selected',true);
        $('#DivToAppendPartialView2').dialog('close');
    }
    else {
        alert(data.Message);
        $("[name='" + data.element + "']").focus();
    }}    

    function Add() {
        $("#frmAddSupplier").submit();
    }
