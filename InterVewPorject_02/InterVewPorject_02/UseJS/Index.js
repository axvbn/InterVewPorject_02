$(document).ready(function () {
    function Query() {
        $.ajax({
            type: 'POST', url: '/Home/Index_Query', async: true, dataType: 'json',
            success: function (data) {
                if (data !== null && data !== '') {
                    let rtData = JSON.parse(data);
                    let i = 0;
                    $.each(rtData, function () {
                        let tbody = '<tr><td class="CategoryID">' + rtData[i].CategoryID + '</td>' +
                            '<td class="CategoryName">' + rtData[i].CategoryName + '</td>' +
                            '<td class="Description">' + rtData[i].Description + '</td>' +
                            '<td><input type="button" id="btnEdit" class="btn btn-info" value="編輯"/></td>' +
                            '<td><input type="button" id="btnDelete" class="btn btn-danger" value="刪除"/></td>' +
                            '</tr>';
                        $('#CategoriesTB tbody').append(tbody);
                        i++;
                    })
                }
            }
        })
    }

    function Insert() {
        let objParams = {
            'CategoryID': $('#Modal_CategoryID').val(),
            'CategoryName': $('#Modal_CategoryName').val(),
            'Description': $('#Modal_Description').val()
        };
        $.ajax({
            type: 'POST', url: '/Home/Index_Insert', async: true,
            data: { jData: JSON.stringify(objParams) },
            success: function (data) {
                if (data !== null && data !== '') {
                    alert(data);
                    $("#CategoriesTB  tr:not(:first)").empty("");
                    $('#InsertModal').modal('hide');
                    Query();
                }
            },
            error: function (data) {
                alert(data);
            }
        })
    }

    function Update() {
        let objParams = {
            'CategoryID': $('#Modal_CategoryID').val(),
            'CategoryName': $('#Modal_CategoryName').val(),
            'Description': $('#Modal_Description').val()
        };
        $.ajax({
            type: 'POST', url: '/Home/Index_Update', async: true,
            data: { jData: JSON.stringify(objParams) },
            success: function (data) {
                if (data !== null && data !== '') {
                    alert(data);
                    $("#CategoriesTB  tr:not(:first)").empty("");
                    $('#InsertModal').modal('hide');
                    Query();
                }
            },
            error: function (data) {
                alert(data);
            }
        })
    }

    //查詢
    $('#btnQuery').click(function () {
        $("#CategoriesTB  tr:not(:first)").empty("");
        Query()
    })

    //新增畫面
    $('#btnInsert').click(function () {
        $('#Modal_btnINSERT').css('display', '');
        $('#Modal_btnUPDATE').css('display', 'none');
        $('#InsertModal').modal('show');
    })

    //確定新增
    $('#Modal_btnINSERT').click(function () {
        Insert();
    })

    //編輯畫面、刪除
    $('#CategoriesTB tbody').on('click', 'input', function () {
        switch (this.id) {
            case 'btnEdit':
                $('#Modal_btnINSERT').css('display', 'none');
                $('#Modal_btnUPDATE').css('display', '');
                $('#Modal_CategoryID').val($(this).parent().prevAll('.CategoryID').text());
                $('#Modal_CategoryName').val($(this).parent().prevAll('.CategoryName').text());
                $('#Modal_Description').val($(this).parent().prevAll('.Description').text());
                $('#InsertModal').modal('show');
                break;
        }
    })

    //確定編輯
    $('#Modal_btnUPDATE').click(function () {
        Update();
    })
})