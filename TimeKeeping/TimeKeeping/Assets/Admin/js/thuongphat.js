//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    loadNhanVien();
});

//Load Data function  
function loadData() {
    var txtSearch = $('#txtSearch').val();
    $.ajax({
        url: "/Admin/ThuongPhat/List",
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
                html += '<td>' + item.MoTa + '</td>';
                html += '<td>' + item.SoTien + '</td>';

                var d = new Date(parseInt(item.DauThoiGian.substring(6)));
                html += '<td>' + d.format("dd/mm/yyyy") + '</td>';
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

//Create dropdown Nhân viên
function loadNhanVien() {
    $.ajax({
        url: "/Admin/ThuongPhat/ListNhanVien",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                $('#IDNhanVien').append($('<option>', {
                    value: item.ID,
                    text: item.Ho + " " + item.Ten
                }));
            });
        },
        error: function (errormessage) {
            alert("Error: " + errormessage.responseText);
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
        IDNhanVien: $('#IDNhanVien').val(),
        MoTa: $('#MoTa').val(),
        SoTien: $('#SoTien').val()
    };
    $.ajax({
        url: "/Admin/ThuongPhat/Add",
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
    $('#IDNhanVien').css('border-color', 'lightgrey');
    $('#MoTa').css('border-color', 'lightgrey');
    $('#SoTien').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Admin/ThuongPhat/GetByID/" + pbID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#IDNhanVien').val(result.IDNhanVien);
            $('#MoTa').val(result.MoTa);
            $('#SoTien').val(result.SoTien);

            $('#myModal').modal();
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
        IDNhanVien: $('#IDNhanVien').val(),
        MoTa: $('#MoTa').val(),
        SoTien: $('#SoTien').val()
    };
    $.ajax({
        url: "/Admin/ThuongPhat/Update",
        data: JSON.stringify(pbObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#TenThuongPhat').val("");
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
            url: "/Admin/ThuongPhat/Delete/" + ID,
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
    $('#IDNhanVien').prop("selectedIndex", 0);
    $('#MoTa').val("");
    $('#SoTien').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#IDNhanVien').css('border-color', 'lightgrey');
    $('#MoTa').css('border-color', 'lightgrey');
    $('#SoTien').css('border-color', 'lightgrey');
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

    if ($('#SoTien').val().trim() == "") {
        $('#SoTien').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SoTien').css('border-color', 'lightgrey');
    }
    return isValid;
}