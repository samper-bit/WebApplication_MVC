var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            {
                data: 'name', "width": "15%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },

            {
                data: 'streetAddress', "width": "15%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },

            {
                data: 'city', "width": "12%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },

            {
                data: 'state', "width": "12%",
                "render": function (data) {
                    return `<div class="text-dark">
                        <td>${data}</td>
                    </div>`
                }
            },

            {
                data: 'postalCode', "width": "11%",
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
                data: 'id', "width": "20%",
                "render": function (data) {
                    return `<div class="btn-group" role="group">
                        <a href="/admin/company/upsert?id=${data}" class="btn btn-warning  m-0"><i class="bi bi-pencil pe-1"></i> Edit</a>
                        <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger  m-0"><i class="bi bi-trash"></i> Delete</a>
                    </div>`
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}