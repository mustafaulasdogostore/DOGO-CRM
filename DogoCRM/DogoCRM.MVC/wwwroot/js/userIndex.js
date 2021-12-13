$(document).ready(function () {


    const dataTable = $('#datatable').DataTable({
        drawCallback: function () {
            console.log('drawCallback');
        }

    });

    toastSettings();

    const placeholderDiv = $('#modalPlaceHolder');

    //.CORE tarafından çalışır ancak javascripte syntax tanımaz
    /*    const url = '@Url.Action("Add","Department")';*/

    const url = '/Admin/User/Add';


    $('#btnEkle').click(function () {

        //It goes add action and get useraddpartial and return partial in htmls
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
        const form = $('#form-user-add');
        //asp-action vermiştik form'a bu bir url üretir ve URL'i aldık,yani bu form hangi url'e post edilmeli
        const actionUrl = form.attr('action');
        //gönderilecek veriiyi serileştirerek almış olduk.
        const dataToSend = new FormData(form.get(0));

       

        $.ajax({
            url: actionUrl,
            type: 'POST',
            data: dataToSend,
            processData: false,
            contentType:false,
            success: function (data) {

             

                const userAddAjaxModel = $.parseJSON(data);

                //amacımız mevcut modal-body ile partialViewden gelen modal-body 'yi değiştirmek çünkü eğer hatalı bir giriş varsa validasyonu slamak ve göstermek
                //DepartmentAddPartial kısımından modal-body kısımını alıyoruz sadece
                const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);

                placeholderDiv.find('.modal-body').replaceWith(newFormBody);
                const isvalid = newFormBody.find('[name="IsValid"]').val() === 'True';

                console.log(userAddAjaxModel.UserDto);

                const validateul = $('#validation-summary ').children().children().text();


                console.log("Gelen hata:" + validateul);

                //isvalid true ise demek ki başarı ile post gerçekleşmiştir.
                if (isvalid && validateul.length === 0) {
                    console.log("evet is valid ve lengt=0");
                    placeholderDiv.find('.modal').modal('hide');

                    dataTable.draw();

                    dataTable.on('draw', function () {
                        console.log("draw çalıştı");
                    });
                   

                    toastr.success(`${userAddAjaxModel.UserDto.Message}`, 'Successfull Transaction !')
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
            },
            error: function (err) {
                console.log(err);
            }
        })


    });

    function drawTable(userAddAjaxModel)
    {
        //dataTable.row.add([
        //    userAddAjaxModel.UserDto.User.Id,
        //    userAddAjaxModel.UserDto.User.Name,
        //    userAddAjaxModel.UserDto.User.LastName,
        //    userAddAjaxModel.UserDto.User.UserName,
        //    userAddAjaxModel.UserDto.User.Email,
        //    userAddAjaxModel.UserDto.User.DepartmentId,
        //    userAddAjaxModel.UserDto.User.Picture,
        //    userAddAjaxModel.UserDto.User.IsManager,
        //    userAddAjaxModel.UserDto.User.IsActive
        //        `$<td>
        //                        <button class="btn btn-primary btn-sm btn-update" data-id="userAddAjaxModel.UserDto.User.Id">Edit</button>
        //                        <button class="btn btn-danger btn-sm btn-delete" data-id="userAddAjaxModel.UserDto.User.Id">Delete</button>
        //                    </td>`

        //]);

    };









});