{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=_CHANGE_ME;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
};




var pop = {
    // (A) ATTACH POPUP HTML
    pWrap: null,  // html popup wrapper
    pTitle: null, // html popup title
    pText: null,  // html popup text
    init: () => {
        // (A1) POPUP WRAPPER
        pop.pWrap = document.createElement("div");
        pop.pWrap.id = "popwrap";
        document.body.appendChild(pop.pWrap);

        // (A2) POPUP INNERHTML
        pop.pWrap.innerHTML =
            `<div id="popbox">
      <h1 id="poptitle"></h1>
      <img src="shape.jpg" alt="Girl in a jacket" width="500" height="600">
      <p id="poptext"></p>
      <div id="popclose" onclick="pop.close()">&#9746;</div>
    </div>`;
        pop.pTitle = document.getElementById("poptitle");
        pop.pText = document.getElementById("poptext");
    },

    // (B) OPEN POPUP
    open: (title, text) => {
        pop.pTitle.innerHTML = title;
        pop.pText.innerHTML = text;
        pop.pWrap.classList.add("open");
    },

    // (C) CLOSE POPUP
    close: () => { pop.pWrap.classList.remove("open"); }
};
window.addEventListener("DOMContentLoaded", pop.init);



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

