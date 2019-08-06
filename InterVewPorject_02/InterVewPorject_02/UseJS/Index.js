$(document).ready(function () {
    function Query() {
        $.ajax({
            type: 'POST', url: '/Home/Index_Query', async: true, dataType: 'json',
            success: function (data) {
                if (data !== null && data !== '') {
                    let rtData = JSON.parse(data);
                    let i = 0;
                    $.each(rtData, function () {
                        let tbody = '<tr><td>' + rtData[i].CategoryID + '</td>' +
                            '<td>' + rtData[i].CategoryName + '</td>' +
                            '<td>' + rtData[i].Description + '</td>' +
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

    $('#btnQuery').click(function () {
        $("#CategoriesTB  tr:not(:first)").empty("");
        Query()
    })

})