$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);
        //=======================================================urunler islem======================================================


        /************urunler kaydet ve gucneleme Pop model*****************/
        if (mode === "UrunGuncelle") {
            $(buton).data('url', "/PartialUrun/GetUrunForm");
            formData.append("UrunID", $(buton).data("data1"));
            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }



        /************urunler kaydet ve gucneleme islem*****************/
        else if (mode === "UrunIslem") {
            $(buton).data('url', "/Urunler/UrunIslem/");
            formData.append("UrunID", $(buton).data("data1"));
            formData.append("type", "Kaydet");

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



        /************urunler sil pop modal*****************/
        else if (mode === "UrunSil") {
            $(buton).data('url', "/PartialUrun/GetUrunSil/");
            ButtonExecute("modal", "#", buton, formData, function () {
            }, function () { }, "true", "#");
        }

        /************urun sil *****************/
        else if (mode === "UrunSilTamamla") {
            $(buton).data('url', "/Urunler/UrunIslem/");
            formData.append("UrunID", $(buton).data("data1"));
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