function goLogout() {
    location.href = location.origin + '/home/logout';
}

function setDetailButtonEvent() {
    const buttonNode = document.querySelector('.nav-logout');
    buttonNode.addEventListener('click', goLogout);
}

document.addEventListener("DOMContentLoaded", () => {
    setDetailButtonEvent();
});