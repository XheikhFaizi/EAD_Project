





document.getElementById('factorycryptoform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let crypto = document.getElementById("coin").value;
    let Acc = document.getElementById("acc").value;

    let Qty = document.getElementById("quantity").value;


    let color = document.getElementById("BColor").value;


    var input = document.getElementById("BpostedFiles"); //get file input id
    console.log(input)

    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }


    formData.append("file", files[0]);
    formData.append("Color", color);

    formData.append("coin", crypto);
    formData.append("account", Acc);
    formData.append("amount", Qty);



    factorycreatebitcoin(formData);
})

function factorycreatebitcoin(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/factorycreatebitcoinqr",
        data: obj,
        processData: false,// tell jQuery not to process the data
        contentType: false,// tell jQuery not to set contentType
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#factorybitcoinqrshow").html(data)
        }

    });

}


document.getElementById('factoryemailform').addEventListener("submit", function (e)
{
    e.preventDefault();

    // do something'



    let email = document.getElementById("mail").value;
    let heading = document.getElementById("subject").value;

    let message = document.getElementById("body").value;

    let color = document.getElementById("EColor").value;


    var input = document.getElementById("EpostedFiles"); //get file input id
    console.log(input)

    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }


    formData.append("file", files[0]);
    formData.append("Color", color);
    formData.append("email", email);
    formData.append("subject", heading);
    formData.append("body", message);



    factorycreateemail(formData);
})


document.getElementById('factorysmsform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    var numz = document.getElementById("num").value;
    let smss = document.getElementById("sms").value;


    let color = document.getElementById("SColor").value;


    var input = document.getElementById("SpostedFiles"); //get file input id
    console.log(input)

    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }


    formData.append("file", files[0]);
    formData.append("Color", color);

    formData.append("num", numz);
    formData.append("sms", smss);

   

    factorycreatesms(formData);
})




document.getElementById('factorywifiform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let pass = document.getElementById("password").value;
    let networks = document.getElementById("network").value;
    let types = document.getElementById("type").value;

    let color = document.getElementById("WColor").value;


    var input = document.getElementById("WpostedFiles"); //get file input id
    console.log(input)

    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }


    formData.append("file", files[0]);
    formData.append("Color", color);

    formData.append("network", networks);
    formData.append("password", pass);
    formData.append("type", types);


    factorycreatewifi(formData);
})


document.getElementById('factorytextform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let tt = document.getElementById("TEXT").value;

    let color = document.getElementById("TColor").value;
   

    var input = document.getElementById("TpostedFiles"); //get file input id
    console.log(input)

    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }


    formData.append("file", files[0]);
    formData.append("Color", color);
 

    formData.append("TEXT", tt);
    console.log(formData)
  
    factorycreatetext(formData);

})


document.getElementById('factoryurlform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let tt = document.getElementById("URL").value;


    let color = document.getElementById("Color").value;

    var input = document.getElementById("postedFiles"); //get file input id
  

    var files = input.files; //get files
    var formData = new FormData(); //create form

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]); //loop through all files and append
    }


    formData.append("file", files[0]);
    formData.append("Color", color);


    formData.append("URL", tt);

    console.log(formData)

    factorycreateurl(formData);

})


function factorycreateurl(obj) {
    
    $.ajax({

        type: 'Post',
        url: "/Home/factorycreateurlqr",
        data: obj,
        processData: false,// tell jQuery not to process the data
        contentType: false,// tell jQuery not to set contentType
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#factoryurlqrshow").html(data)
        }

    });

}



function factorycreatetext(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/factorycreatetextqr",
        data: obj,
        processData: false,// tell jQuery not to process the data
        contentType: false,// tell jQuery not to set contentType
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#factorytextqrshow").html(data)
        }

    });

}


function factorycreatewifi(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/factorycreatewifiqr",
        data: obj,
        processData: false,// tell jQuery not to process the data
        contentType: false,// tell jQuery not to set contentType
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#factorywifiqrshow").html(data)
        }

    });

}










function factorycreatesms(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/factorycreatesmsqr",
        data: obj,
        processData: false,// tell jQuery not to process the data
        contentType: false,// tell jQuery not to set contentType
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#factorysmsqrshow").html(data)
        }

    });

}








function factorycreateemail(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/factorycreateemailqr",
        data: obj,
        processData: false,// tell jQuery not to process the data
        contentType: false,// tell jQuery not to set contentType
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#factoryemailqrshow").html(data)
        }

    });

}





//document.getElementById('imageform').addEventListener("submit", function (e) {
//    e.preventDefault();
//    // do something'

//    var input = document.getElementById("postedFiles"); //get file input id


//    var files = input.files; //get files
//    var formData = new FormData(); //create form

//    for (var i = 0; i != files.length; i++) {
//        formData.append("files", files[i]); //loop through all files and append
//    }

//    uploadFiles(formData);

//})




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
