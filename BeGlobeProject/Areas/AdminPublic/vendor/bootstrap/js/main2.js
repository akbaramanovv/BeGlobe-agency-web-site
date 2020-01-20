$(document).ready(function () {
    $('#change-password').on('click', function (e) {

        validate();
      
           
         
    })
  
  
})

function validate() {
    console.log('salam')
    if ($('#name').val() == '') {
        $('#nameerr').show();
        $('#nameerr').text('bos olmamalidir');
    } else {
        $('#nameerr').hide();
    }
    if ($('#old').val() == '') {
        $('#oldErr').show();
        $('#oldErr').text('bos olmamalidir');
    } else {
        $('#oldErr').hide();
    }
    if ($('#old').val() != '' && $('#name').val() != '' && $('#newVal').val() != '' ) {
        var old = $('#old').val();
        var newVal = $('#newVal').val();
        var name = $('#name').val();
        $.ajax({

            url: '/AdminHome/ChangePassword',
            method: 'POST',
            data: { 'old': old, 'newPass': newVal, 'name': name },
            success: function (equal) {

                if (equal == "True") {
                    $('#oldErr').hide();
                    $('#oldErr').text('');
                    alert("Parolunuzu deyisdirdiniz !");
                    window.location.replace("/Admin/AdminHome/Index");

                } else {
                    console.log('else ' + equal);

                    $('#loaderImg').hide();
                    $('#oldErr').show();
                    $('#oldErr').text('Parol düzgün deyil !');
                }

            }
        })
       
    }
    if ($('#newVal').val() == '') {
        $('#newErr').show();
        $('#newErr').text('bos olmamalidir');
    } else {
        
        $('#newErr').hide();
    }
}
//$('#changePassword').validate({
//    rules: {
//        name: {
//            required: true,
//        },
//        oldPassword: {
//            required: true,
//        },
//        newPassword: {
//            required: true,
//            minlength: 7
//        }
//    },
//    messages: {
//        name: {
//            required: 'Bu sahə boş buraxıla bilməz !',

//        },
//        oldPassword: {
//            required: 'Bu sahə boş buraxıla bilməz !'
//        },
//        newPassword: {
//            required: 'Bu sahə boş buraxıla bilməz !',
//            minlength: 'Şifrədə minimal uzunluğu 7 olmalıdır !'
//        }

//    },
//    submitHandler: function () {
//        var newVal = $('#newVal').val();
//        var name = $('#name').val();

//        $.ajax({

//            url: '/AdminHome/ChangePassword',
//            method: 'POST',
//            data: { 'old': old, 'newPass': newVal, 'name': name },
//            success: function (response) {
//                $('#loaderImg').show();
//                if (response == false) {
//                    $('#loaderImg').hide();
//                    $('#err').text('Parol düzgün deyil');
//                } else {

//                    $('#loaderImg').hide();
//                    $('#err').text('Parol düzgün deyil');
//                }

//            }
//        })
//    }
//})