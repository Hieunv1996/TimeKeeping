
//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    loadChucVu();
    loadHSLuong();
    loadPhongBan();
});
//Load Data function  
function loadData() {
    var txtSearch = $('#txtSearch').val();
    $.ajax({
        url: "/Admin/NhanVien/List",
        type: "POST",
        data: JSON.stringify({ query: txtSearch, page: 1, pageSize: 10 }),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.Ho + " " + item.Ten + '</td>';
                var d = new Date(parseInt(item.NgaySinh.substring(6)));
                html += '<td>' + d.format("dd/mm/yyyy") + '</td>';
                html += '<td>' + item.CMND + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td>' + item.DienThoai + '</td>';
                html += '<td>' + item.TenChucVu + '</td>';
                html += '<td>' + item.TenPhongBan + '</td>';
                html += '<td>' + item.HeSoLuong + '</td>';
                html += '<td><a href="#" onclick="return getByID(' + item.ID + ')">Sửa</a> | <a href="#" onclick="Delele(' + item.ID + ')">Xóa</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//Create dropdown Chức vụ
function loadChucVu() {
    $.ajax({
        url: "/Admin/NhanVien/ListChucVu",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                $('#IDChucVu').append($('<option>', {
                    value: item.ID,
                    text: item.TenChucVu
                }));
            });
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//Create dropdown Phòng ban
function loadPhongBan() {
    $.ajax({
        url: "/Admin/NhanVien/ListPhongBan",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                $('#IDPhongBan').append($('<option>', {
                    value: item.ID,
                    text: item.TenPhongBan
                }));
            });
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
        }
    });
}

//Create dropdown HS Lương
function loadHSLuong() {
    $.ajax({
        url: "/Admin/NhanVien/ListHeSoLuong",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                $('#IDHeSoLuong').append($('<option>', {
                    value: item.ID,
                    text: "Hệ số " + item.HeSoLuong
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
    if (res == false) {
        return false;
    }
    var pbObj = {
        ID: $('#ID').val(),
        Ho: $('#Ho').val(),
        Ten: $('#Ten').val(),
        GioiTinh: $('#GioiTinh').val(),
        NgayVaoLam: $('#NgayVaoLam').val(),
        NgaySinh: $('#NgaySinh').val(),
        CMND: $('#CMND').val(),
        Email: $('#Email').val(),
        DienThoai: $('#DienThoai').val(),
        AnhDaiDien: $('#AnhDaiDien').val(),
        IDChucVu: $('#IDChucVu').val(),
        IDPhongBan: $('#IDPhongBan').val(),
        IDHeSoLuong: $('#IDHeSoLuong').val()
    };
    $.ajax({
        url: "/Admin/NhanVien/Add",
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
    $('#Ho').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/NhanVien/GetByID/" + pbID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#Ho').val(result.Ho);
            $('#Ten').val(result.Ten);
            $("#GioiTinh").val(result.GioiTinh.toString());
            var d = new Date(parseInt(result.NgayVaoLam.substring(6)));
            $('#NgayVaoLam').val(d.format("yyyy-mm-dd"));
            d = new Date(parseInt(result.NgaySinh.substring(6)));
            $('#NgaySinh').val(d.format("yyyy-mm-dd"));
            $('#CMND').val(result.CMND);
            $('#Email').val(result.Email);
            $('#DienThoai').val(result.DienThoai);
            $('#AnhDaiDien').val(result.AnhDaiDien);
            $('#IDChucVu').val(result.IDChucVu);
            $('#IDPhongBan').val(result.IDPhongBan);
            $('#IDHeSoLuong').val(result.IDHeSoLuong);

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
        Ho: $('#Ho').val(),
        Ten: $('#Ten').val(),
        GioiTinh: $('#GioiTinh').val(),
        NgayVaoLam: $('#NgayVaoLam').val(),
        NgaySinh: $('#NgaySinh').val(),
        CMND: $('#CMND').val(),
        Email: $('#Email').val(),
        DienThoai: $('#DienThoai').val(),
        AnhDaiDien: $('#AnhDaiDien').val(),
        IDChucVu: $('#IDChucVu').val(),
        IDPhongBan: $('#IDPhongBan').val(),
        IDHeSoLuong: $('#IDHeSoLuong').val()
    };
    $.ajax({
        url: "/Admin/NhanVien/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
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
            url: "/Admin/NhanVien/Delete/" + ID,
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
function clearTextBox(){
    $('#ID').val("");
    $('#Ho').val("");
    $('#Ten').val("");
    $("#GioiTinh").prop("selectedIndex", 0);
    $('#NgayVaoLam').val("");
    $('#NgaySinh').val("");
    $('#CMND').val("");
    $('#Email').val("");
    $('#DienThoai').val("");
    $('#AnhDaiDien').val("");
    $("#IDChucVu").prop("selectedIndex", 0);
    $('#IDPhongBan').prop("selectedIndex", 0);
    $('#IDHeSoLuong').prop("selectedIndex", 0);
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Ho').css('border-color', 'lightgrey');
    $('#Ten').css('border-color', 'lightgrey');
    $('#GioiTinh').css('border-color', 'lightgrey');
    $('#NgayVaoLam').css('border-color', 'lightgrey');
    $('#NgaySinh').css('border-color', 'lightgrey');
    $('#CMND').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#DienThoai').css('border-color', 'lightgrey');
    $('#IDChucVu').css('border-color', 'lightgrey');
    $('#IDPhongBan').css('border-color', 'lightgrey');
    $('#IDHeSoLuong').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Ho').val().trim() == "") {
        $('#Ho').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Ho').css('border-color', 'lightgrey');
    }
    if ($('#Ten').val().trim() == "") {
        $('#Ten').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Ten').css('border-color', 'lightgrey');
    }
    if ($('#GioiTinh').val() == null) {
        $('#GioiTinh').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GioiTinh').css('border-color', 'lightgrey');
    }
    if ($('#NgayVaoLam').val().trim() == "") {
        $('#NgayVaoLam').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NgayVaoLam').css('border-color', 'lightgrey');
    }
    if ($('#NgaySinh').val().trim() == "") {
        $('#NgaySinh').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NgaySinh').css('border-color', 'lightgrey');
    }
    if ($('#CMND').val().trim() == "") {
        $('#CMND').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CMND').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#DienThoai').val().trim() == "") {
        $('#DienThoai').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DienThoai').css('border-color', 'lightgrey');
    }
    if ($('#IDChucVu').val() == null) {
        $('#IDChucVu').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDChucVu').css('border-color', 'lightgrey');
    }
    if ($('#IDPhongBan').val() == null) {
        $('#IDPhongBan').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDPhongBan').css('border-color', 'lightgrey');
    }
    if ($('#IDHeSoLuong').val() == null) {
        $('#IDHeSoLuong').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDHeSoLuong').css('border-color', 'lightgrey');
    }
    return isValid;
}

//CkFinder
$('#btnSelectImage').on('click', function (e) {
    var finder = new CKFinder();
    finder.selectActionFunction = function (url) {
        $('#AnhDaiDien').val(url);
    };
    finder.popup();
})

