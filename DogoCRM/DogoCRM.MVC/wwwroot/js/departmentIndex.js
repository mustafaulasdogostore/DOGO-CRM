$(document).ready(function () {


    $('#datatable').DataTable();

    toastSettings();

    const placeholderDiv = $('#modalPlaceHolder');

    //.CORE tarafından çalışır ancak javascripte syntax tanımaz
    /*    const url = '@Url.Action("Add","Department")';*/

    const url = '/Admin/Department/Add';


    $('#btnEkle').click(function () {

        //It goes add action and get departmentaddpartial and return partial in htmls
        $.get(url).done(function (data) {

            placeholderDiv.html(data);
            //ıt finds modal class and makes modal to open regularly
            placeholderDiv.find(".modal").modal('show');

        })

    });
    //modal daha gelmediği oluşmadığı için çalışcağı div üzerindeki eventi belirledik
    placeholderDiv.on('click', '#btnSave', function (event) {

        ////önlem submit butonu ise enellemek için
        event.preventDefault();
        const form = $('#form-department-add');
        //asp-action vermiştik form'a bu bir url üretir ve URL'i aldık,yani bu form hangi url'e post edilmeli
        const actionUrl = form.attr('action');
        //gönderilecek veriiyi serileştirerek almış olduk.
        const dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {

            console.log("action :" + actionUrl);
            const departmentAddAjaxModel = $.parseJSON(data);

            //amacımız mevcut modal-body ile partialViewden gelen modal-body 'yi değiştirmek çünkü eğer hatalı bir giriş varsa validasyonu slamak ve göstermek
            //DepartmentAddPartial kısımından modal-body kısımını alıyoruz sadece
            const newFormBody = $('.modal-body', departmentAddAjaxModel.DepartmentAddPartial);

            placeholderDiv.find('.modal-body').replaceWith(newFormBody);
            const isvalid = newFormBody.find('[name="IsValid"]').val() === 'True';

            console.log(departmentAddAjaxModel.DepartmentDto);

            const validateul = $('#validation-summary ').children().children().text();


            console.log("Gelen hata:" + validateul);

            //isvalid true ise demek ki başarı ile post gerçekleşmiştir.
            if (isvalid && validateul.length === 0) {
                console.log("evet is valid ve lengt=0");
                placeholderDiv.find('.modal').modal('hide');

                //string literal oluşturmak için altgr'ye basılı tut noktalı virgüle 2 kez bas.stringlerimizi formatlamak için kullanırız
                const newTableRow = `
                             <tr  name='${departmentAddAjaxModel.DepartmentDto.Department.Id}'>
                                <td>${departmentAddAjaxModel.DepartmentDto.Department.Id}</td>
                                <td>${departmentAddAjaxModel.DepartmentDto.Department.Name}</td>
                                <td>${convertoShortDate(departmentAddAjaxModel.DepartmentDto.Department.ModifiedDate)}</td>
                                <td>
                                    <button class='btn btn-primary btn-sm btn-update' data-id='${departmentAddAjaxModel.DepartmentDto.Department.Id}'>Edit</button>
                                    <button class='btn btn-danger btn-sm btn-delete' data-id='${departmentAddAjaxModel.DepartmentDto.Department.Id}'>Delete</button>
                                </td>
                            </tr>`


                const newTableRowObject = $(newTableRow);

                newTableRowObject.hide();

                $('#dataTable').append(newTableRowObject);

                newTableRowObject.fadeIn(3500);


                toastr.success(`${departmentAddAjaxModel.DepartmentDto.Message}`, 'Successfull Transaction !')
            }

            else {
                //is valid false alanı

                let summaryText = "";
                $('#validation-summary > ul > li').each(function () {
                    let text = $(this).text();
                    summaryText = `*${text}\n`;
                });
                toastr.warning(summaryText);


            }

        })


    });



    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');

        Swal.fire({
            title: 'Are you sure?',
            text: "The Department will deleted",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes,I want to Delete it.',
            cancelButtonText: 'No, I do not.'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { departmentId: id },
                    url: '/Admin/Department/Delete/',
                    success: function (data) {
                        const result = jQuery.parseJSON(data);
                        if (result.ResultStatus === 0) {
                            Swal.fire(
                                'Deleted!',
                                'The Department has Successfully Deleted.',
                                'success'
                            );
                            const tableRow = $(`[name="${id}"]`);
                            tableRow.fadeOut(3500);
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Somethink Wrong!',
                                text: `${result.Message}`,
                            });
                        }
                    },
                    error: function (err) { console.log(err); }
                })
            }
        })


    });

    $(function () {
        //ajax get the department to edit
        const url = '/Admin/Department/Update';
        const placeHolderDiv=$('#modalPlaceHolder')
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();

            const id = $(this).attr('data-id');
            $.get(url, { departmentId: id }).done(function (data) {

                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');


            }).fail(function (err) {
                toastr.error("There is somethink error");
            })
        })




        //update post

        //ajax post to update department
        //btnUpdate açılan modaldaki update butonudur.
        placeholderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();

            const form = $('#form-department-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {

                const departmentUpdateAjaxModel = $.parseJSON(data);
                console.log("gelen deparmentajax:" + departmentUpdateAjaxModel.DepartmentDto.Message);

                const newFormBody = $('.modal-body', departmentUpdateAjaxModel.DepartmentUpdatePartial);
                //eski form body placeholderdiv de yerdeğiştirmek için
                placeholderDiv.find('.modal-body').replaceWith(newFormBody);

                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True'

                if (isValid) {

                    placeholderDiv.find('.modal').modal('hide');

                    const newTableRow = `
                             <tr  name='${departmentUpdateAjaxModel.DepartmentDto.Department.Id}'>
                                <td>${departmentUpdateAjaxModel.DepartmentDto.Department.Id}</td>
                                <td>${departmentUpdateAjaxModel.DepartmentDto.Department.Name}</td>
                                <td>${convertoShortDate(departmentUpdateAjaxModel.DepartmentDto.Department.ModifiedDate)}</td>
                                <td>
                                    <button class='btn btn-primary btn-sm btn-update' data-id='${departmentUpdateAjaxModel.DepartmentDto.Department.Id}'>Edit</button>
                                    <button class='btn btn-danger btn-sm btn-delete' data-id='${departmentUpdateAjaxModel.DepartmentDto.Department.Id}'>Delete</button>
                                </td>
                            </tr>`

                    const newTableRowObject = $(newTableRow);
                    //eski department
                    const departmentTableRow = $(`[name="${departmentUpdateAjaxModel.DepartmentDto.Department.Id}"]`);

                    departmentTableRow.hide();
                    departmentTableRow.replaceWith(newTableRowObject);
                    departmentTableRow.fadeIn(3500);

                    toastr.success(`${departmentUpdateAjaxModel.DepartmentDto.Message}`, "The Transaction is Success!");
                }
                else {
                    toastr.error(`${departmentUpdateAjaxModel.DepartmentDto.Message}`, "Trouble !!");
                }

            }).fail(function (response) {
                console.log("hata"+ response);
            });



        });


    });







});