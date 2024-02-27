var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else if (url.includes("completed")) {
        loadDataTable("completed");
    }
    else if (url.includes("pending")) {
        loadDataTable("pending");
    }
    else if (url.includes("approved")) {
        loadDataTable("approved");
    }
    else {
        loadDataTable("all");
    }
});


function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall?status=' + status },
        "columns": [
            {
                data: 'id', "width": "10%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },
            {
                data: 'name', "width": "15%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },
            {
                data: 'phoneNumber', "width": "15%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },
            {
                data: 'applicationUser.email', "width": "25%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },
            {
                data: 'orderStatus', "width": "10%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },
            {
                data: 'orderTotal', "width": "10%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },
            {
                data: 'id', "width": "10%",
                "render": function (data) {
                    return `<div class="btn-group" role="group">
                        <a href="/admin/order/details?orderId=${data}" class="btn btn-warning text-center m-0 px-3"><i class="bi bi-pencil"></i></a>
                    </div>`
                }
            }
        ]
    });
}