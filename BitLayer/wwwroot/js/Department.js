


$(document).ready(function () {
    $('#DepTable').DataTable(
        {
            ajax: {
                url: "Department/GetAllDepartment",
                type: "POST",
            },
            processing: true,
            serverSide: true,
            searching: true,
            ordering: true,
            paging: true,
            columns: [


                {
                    data: "Id",
                    "render": function (data, type, row) { return '<a  data-bs-toggle="modal" data-bs-target="#Detail"  data-url="/Department/Detail?id=' + data + '" ><i class="fa-regular fa-book"></i></a>'; }

                },

                { data: "Id", name: "Id" },

                { data: "DepartmentName", name: "Name" },

               
            
                
                {
                    data: "Id",
                    "render": function (data, type, row) { return '<button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#Edit"  data-url="/Department/AddOrEdit?Id=' + data + '" >Edit</button>'; }
                },
                {
                    data: "Id",
                    render: function (data, type, row) {
                        return "<a id='DelEmp' class='' ('" + data + "'); >Delete</a>";
                    }


                },






            ]
        }


    );




});
