//https://codeseven.github.io/toastr/demo.html toastr demo sayfa

function errorMes(message, errorTitle) {
    toastr.error(message, errorTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function sucMess(message, sucTitle) {
    toastr.success(message, sucTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function warMess(message, warTitle) {
    toastr.warning(message, warTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};


function LoginControl() {
    var bilgi = {
        UserName: $("#UserName").val(),
        Password: $("#Pass").val(),
    }
    $.ajax({
        url: "/Login/LoginControl",
        type: "post",
        data: bilgi,
        success: function (e) {
            if (e != true) {
                errorMes("Kullanıcı Adı veya Parola Hatalı", "HATA!");
                setInterval(function () {
                    window.location.replace("/");
                }, 1000);
            }
            else {
                sucMess(bilgi.UserName, "Hoşgeldin");
                setInterval(function () {
                    window.location.replace("/Home/Index");
                }, 1000);
            }
        }
    });
}

function CustomerSearch() {
    var bilgi = {
        Phone: $("#searchPhone").val()
    };
    $.ajax({
        url: "/Customer/Search",
        type: "post",
        data: bilgi,
        success: function (e) {
            if (e != false) {
                $("#CustomerStatus").html("");
                $("#CustomerStatus").removeClass("text-success");
                $("#CustomerStatus").removeClass("text-danger");
                $("#CustomerStatus").removeAttr("hidden");
                $("#CustomerNameLast").val(e.FirstName + " " + e.LastName);
                $("#FirstName").val(e.FirstName);
                $("#LastName").val(e.LastName);
                $("#Phone").val(e.Phone);
                $("#Email").val(e.Email);
                $("#CustomerID").val(e.ID);
                $("#CustomerNameLast").attr("disabled", "disabled");
                $("#Phone").attr("disabled", "disabled");
                $("#Email").attr("disabled", "disabled");
                $("#CustomerStatus").addClass("text-success");
                $("#CustomerStatus").html("Müşteri Daha Önce Eklenmiş");
                $("#kaydet").removeAttr("disabled");

            }
            else {
                $("#CustomerStatus").html("");
                $("#CustomerStatus").removeClass("text-success");
                $("#CustomerStatus").removeClass("text-danger");
                $("#CustomerStatus").removeAttr("hidden");
                $("#CustomerNameLast").val("");
                $("#Phone").val("");
                $("#Email").val("");
                $("#CustomerID").val("");
                $("#FirstName").val("");
                $("#LastName").val("");
                $("#CustomerNameLast").removeAttr("disabled");
                $("#Phone").removeAttr("disabled");
                $("#Email").removeAttr("disabled");
                $("#CustomerStatus").addClass("text-danger");
                $("#CustomerStatus").html("Müşteri Daha Önce Eklenmemiş");
                $("#kaydet").attr("disabled", "disabled");
            }
        }
    })
}

function BarcodeSearch() {
    var bilgi = {
        Barcode: $("#productBarcode").val()
    };
    $.ajax({
        url: "/Product/BarcodeSearch",
        type: "post",
        data: bilgi,
        success: function (e) {
            if (e != false) {
                if (e.Stock > 0) {
                    $("#StockStatus").html("");
                    $("#StockStatus").removeAttr("hidden");
                    $("#StockStatus").removeClass("text-danger");
                    $("#StockStatus").removeClass("text-success");
                    $("#StockStatus").addClass("text-success");
                    $("#StockStatus").html("Mevcut Stok Durumunuz" + e.Stock);
                    $("#ProductName").attr("disabled", "disabled");
                    $("#CategoryName").attr("disabled", "disabled");
                    $("#SellPrice").attr("disabled", "disabled");
                    $("#Stock").attr("disabled", "disabled");
                    $("#ProductName").val(e.ProductName);
                    $("#CategoryName").val(e.CategoryName);
                    $("#ProductID").val(e.ID);
                    $("#SellPrice").val(e.SellPrice);
                    $("#Stock").val(e.Stock);
                }
                else {
                    $("#StockStatus").html("");
                    $("#StockStatus").removeAttr("hidden");
                    $("#StockStatus").removeClass("text-danger");
                    $("#StockStatus").removeClass("text-success");
                    $("#StockStatus").addClass("text-danger");
                    $("#StockStatus").html("Mevcut Stok Durumunuz Satışa Uygun Değil " + e.Stock);
                    $("#ProductName").attr("disabled", "disabled");
                    $("#CategoryName").attr("disabled", "disabled");
                    $("#SellPrice").attr("disabled", "disabled");
                    $("#Stock").attr("disabled", "disabled");
                    $("#ProductName").val(e.ProductName);
                    $("#CategoryName").val(e.CategoryName);
                    $("#ProductID").val(e.ID);
                    $("#SellPrice").val(e.SellPrice);
                    $("#Stock").val(e.Stock);
                }
            }
            else {
                $("#StockStatus").html("");
                $("#StockStatus").removeAttr("hidden");
                $("#StockStatus").removeClass("text-danger");
                $("#StockStatus").removeClass("text-success");
                $("#StockStatus").addClass("text-danger");
                $("#StockStatus").html("Ürün Bulunamadı !");
                $("#ProductName").attr("disabled", "disabled");
                $("#CategoryName").attr("disabled", "disabled");
                $("#SellPrice").attr("disabled", "disabled");
                $("#Stock").attr("disabled", "disabled");
                $("#ProductName").val("");
                $("#CategoryName").val("");
                $("#SellPrice").val("");
                $("#Stock").val("");
            }
        }
    })
}

function EmployeeGet(id) {
    $.get("/Employee/UpdateJS?id=" + id, function (result) {
        if (result.Status == true) {
            $("#ID").val(result.Data.ID);
            $("#FirstName").val(result.Data.FirstName);
            $("#LastName").val(result.Data.LastName);
            $("#Phone").val(result.Data.Phone);
            $("#Adress").html(result.Data.Adress);
            $("#Email").val(result.Data.Email);
            $("#PhotoURL").attr("src", result.Data.ImageURL);
        }
        else {
            errorMes("Kişi Bulunamadı", "Hata");
        }
    })
}

function CustomerJSUpdate(id) {
    $.get("/Customer/UpdateJS?id=" + id, function (result) {
        if (result.Status == true) {
            $("#ID").val(result.Data.ID);
            $("#FirstName").val(result.Data.FirstName);
            $("#LastName").val(result.Data.LastName);
            $("#Phone").val(result.Data.Phone);
            $("#Adress").html(result.Data.Adress);
            $("#Email").val(result.Data.Email);
        }
    })
}