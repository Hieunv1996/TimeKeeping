//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Admin/CaLamViec/List",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' +item.TenCaLamViec  + '</td>';
                html += '<td>' + (zeroFill(item.TGBatDau.Hours) + ":" + zeroFill(item.TGBatDau.Minutes) + ":" + zeroFill(item.TGBatDau.Seconds)) + '</td>';
                html += '<td>' + (zeroFill(item.TGKetThuc.Hours) + ":" + zeroFill(item.TGKetThuc.Minutes) + ":" + zeroFill(item.TGKetThuc.Seconds)) + '</td>';
                html += '<td><a href="#" onclick="return getByID(' + item.ID + ')">Sửa</a> | <a href="#" onclick="Delele(' + item.ID + ')">Xóa</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function zeroFill(n) {
    if ((n + '').length == 1)
        return '0' + n;

    return n;
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var pbObj = {
        ID: $('#ID').val(),
        TenCaLamViec: $('#TenCaLamViec').val(),
        TGBatDau: $('#TGBatDau').val(),
        TGKetThuc: $('#TGKetThuc').val()
    };
    $.ajax({
        url: "/Admin/CaLamViec/Add",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getByID(pbID) {
    $('#TenCaLamViec').css('border-color', 'lightgrey');
    $('#TGBatDau').css('border-color', 'lightgrey');
    $('#TGKetThuc').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/CaLamViec/GetByID/" + pbID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#TenCaLamViec').val(result.TenCaLamViec);
            $('#TGBatDau').val((zeroFill(result.TGBatDau.Hours) + ":" + zeroFill(result.TGBatDau.Minutes) + ":" + zeroFill(result.TGBatDau.Seconds)));
            $('#TGKetThuc').val((zeroFill(result.TGKetThuc.Hours) + ":" + zeroFill(result.TGKetThuc.Minutes) + ":" + zeroFill(result.TGKetThuc.Seconds)));

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var pbObj = {
        ID: $('#ID').val(),
        TenCaLamViec: $('#TenCaLamViec').val(),
        TGBatDau: $('#TGBatDau').val(),
        TGKetThuc: $('#TGKetThuc').val()
    };
    $.ajax({
        url: "/Admin/CaLamViec/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#TenCaLamViec').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Bạn muốn xóa bản ghi này?");
    if (ans) {
        $.ajax({
            url: "/Admin/CaLamViec/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#ID').val("");
    $('#TenCaLamViec').val("");
    $('#TGBatDau').val("");
    $('#TGKetThuc').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#TenCaLamViec').css('border-color', 'lightgrey');
    $('#TGBatDau').css('border-color', 'lightgrey');
    $('#TGKetThuc').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#TenCaLamViec').val().trim() == "") {
        $('#TenCaLamViec').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TenCaLamViec').css('border-color', 'lightgrey');
    }

    if ($('#TGBatDau').val().trim() == "") {
        $('#TGBatDau').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TGBatDau').css('border-color', 'lightgrey');
    }

    if ($('#TGKetThuc').val().trim() == "") {
        $('#TGKetThuc').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TGKetThuc').css('border-color', 'lightgrey');
    }
    return isValid;
}