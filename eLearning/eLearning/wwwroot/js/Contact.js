function addNavButtons() {
    const btnNode = document.querySelector('.navbar-buttons');
    while (btnNode.hasChildNodes()) {
        btnNode.removeChild(btnNode.firstChild);
    }
}

document.addEventListener("DOMContentLoaded", () => {
    addNavButtons();
});