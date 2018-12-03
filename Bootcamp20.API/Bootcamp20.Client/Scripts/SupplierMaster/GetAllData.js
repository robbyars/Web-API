LoadIndexSupplier();

function LoadIndexSupplier(){
        $.ajax({
            url: 'http://localhost:1349/api/Suppliers',
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var html = '';
                for (var i = 0; i < data.length; i++) {
                    html = html + '<tr>';
                    
                    html = html + '<td>' + data[i].Name + '</td>';

                    html = html + '<td><button onclick="return GetById(' + data[i].Id + ')">Edit</button>';

                    html = html + '| <button onclick="return Delete(' + data[i].Id +')">Delete</button>';
                    
                    html = html + '</tr>';
                }
                $('#tBody').html(html);
            }

    });
}

function Save() {
    var supplier = new Object();
    supplier.name = $('#Name').val();
    if(supplier.name == ''){
        swal("Invalid", "Isi Form sesuai Data", "warning");
        return false;
    }
    else {
        $.ajax({
            url: 'http://localhost:1349/api/Suppliers',
            type: 'POST',
            dataType: 'json',
            data: supplier,
            success: function (result) {
                LoadIndexSupplier();
                $('#myModal').modal('hide');
            }
        });
    }
}

function SaveTampil() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Save').show();
    $('#Update').hide();
}

function Edit() {
    var supplier = new Object();
    supplier.Id = $('#Id').val();
    supplier.Name = $('#Name').val();
    if (supplier.Name == '') {
        swal("Invalid", "Form tidak boleh kosong", "warning");
        return false;
    } else if (supplier.Name == $('#NameOld').val()) {
        swal("Invalid", "Isian Tidak Boleh Sama", "warning");
        return false;
    }
    else {
        $.ajax({
            url: 'http://localhost:1349/api/Suppliers/' + $('#Id').val(),
            data: supplier,
            type: 'PUT',
            dataType: 'json',
            success: function (result) {
                LoadIndexSupplier();
                $('#myModal').modal('hide');
                $('#Name').val('');
                $('#Id').val('');
            }
        });
    }
}
function GetById(Id) {
    $.ajax({
        url: 'http://localhost:1349/api/Suppliers/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#NameOld').val(result.Name);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    });
}

function Delete(Id){
    swal({
        title: "Are you sure?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD7B55",
        confirmButtonText: "Yes, Delete Data!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: 'http://localhost:1349/api/Suppliers/' + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted",
                    text: "Your data has been deleted.",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Suppliers/Index/';
                        //setTimeout(function () {
                        //    location.reload();
                        //}, 1200);
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "Error");
            }
        });
    });
}

function Search() {
    var jenis = new Object($('#pilih').val());
    console.log(jenis);
    if (jenis == "1") {
        var supplier = new Object($('#cari').val());
        $.ajax({
            url: 'http://localhost:1349/api/Suppliers/?name=' + supplier,
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var html = '';
                for (var i = 0; i < data.length; i++) {
                    html = html + '<tr>';

                    html = html + '<td>' + data[i].Name + '</td>';

                    html = html + '<td><button onclick="return GetById(' + data[i].Id + ')">Edit</button>';

                    html = html + '| <button onclick="return Delete(' + data[i].Id + ')">Delete</button>';

                    html = html + '</tr>';
                }
                $('#tBody').html(html);
                $("#cari").val('');
                $("#cari").attr("placeholder", "Search (Choose Find Options)");
                $("#cari").attr("title", "Search (Choose Find Options)");
                $("#pilih").val(0);
            }
        });
    } else if(jenis == "2"){
        var supplier = new Object($('#cari').val());
        $.ajax({
            url: 'http://localhost:1349/api/Suppliers/?month=' + supplier,
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var html = '';
                for (var i = 0; i < data.length; i++) {
                    html = html + '<tr>';

                    html = html + '<td>' + data[i].Name + '</td>';

                    html = html + '<td><button onclick="return GetById(' + data[i].Id + ')">Edit</button>';

                    html = html + '| <button onclick="return Delete(' + data[i].Id + ')">Delete</button>';

                    html = html + '</tr>';
                }
                $('#tBody').html(html);
                $("#cari").val('');
                $("#cari").attr("placeholder", "Search (Choose Find Options)");
                $("#cari").attr("title", "Search (Choose Find Options)");
                $("#opt1").attr("selected", "true");
            }
        });
    } else if(jenis == "0"){
        swal("Oops", "Select Find Options!");
    }
    
}

function Jenis() {
    $('#pilih').change(function () {
        var k = $(this).val();
        if (k == 1) {
            $("#cari").val('');
            $("#cari").attr("placeholder", "Search by Name");
            $("#cari").attr("title", "Search by Name");
        }
        else if (k == 2) {
            $("#cari").val('');
            $("#cari").attr("placeholder", "Search by Join Date(Input Number of Month)");
            $("#cari").attr("title", "Search by Join Date(Input Number of Month)");
        }
        else if (k == 0) {
            $("#cari").val('');
            $("#cari").attr("placeholder", "Search (Choose Find Options)");
            $("#cari").attr("title", "Search (Choose Find Options)");
        }
    });
}