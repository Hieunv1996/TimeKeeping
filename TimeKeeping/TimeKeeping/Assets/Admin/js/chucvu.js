//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    var txtSearch = $('#txtSearch').val();
    $.ajax({
        url: "/Admin/ChucVu/List",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ query: txtSearch, page: 1, pageSize: 10 }),
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.TenChucVu + '</td>';
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
        TenChucVu: $('#TenChucVu').val()
    };
    $.ajax({
        url: "/Admin/ChucVu/Add",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            if (result == true) {
                alertDisplay("Thêm bản ghi thành công", "alert-success");
            }
            else {
                alertDisplay("Thêm bản ghi không thành công", "alert-danger");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getByID(pbID){
    clearTextBox();
    $('#TenChucVu').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/ChucVu/GetByID/" + pbID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#TenChucVu').val(result.TenChucVu);

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
        TenChucVu: $('#TenChucVu').val()
    };
    $.ajax({
        url: "/Admin/ChucVu/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#TenChucVu').val("");
            if (result == true) {
                alertDisplay("Sửa bản ghi thành công", "alert-success");
            }
            else {
                alertDisplay("Sửa bản ghi không thành công", "alert-danger");
            }
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
            url: "/Admin/ChucVu/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
                if (result == true) {
                    alertDisplay("Xóa bản ghi thành công", "alert-success");
                }
                else {
                    alertDisplay("Xóa bản ghi không thành công", "alert-danger");
                }
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
    $('#TenChucVu').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#TenChucVu').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#TenChucVu').val().trim() == "") {
        $('#TenChucVu').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TenChucVu').css('border-color', 'lightgrey');
    }
    return isValid;
}