//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    loadChucVu();
});

//Load Data function  
function loadData() {
    var txtSearch = $('#txtSearch').val();
    $.ajax({
        url: "/Admin/PhuCap/List",
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
                html += '<td>' + item.MoTaPhuCap + '</td>';
                html += '<td>' + item.SoTien + '</td>';
                html += '<td>' + (item.TinhTrang == true ? "Kích hoạt" : "Khóa") + '</td>';
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

//Create dropdown Chức vụ
function loadChucVu() {
    $.ajax({
        url: "/Admin/PhuCap/ListChucVu",
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
//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var pbObj = {
        ID : $('#ID').val(),
        IDChucVu : $('#IDChucVu').val(),
        MoTaPhuCap : $('#MoTaPhuCap').val(),
        SoTien : $('#SoTien').val(),
        TinhTrang: $('#TinhTrang').prop("checked")
};
    $.ajax({
        url: "/Admin/PhuCap/Add",
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
    $('#IDChucVu').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/PhuCap/GetByID/" + pbID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#IDChucVu').val(result.IDChucVu);
            $('#MoTaPhuCap').val(result.MoTaPhuCap);
            $('#SoTien').val(result.SoTien);
            $('#TinhTrang').prop("checked",result.TinhTrang);

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
        IDChucVu: $('#IDChucVu').val(),
        MoTaPhuCap: $('#MoTaPhuCap').val(),
        SoTien: $('#SoTien').val(),
        TinhTrang: $('#TinhTrang').prop("checked")
    };
    $.ajax({
        url: "/Admin/PhuCap/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#IDChucVu').prop("selectedIndex", 0);
            $('#MoTaPhuCap').val("");
            $('#SoTien').val("");
            $('#TinhTrang').prop("checked", true);
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
            url: "/Admin/PhuCap/Delete/" + ID,
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
    $('#MoTaPhuCap').val("");
    $('#SoTien').val("");
    $('#TinhTrang').prop("checked", true);
    $('#IDChucVu').prop("selectedIndex",0);
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#TenPhuCap').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#IDChucVu').val() == null) {
        $('#IDChucVu').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IDChucVu').css('border-color', 'lightgrey');
    }
    if ($('#SoTien').val().trim() == "") {
        $('#SoTien').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SoTien').css('border-color', 'lightgrey');
    }
    return isValid;
}