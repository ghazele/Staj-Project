function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function ButtonExecute(buttontype, formID, item, formData, successfunction_, errorfunction_, isUrlData, content_) {

    var url = "";
    if (isUrlData === "true") {
        url = $(item).data("url") + GetUrlEk(item);
    }
    else {
        url = $(item).data("url");
    }


    if (buttontype === "modal") {
        $.get(url, function (result, status) {
            $('#dvMdlDialog').html(result);
            $('#mdl').modal('show');
            successfunction_(result);
        });
    }
    if (buttontype === "partial") {
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function () {
            },
            success: function (result) {
                $(content_).html(result);
                successfunction_(result);
            },
            error: function () {
                errorfunction_();
            }
        });
    }

    else if (buttontype === "post") {
        if (!(formID === undefined || formID === '' || formID === null)) {
            $(formID + ' input').each(function () {
                if ($(this).attr('type') === 'checkbox')
                    formData.append($(this).attr('name'), $(this).is(":checked"));
                else if ($(this).attr('type') === 'radio') {
                    if (formData.get($(this).attr('name')) === null && $(this).is(":checked") === true) {
                        formData.append($(this).attr('name'), $(this).val());
                    }
                }
                else
                    formData.append($(this).attr('name'), $(this).val());
            });

            $(formID + ' textarea').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });

            $(formID + ' select').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });



            $(formID + ' input[type=file]').each(function () {
                if ($(this)[0].hasAttribute("multiple")) {//Kaan Kandemir
                    var files = $(this)[0].files;
                    for (var i = 0; i < files.length; i++) {
                        formData.append($(this).attr('name'), files[i]);
                    }
                }
                else {
                    formData.append($(this).attr('name'), $(this)[0].files[0]);
                }
            });
        }

        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function () {
                loader("show");
            },
            success: function (result) {
                //MessageBoxShow("success", "Mesajiniz Var!", "Isleminiz basariyla tamamlandi");
                loader("hide");
                successfunction_(result);
            },
            error: function (result) {
                //MessageBoxShow("error", "Mesajiniz Var!", "Isleminiz gerceklestirilirken bir hata meydana geldi");
                loader("hide");
                errorfunction_(result);
            }
        });
    }
}
function loader(mode) {
    if (mode === "show") {
        $('#preloader').css('display', 'block');
        $('#preloader').css('z-index', '99999');

        $('#wrapper').css('filter', 'alpha(opacity=100)');
        $('#wrapper').css('opacity', '0.2');
    }
    else {
        $('#preloader').css('display', 'none');

        $('#wrapper').css('filter', 'none');
        $('#wrapper').css('opacity', '1');

    }
}
function GetUrlEk(item) {
    var urlEk = '';
    if (!($(item).data("data1") === undefined || $(item).data("data1") === '' || $(item).data("data1") === null)) {
        urlEk += '/' + $(item).data("data1");
    }

    if (!($(item).data("data2") === undefined || $(item).data("data2") === '' || $(item).data("data2") === null)) {
        urlEk += '/' + $(item).data("data2");
    }

    if (!($(item).data("data3") === undefined || $(item).data("data3") === '' || $(item).data("data3") === null)) {
        urlEk += '/' + $(item).data("data3");
    }

    if (!($(item).data("data4") === undefined || $(item).data("data4") === '' || $(item).data("data4") === null)) {
        urlEk += '/' + $(item).data("data4");
    }

    if (!($(item).data("data5") === undefined || $(item).data("data5") === '' || $(item).data("data5") === null)) {
        urlEk += '/' + $(item).data("data5");
    }



    return urlEk;
}
function alert_v1(title, body, successfunction_) {
    var clsIcon = "fa fa-exclamation-circle blue", clsContent = "border-blue";
    if (title === "Bilgi") {
        clsIcon = "fa fa-check-circle-o green";
        clsContent = "border-green";
    }
    else if (title === "Hata") {
        clsIcon = "fa fa-exclamation-triangle red";
        clsContent = "border-red";
    }
    else if (title === "Dikkat" || title === "Uyarı") {
        clsIcon = "fa fa-exclamation-triangle yellow";
        clsContent = "border-yellow";
    }
    else {
        clsIcon = "fa fa-exclamation-triangle blue";
        clsContent = "border-blue";
    }

    var modal = "";
    modal += "<div class=\"modal-content " + clsContent + "\">";
    modal += "    <div class=\"modal-body\">";
    modal += "        <div class=\"page-header\">";
    modal += "            <h2>";
    modal += title;
    modal += "            </h2>";
    modal += "        </div>";
    modal += "        <div class='modal-message-content'>";
    modal += "            <div class=\"row\">";
    modal += "                <div class=\"form-group col-xs-3 text-center\">";

    modal += "<i class=\"ace-icon " + clsIcon + "\" style=\"font-size:66px; \"></i>";

    modal += "                </div>";
    modal += "                <div class=\"form-group col-xs-9\">";
    modal += "                    <h4>";
    modal += body;
    modal += "                    </h4>";
    modal += "                </div>";
    modal += "            </div>";
    modal += "        </div>";
    modal += "    </div>";
    modal += "    <div class=\"modal-footer\">";
    modal += "      <button id='btnModalClose' class='btn btn-sm' data-dismiss='modal'>";
    modal += "               <i class='ace-icon fa fa-times'></i>";
    modal += "              Kapat";
    modal += "      </button>";
    modal += "    </div>";
    modal += "</div>";
    $("#dvMdlDialog").html(modal);
    $("#mdl").modal("show");

    $('#mdl').on('hidden.bs.modal', function () {
        successfunction_();
    });
}