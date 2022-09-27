





//document.getElementById('cryptoform').addEventListener("submit", function (e) {
//    e.preventDefault();
//    // do something'

//    let crypto = document.getElementById("coin").value;
//    let Acc = document.getElementById("acc").value;

//    let Qty = document.getElementById("quantity").value;


//    var data =
//    {
//        coin: crypto,
//        account: Acc,
//        amount: Qty
//    }

//    createbitcoin(data);
//})



document.getElementById('emailform').addEventListener("submit", function (e)
{
    e.preventDefault();

    // do something'

    let email = document.getElementById("mail").value;
    let heading = document.getElementById("subject").value;

    let message = document.getElementById("body").value;


    var data =
    {
        mail: email,
        subject: heading,
        body: message
    }

    createemail(data);
})

document.getElementById('smsform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    var numz = document.getElementById("num").value;
    let smss = document.getElementById("sms").value;


    var data =
    {
        num: numz,
        sms: smss
    }

    createsms(data);
})




document.getElementById('wifiform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let pass = document.getElementById("password").value;
    let networks = document.getElementById("network").value;
    let types = document.getElementById("type").value;



    var data =
    {
        network: networks,
        password: pass,
        type: types
    }

    createwifi(data);
})


document.getElementById('textform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let tt = document.getElementById("TEXT").value;


    var data = $("#TEXT").serialize();
    console.log(data)

    alert(data);
    createtext(data);

})


document.getElementById('urlform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let tt = document.getElementById("URL").value;


    var data = $("#URL").serialize();
    console.log(data)


    document.getElementById("urlform").reset();
    createurl(data);

})



function createsms(obj)
{
    $.ajax({

        type: 'Post',
        url: "/Home/createsmsqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data)
        {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#smsqrshow").html(data)
        }

    });

}


function createwifi(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/createwifiqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#wifiqrshow").html(data)
        }

    });

}

function createurl(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/createurlqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#urlqrshow").html(data)
        }

    });

}

function createtext(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/createtextqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#textqrshow").html(data)
        }

    });

}

function createemail(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/createemailqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#emailqrshow").html(data)
        }

    });

}

function createbitcoin(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/createbitcoinqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#bitcoinqrshow").html(data)
        }

    });

}



document.getElementById('imageform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    var input = document.getElementById("postedFiles"); //get file input id


    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }

    uploadFiles(formData);

})




function uploadFiles(obj) {

    $.ajax(
        {
            url: "/Home/AjaxUpload",
            data: obj, // send it as formData
            processData: false,// tell jQuery not to process the data
            contentType: false,// tell jQuery not to set contentType
            type: "POST", //type is post as we will need to post files
            success: function (data) {
                alert("Files Uploaded!" + data);
            }
        }
    );
}
