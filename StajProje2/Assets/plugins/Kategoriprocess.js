$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);




        //=======================================================kategoriler islem======================================================

        /************kategori kaydet ve gucneleme Pop model*****************/
        if (mode === "KategoriGuncelle") {
            $(buton).data('url', "/PartialKategoriler/GetKategoriForm");
            formData.append("KategoriID", $(buton).data("data1"));
            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }

        /************kategori kaydet ve Guncelleme*****************/
        else if (mode === "KategoriIslem") {
            $(buton).data('url', "/kategoriler/KategoriIslem/");
            formData.append("KategoriID", $(buton).data("data1"));
            formData.append("type", "Kaydet");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        //alert_v1("Bilgi", result.split("|")[1], function () { });
                        //$('#hoca_yabanciDil_datatable').DataTableT(hoca_yabanciDil_getir);
                        //$("#mdl").modal("hide");
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        /************kategori sil pop modal*****************/
        else if (mode === "KategoriSil") {
            $(buton).data('url', "/PartialKategoriler/GetKategoriSil/");
            ButtonExecute("modal", "#", buton, formData, function () {
            }, function () { }, "true", "#");
        }
        /************kategori sil *****************/
        else if (mode === "KategoriSilTamamla") {
            $(buton).data('url', "/kategoriler/KategoriIslem/");
            formData.append("KategoriID", $(buton).data("data1"));
            formData.append("type", "Sil");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");

            }

        }


    });

});




