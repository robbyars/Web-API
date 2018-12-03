LoadIndexSupplier();
getSup();

function LoadIndexSupplier(){
        $.ajax({
            url: 'http://localhost:1349/api/Items',
            dataType: 'json',
            type: 'GET',
            success: function (data) {
                var html = '';
                for (var i = 0; i < data.length; i++) {
                    html = html + '<tr>';
                    
                    html = html + '<td>' + data[i].Name + '</td>';

                    html = html + '<td>' + data[i].Price + '</td>';

                    html = html + '<td>' + data[i].Stock + '</td>';

                    html = html + '<td>' + data[i].Supplier + '</td>';

                    html = html + '<td><button onclick="return GetById(' + data[i].Id + ')">Edit</button>';

                    html = html + '| <button onclick="return Delete(' + data[i].Id +')">Delete</button>';
                    
                    html = html + '</tr>';
                }
                $('#tBody').html(html);
            }

    });
}

function getSup() {
    $.ajax({
        url: 'http://localhost:1349/api/Suppliers',
        //dataType: 'json',
        type: 'GET',
        success: function (result) {
            var Supplier = $("#Supplier");
            $.each(result, function (i, supplier) {
                $("<option></option>").val(supplier.Id).text(supplier.Name).appendTo(Supplier);
            });
        }

    });
}

function Save() {
    var supplier = new Object();
    supplier.name = $('#Name').val();
    supplier.price = $('#Price').val();
    supplier.stock = $('#Stock').val();
    supplier.supplier = $('#Supplier').val();
    if (supplier.name == '') {
        swal("Invalid", "Isi Form sesuai Data", "warning");
        return false;
    } else if (supplier.price == '') {
        swal("Invalid", "Isi Form sesuai Data", "warning");
        return false;
    } else if (supplier.stock == '') {
        swal("Invalid", "Isi Form sesuai Data", "warning");
        return false;
    } else if (supplier.supplier == null) {
        swal("Invalid", "Isi Form sesuai Data", "warning");
        return false;
    }
    else {
        $.ajax({
            url: 'http://localhost:1349/api/Items',
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
    $('#Price').val('');
    $('#Stock').val('');
    $('#Supplier').val('');
    $('#Save').show();
    $('#Update').hide();
}

function Edit() {
    var supplier = new Object();
    supplier.Id = $('#Id').val();
    supplier.Name = $('#Name').val();
    supplier.Price = $('#Price').val();
    supplier.Stock = $('#Stock').val();
    supplier.Supplier = $('#Supplier').val();
    if (supplier.Name == '') {
        swal("Invalid", "Form tidak boleh kosong", "warning");
        return false;
    } else if (supplier.Price == '') {
        swal("Invalid", "Form tidak boleh kosong", "warning");
        return false;
    } else if (supplier.Stock == '') {
        swal("Invalid", "Form tidak boleh kosong", "warning");
        return false;
    } else if (supplier.Supplier == '') {
        swal("Invalid", "Form tidak boleh kosong", "warning");
        return false;
    } 
    else {
        $.ajax({
            url: 'http://localhost:1349/api/Items/' + $('#Id').val(),
            data: supplier,
            type: 'PUT',
            dataType: 'json',
            success: function (result) {
                LoadIndexSupplier();
                $('#myModal').modal('hide');
                $('#Name').val('');
                $('#Id').val('');
                $('#Price').val('');
                $('#Stock').val('');
                $('#Supplier').val('');
            }
        });
    }
}
function GetById(Id) {
    $.ajax({
        url: 'http://localhost:1349/api/Items/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#NameOld').val(result.Name);
            $('#Price').val(result.Price);
            $('#PriceOld').val(result.Price);
            $('#Stock').val(result.Stock);
            $('#StockOld').val(result.Stock);
            $('#Supplier').val(result.Supplier);
            $('#SupplierOld').val(result.Supplier);
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
            url: 'http://localhost:1349/api/Items/' + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted",
                    text: "Your data has been deleted.",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Items/Index/';
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
    debugger;
    var item = new Object($('#cari').val());
    var searchby = new Object($('#searchby').val());
    console.log(item);
    $.ajax({
        url: 'http://localhost:1349/api/Items/Search/?name='+item+'&&search='+searchby,
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            var html = '';
            for (var i = 0; i < data.length; i++) {
                html = html + '<tr>';

                html = html + '<td>' + data[i].Name + '</td>';

                html = html + '<td>' + data[i].Price + '</td>';

                html = html + '<td>' + data[i].Stock + '</td>';

                html = html + '<td>' + data[i].Supplier + '</td>';

                html = html + '<td><button onclick="return GetById(' + data[i].Id + ')">Edit</button>';

                html = html + '| <button onclick="return Delete(' + data[i].Id + ')">Delete</button>';

                html = html + '</tr>';
            }
            $('#tBody').html(html);
        }

    });
}