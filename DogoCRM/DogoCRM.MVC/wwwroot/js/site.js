function convertFirstlettertoUppercase(text) {

    return text.charAt(0).toUpperCase() + text.slice(1);
}

function toastSettings() {

    toastr.options = {
        "debug": false,
        "positionClass": "toast-bottom-full-width",
        "onclick": null,
        "fadeIn": 300,
        "fadeOut": 1000,
        "timeOut": 5000,
        "extendedTimeOut": 1000
    }
}


function convertoShortDate(datestring) {

    const shortdate = new Date(datestring).toLocaleDateString('tr-TR');

    return shortdate;
}