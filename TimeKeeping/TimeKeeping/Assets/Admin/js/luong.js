//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    var txtSearch = $('#txtSearch').val();
    $.ajax({
        url: "/Admin/Luong/List",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ query: txtSearch, page: 1, pageSize: 10 }),
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.HeSoLuong + '</td>';
                html += '<td>' + item.LuongCoBan + '</td>';
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

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var pbObj = {
        ID: $('#ID').val(),
        HeSoLuong: $('#HeSoLuong').val(),
        LuongCoBan: $('#LuongCoBan').val()
    };
    $.ajax({
        url: "/Admin/Luong/Add",
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
    $('#HeSoLuong').css('border-color', 'lightgrey');
    $('#LuongCoBan').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/Luong/GetByID/" + pbID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#HeSoLuong').val(result.HeSoLuong);
            $('#LuongCoBan').val(result.LuongCoBan);

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
        HeSoLuong: $('#HeSoLuong').val(),
        LuongCoBan: $('#LuongCoBan').val()
    };
    $.ajax({
        url: "/Admin/Luong/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#HeSoLuong').val("");
            $('#LuongCoBan').val("");
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
            url: "/Admin/Luong/Delete/" + ID,
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
    $('#HeSoLuong').val("");
    $('#LuongCoBan').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#HeSoLuong').css('border-color', 'lightgrey');
    $('#LuongCoBan').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#HeSoLuong').val().trim() == "") {
        $('#HeSoLuong').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#HeSoLuong').css('border-color', 'lightgrey');
    }
    return isValid;
}