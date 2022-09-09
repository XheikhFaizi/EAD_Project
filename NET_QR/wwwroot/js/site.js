/**
* Template Name: Ninestars - v4.7.0
* Template URL: https://bootstrapmade.com/ninestars-free-bootstrap-3-theme-for-creative/
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/


document.getElementById('cryptoform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let crypto = document.getElementById("coin").value;
    let Acc = document.getElementById("acc").value;

    let Qty = document.getElementById("quantity").value;


    var data =
    {
        coin: crypto,
        account: Acc,
        amount: Qty
    }

    createbitcoin(data);
})



document.getElementById('emailform').addEventListener("submit", function (e) {
    e.preventDefault();
    // do something'

    let email = document.getElementById("mail").value;
    let heading = document.getElementById("subject").value;

    let message = document.getElementById("body").value;


    var data =
    {
        mail: email,
        subject: heading,
        body:message
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


document.getElementById('urlform').addEventListener("submit", function (e)
{
        e.preventDefault();
        // do something'
      
        let tt = document.getElementById("URL").value;
  

        var data = $("#URL").serialize();
        console.log(data)

       
    document.getElementById("urlform").reset();
        createurl(data);

})



function createsms(obj) {
    $.ajax({

        type: 'Post',
        url: "/Home/createsmsqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#five-panel").html(data)
        }

    });

}


function createwifi(obj)
{
    $.ajax({

        type: 'Post',
        url: "/Home/createwifiqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#four-panel").html(data)
        }

    });

}

function createurl(obj)
{
    $.ajax({

        type: 'Post',
        url: "/Home/createurlqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data)
        {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#one-panel").html(data)
        }

    });

}

function createtext(obj)
{
    $.ajax({

        type: 'Post',
        url: "/Home/createtextqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#two-panel").html(data)
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
            $("#six-panel").html(data)
        }

    });

}

function createbitcoin(obj)
{
    $.ajax({

        type: 'Post',
        url: "/Home/createbitcoinqr",
        data: obj,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (data) {
            alert("YOUR QR IS READY DOWNLOAD IT")
            $("#three-panel").html(data)
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




function uploadFiles(obj ) {

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





//$(document).on('submit', 'urlform', function (e) {
//    e.preventDefault();
//    //your code goes here
//    //100% works

//    let tt = document.getElementById("URL").value;
//    alert(tt)
  
//});

//function createurlqr(event)
//{
//    event.preventDefault();

//    alert("Enteredd")


 


//}















(function () {
    "use strict";

    /**
     * Easy selector helper function
     */
    const select = (el, all = false) => {
        el = el.trim()
        if (all) {
            return [...document.querySelectorAll(el)]
        } else {
            return document.querySelector(el)
        }
    }

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        let selectEl = select(el, all)
        if (selectEl) {
            if (all) {
                selectEl.forEach(e => e.addEventListener(type, listener))
            } else {
                selectEl.addEventListener(type, listener)
            }
        }
    }

    /**
     * Easy on scroll event listener 
     */
    const onscroll = (el, listener) => {
        el.addEventListener('scroll', listener)
    }

    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = select('#navbar .scrollto', true)
    const navbarlinksActive = () => {
        let position = window.scrollY + 200
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return
            let section = select(navbarlink.hash)
            if (!section) return
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active')
            } else {
                navbarlink.classList.remove('active')
            }
        })
    }
    window.addEventListener('load', navbarlinksActive)
    onscroll(document, navbarlinksActive)

    /**
     * Scrolls to an element with header offset
     */
    const scrollto = (el) => {
        let header = select('#header')
        let offset = header.offsetHeight

        let elementPos = select(el).offsetTop
        window.scrollTo({
            top: elementPos - offset,
            behavior: 'smooth'
        })
    }

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top')
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active')
            } else {
                backtotop.classList.remove('active')
            }
        }
        window.addEventListener('load', toggleBacktotop)
        onscroll(document, toggleBacktotop)
    }

    /**
     * Mobile nav toggle
     */
    on('click', '.mobile-nav-toggle', function (e) {
        select('#navbar').classList.toggle('navbar-mobile')
        this.classList.toggle('bi-list')
        this.classList.toggle('bi-x')
    })

    /**
     * Mobile nav dropdowns activate
     */
    on('click', '.navbar .dropdown > a', function (e) {
        if (select('#navbar').classList.contains('navbar-mobile')) {
            e.preventDefault()
            this.nextElementSibling.classList.toggle('dropdown-active')
        }
    }, true)

    /**
     * Scrool with ofset on links with a class name .scrollto
     */
    on('click', '.scrollto', function (e) {
        if (select(this.hash)) {
            e.preventDefault()

            let navbar = select('#navbar')
            if (navbar.classList.contains('navbar-mobile')) {
                navbar.classList.remove('navbar-mobile')
                let navbarToggle = select('.mobile-nav-toggle')
                navbarToggle.classList.toggle('bi-list')
                navbarToggle.classList.toggle('bi-x')
            }
            scrollto(this.hash)
        }
    }, true)

    /**
     * Scroll with ofset on page load with hash links in the url
     */
    window.addEventListener('load', () => {
        if (window.location.hash) {
            if (select(window.location.hash)) {
                scrollto(window.location.hash)
            }
        }
    });

})