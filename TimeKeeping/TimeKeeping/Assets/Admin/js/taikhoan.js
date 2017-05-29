//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    loadNhanVien();
    loadQuyen();
});

//Load Data function  
function loadData(){
    var txtSearch = $('#txtSearch').val();
    console.log(txtSearch);
    $.ajax({
        url: "/Admin/TaiKhoan/List",
        type: "POST",
        data: JSON.stringify({ query: txtSearch, page : 1, pageSize : 10 }),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                console.log(item);
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.Ho + " " +item.Ten + '</td>';
                html += '<td>' + item.TenDangNhap + '</td>';
                html += '<td>' + item.TenQuyen + '</td>';
                var d = new Date(parseInt(item.NgayTao.substring(6)));
                html += '<td>' + d.format("dd/mm/yyyy") + '</td>';
                html += '<td>' + (item.TinhTrang == true ? "Kích hoạt" : "Khóa" ) + '</td>';
                html += '<td><a href="#" onclick="return getByID(' + item.ID + ')">Sửa</a> | <a href="#" onclick="Delele(' + item.ID + ')">Xóa</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("Error: "+errormessage.responseText);
        }
    });
}

//Create dropdown Quyền
function loadQuyen() {
    $.ajax({
        url: "/Admin/TaiKhoan/ListQuyen",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                $('#IDQuyen').append($('<option>', {
                    value: item.ID,
                    text: item.TenQuyen
                }));
            });
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//Create dropdown Nhân viên
function loadNhanVien() {
    $.ajax({
        url: "/Admin/TaiKhoan/ListNhanVien",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                $('#IDNhanVien').append($('<option>', {
                    value: item.ID,
                    text: item.Ho + " " +item.Ten
                }));
            });
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var pbObj = {
        ID: $('#ID').val(),
        IDNhanVien: $('#IDNhanVien').val(),
        TenDangNhap: $('#TenDangNhap').val(),
        MatKhau: $('#MatKhau').val(),
        IDQuyen: $('#IDQuyen').val(),
        TinhTrang: $('TinhTrang').val()
    };
    $.ajax({
        url: "/Admin/TaiKhoan/Add",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            if (result === true) {
                alertDisplay("Thêm bản ghi thành công", "alert-success");
            }
            else {
                alertDisplay("Thêm bản ghi không thành công", "alert-danger");
            }
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getByID(pbID) {
    clearTextBox();
    $('#IDNhanVien').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/TaiKhoan/GetByID/" + pbID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#IDNhanVien').val(result.IDNhanVien);
            $('#TenDangNhap').val(result.TenDangNhap);
            $('#MatKhau').val("");
            $('#IDQuyen').val(result.IDQuyen);
            $('#TinhTrang').val(result.TinhTrang.toString());

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var pbObj = {
        ID: $('#ID').val(),
        IDNhanVien: $('#IDNhanVien').val(),
        TenDangNhap: $('#TenDangNhap').val(),
        MatKhau: $('#MatKhau').val(),
        IDQuyen: $('#IDQuyen').val(),
        TinhTrang: $('#TinhTrang').val()
    };
    $.ajax({
        url: "/Admin/TaiKhoan/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#IDNhanVien').val("");
            $('#TenDangNhap').val("");
            $('#MatKhau').val("");
            $('#IDQuyen').val("");
            $('#NgayTao').val("");
            $('#TinhTrang').val("");
            if (result == true) {
                alertDisplay("Sửa bản ghi thành công", "alert-success");
            }
            else {
                alertDisplay("Sửa bản ghi không thành công", "alert-danger");
            }
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Bạn muốn xóa bản ghi này?");
    if (ans) {
        $.ajax({
            url: "/Admin/TaiKhoan/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
                if (result === true) {
                    alertDisplay("Xóa bản ghi thành công", "alert-success");
                }
                else {
                    alertDisplay("Xóa bản ghi không thành công", "alert-danger");
                }
            },
            error: function (errormessage) {
                alert("Error: " + errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#ID').val("");
    $("#IDNhanVien").prop("selectedIndex", 0);
    $('#TenDangNhap').val("");
    $('#MatKhau').val("");
    $("#IDQuyen").prop("selectedIndex", 0);
    $('#NgayTao').val("");
    $("#TinhTrang").prop("selectedIndex", 0);
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#IDNhanVien').css('border-color', 'lightgrey');
    $('#TenDangNhap').css('border-color', 'lightgrey');
    $('#MatKhau').css('border-color', 'lightgrey');
    $('#IDQuyen').css('border-color', 'lightgrey');
    $('#NgayTao').css('border-color', 'lightgrey');
    $('#TinhTrang').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#IDNhanVien').val() == null) {
        $('#IDNhanVien').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDNhanVien').css('border-color', 'lightgrey');
    }
    if ($('#TenDangNhap').val().trim() === "") {
        $('#TenDangNhap').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TenDangNhap').css('border-color', 'lightgrey');
    }
    if ($('#MatKhau').val().trim() === "") {
        $('#MatKhau').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MatKhau').css('border-color', 'lightgrey');
    }
    if ($('#MatKhau').val() !== $('#ReMatKhau').val()) {
        alert("Mật khẩu mới không khớp");
        $('#MatKhau').css('border-color', 'Red');
        $('#ReMatKhau').css('border-color', 'Red');
        isValid = false;
    }
    if ($('#IDQuyen').val() == null) {
        $('#IDQuyen').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDQuyen').css('border-color', 'lightgrey');
    }
    if ($('#TinhTrang').val() == null) {
        $('#TinhTrang').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TinhTrang').css('border-color', 'lightgrey');
    }
    return isValid;
}