
window.addEventListener("DOMContentLoaded", function () {

    const mobileBtn = document.querySelector("#btn-mobile")

    mobileBtn.addEventListener('click', () => {
        const menu = document.querySelector('#mobile-menu')

        const isOpen = menu.getAttribute('aria-expanded') === 'true'
        //console.log(isOpen)
        menu.setAttribute('aria-expanded', !isOpen)
    })
});
