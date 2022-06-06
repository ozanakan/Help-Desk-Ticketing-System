$(document).ready(function () {
    $('#companyTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd"
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                    /*  alert('Ekle Butonuna Basıldı');*/
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        /*   url: '@Url.Action("GetAllArea", "Area")',*/
                        url: '/Admin/Company/GetAllCompany/',
                        contentType: "application/json",
                        //beforeSend işlemi ajax işlemini yapmadan önce yapıcaklarımızı belirttiğimiz bölüm
                        beforeSend: function () {
                            $('#companyTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const companyListDto = jQuery.parseJSON(data);
                            if (companyListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(companyListDto.Companies.$values,
                                    function (index, company) {
                                        tableBody += `
                                        <tr>
                                            <td>${company.Id}</td>
                                            <td>${company.Name}</td>
                                             <td>
                                                <button class="btn btn-info btn-sm btn-update" data-id="${company.Id}"><span class="fas fa-edit"></span>Update</button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${company.Id}"><span class="fas fa-minus-circle"></span>Delete</button>
                                            </td>
                                         </tr>`;
                                    });
                                $('#companyTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#companyTable').show();
                            } else {
                                toastr.error(`${companyListDto.Message}`, 'Exception');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#companyTable').fadeIn(1000);
                            toastr.error(`${err.statusText}`, 'Exception');
                        }
                    });
                }
            }
        ]
    });

    $(function () {
        /*       const url = '@Url.Action("Add", "Area")';*/
        const url = '/Admin/Company/Add/';
        const placeHolderDiv = $('#modelPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-company-add');
                /* const actionUrl = form.attr('action');*/
                const dataToSend = form.serialize();
                $.post('/Admin/Company/Add/', dataToSend).done(function (data) {
                    const companyAddAjaxModel = jQuery.parseJSON(data);
                    const newFromBody = $('.modal-body', companyAddAjaxModel.CompanyAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFromBody);
                    const isValid = newFromBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                         <tr name="${companyAddAjaxModel.CompanyDto.Company.Id}">
                                            <td>${companyAddAjaxModel.CompanyDto.Company.Id}</td>
                                            <td>${companyAddAjaxModel.CompanyDto.Company.Name}</td>
                                            <td>
                                                <button class="btn btn-info btn-sm btn-update" data-id="${companyAddAjaxModel.CompanyDto.Company.Id}"><span class="fas fa-edit"></span>Güncelle</button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${companyAddAjaxModel.CompanyDto.Company.Id}"><span class="fas fa-minus-circle"></span>Kayıt Sil</button>
                                            </td>
                                         </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#companyTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(2000);
                        toastr.success(`${companyAddAjaxModel.AreaDto.Message}`, 'Başarılı İşlem');
                    } //``
                    else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });

    });


    $(document).on('click',
        '.btn-delete',
        function (event) { //sayfa üzerinde tıklama yakalıyoruz
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
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
                        type: 'POST',
                        dataType: 'json',
                        data: { companyId: id },
                        /* url: '@Url.Action("Delete", "Area")',*/
                        url: '/Admin/Company/Delete/',
                        success: function (data) {
                            const result = jQuery.parseJSON(data);
                            if (result.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    'Your file has been deleted.',
                                    'success'
                                );

                                tableRow.fadeOut(2000);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops',
                                    text: `${result.Message}`
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, 'Exception');
                        }
                    });
                }
            });
        });

    $(function () {
        const url = '/Admin/Company/Update/';
        const placeHolderDiv = $('#modelPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { areaId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Exception");
                });
            });

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();
                const form = $('#form-company-update');
                /* const actionUrl = form.attr('action');*/
                const dataToSend = form.serialize();
                $.post('/Admin/Company/Update/', dataToSend).done(function (data) {
                    const companyUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(companyUpdateAjaxModel);
                    const newFormBody = $('.modal-body', companyUpdateAjaxModel.CompanyUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                         <tr name="${companyUpdateAjaxModel.CompanyDto.Company.Id}">
                                            <td>${companyUpdateAjaxModel.CompanyDto.Company.Id}</td>
                                            <td>${companyUpdateAjaxModel.CompanyDto.Company.Name}</td>
                                            <td>
                                                <button class="btn btn-info btn-sm btn-update" data-id="${companyUpdateAjaxModel.CompanyDto.Company.Id}"><span class="fas fa-edit"></span>Güncelle</button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${companyUpdateAjaxModel.CompanyDto.Company.Id}"><span class="fas fa-minus-circle"></span>Kayıt Sil</button>
                                            </td>
                                         </tr>`;
                        const newTableRowObject = $(newTableRow);
                        const areaTableRow = $(`[name="${companyUpdateAjaxModel.CompanyDto.Company.Id}"]`);
                        /*  areaTableRow.replaceWith(newTableRowObject);*/
                        newTableRowObject.hide();
                        areaTableRow.replaceWith(newTableRowObject);
                        newTableRowObject.fadeIn(2000);
                        toastr.success(`${companyUpdateAjaxModel.CompanyDto.Message}`, "Success");
                    } else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function (response) {
                    console.log(response);
                });
            });
    });


});

